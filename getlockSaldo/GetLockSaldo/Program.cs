using NLog;
using SaldoCofre.Processor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GetLockSaldo
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            var processor = new SaldoProcessor();
            processor.ProcessCofres();
        }

        static List<CofreInfo> GetCofreList(SqlConnection connection)
        {
            var result = new List<CofreInfo>();

            string sql = @"
            SELECT c.id AS CofreId, c.id_cofre, c.nome AS CofreNome, c.cod_loja,
                    l.id AS LojaId, l.cod_cliente, cli.id AS ClienteId
            FROM dbo.cofre c
            JOIN dbo.loja l ON c.cod_loja = l.cod_loja
            JOIN dbo.cliente cli ON l.cod_cliente = cli.cod_cliente";

            using (var cmd = new SqlCommand(sql, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new CofreInfo
                    {
                        CofreId = (long)reader["CofreId"],
                        IdCofre = reader["id_cofre"].ToString(),
                        CofreNome = reader["CofreNome"].ToString(),
                        CodLoja = reader["cod_loja"].ToString(),
                        LojaId = (long)reader["LojaId"],
                        CodCliente = reader["cod_cliente"].ToString(),
                        ClienteId = (long)reader["ClienteId"]
                    });
                }
            }

            return result;
        }

        static MessageInfo GetSnapshotForCofre(SqlConnection connection, string idCofre)
        {

            var cmd = new SqlCommand(@"
            SELECT TOP 1 id_cofre, data_tmst_end_datetime, info_id, balance, balance_id
            FROM saldo_cofre_snapshot
            WHERE id_cofre = @id_cofre
            ORDER BY data_tmst_end_datetime DESC", connection);

            cmd.Parameters.AddWithValue("@id_cofre", idCofre);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new MessageInfo
                    {
                        IdCofre = reader["id_cofre"]?.ToString(),
                        DataTmstEndDatetime = reader["data_tmst_end_datetime"] as DateTime?,
                        InfoId = reader["info_id"]?.ToString(),
                        Balance = reader["balance"] as decimal?,
                        BalanceId = reader["balance_id"]?.ToString()
                    };
                }
            }

            return null;
        }

        static List<MessageInfo> GetAllSnapshots(SqlConnection connection)
        {
            var result = new List<MessageInfo>();

            string sql = @"
                    SELECT id_cofre, data_tmst_end_datetime, info_id, balance, balance_id
                    FROM dbo.saldo_cofre_snapshot";

            using (var cmd = new SqlCommand(sql, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new MessageInfo
                    {
                        IdCofre = reader["id_cofre"]?.ToString(),
                        DataTmstEndDatetime = reader["data_tmst_end_datetime"] as DateTime?,
                        InfoId = reader["info_id"]?.ToString(),
                        Balance = reader["balance"] as decimal?,
                        BalanceId = reader["balance_id"]?.ToString()
                    });
                }
            }

            return result;
        }

        //CREATE INDEX IX_message_latest ON message (id_cofre, data_tmst_end_datetime DESC)
        //INCLUDE (balance, info_id, balance_id);

        static MessageInfo GetLatestMessageAfter(SqlConnection connection, string idCofre, DateTime? since)
        {
            var cmd = new SqlCommand(@"
            SELECT TOP 1 id_cofre, data_tmst_end_datetime, info_id, balance, balance_id
            FROM message
            WHERE id_cofre = @id_cofre AND balance IS NOT NULL AND data_tmst_end_datetime > @since
            ORDER BY data_tmst_end_datetime DESC", connection);

            cmd.Parameters.AddWithValue("@id_cofre", idCofre);
            cmd.Parameters.AddWithValue("@since", since ?? DateTime.MinValue);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new MessageInfo
                    {
                        IdCofre = reader["id_cofre"]?.ToString(),
                        DataTmstEndDatetime = reader["data_tmst_end_datetime"] as DateTime?,
                        InfoId = reader["info_id"]?.ToString(),
                        Balance = reader["balance"] as decimal?,
                        BalanceId = reader["balance_id"]?.ToString()
                    };
                }
            }

            return null;
        }

        static MessageInfo GetLatestMessageOverall(SqlConnection connection, string idCofre)
        {
            var cmd = new SqlCommand(@"
            SELECT TOP 1 id_cofre, data_tmst_end_datetime, info_id, balance, balance_id
            FROM message
            WHERE id_cofre = @id_cofre AND balance IS NOT NULL
            ORDER BY data_tmst_end_datetime DESC", connection);

            cmd.Parameters.AddWithValue("@id_cofre", idCofre);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new MessageInfo
                    {
                        IdCofre = reader["id_cofre"]?.ToString(),
                        DataTmstEndDatetime = reader["data_tmst_end_datetime"] as DateTime?,
                        InfoId = reader["info_id"]?.ToString(),
                        Balance = reader["balance"] as decimal?,
                        BalanceId = reader["balance_id"]?.ToString()
                    };
                }
            }

            return null;
        }
        private static void UpsertSaldoCofreSnapshot(SqlConnection connection, CofreData cofre, MessageData latestMessage)
        {
            // Check if snapshot already exists for this cofre
            bool exists;
            using (var checkCmd = new SqlCommand("SELECT 1 FROM dbo.saldo_cofre_snapshot WHERE id_cofre = @id_cofre", connection))
            {
                checkCmd.Parameters.AddWithValue("@id_cofre", cofre.IdCofre);
                exists = checkCmd.ExecuteScalar() != null;
            }

            if (exists)
            {
                using (var updateCmd = new SqlCommand(@"
                            UPDATE dbo.saldo_cofre_snapshot
                            SET 
                                data_tmst_end_datetime = @data_tmst_end_datetime,
                                info_id = @info_id,
                                balance = @balance,
                                balance_id = @balance_id,
                                cofre_nome = @cofre_nome,
                                cod_loja = @cod_loja,
                                id_loja = @id_loja,
                                cod_cliente = @cod_cliente,
                                id_cliente = @id_cliente
                            WHERE id_cofre = @id_cofre", connection))
                {
                    AddSnapshotParameters(updateCmd, cofre, latestMessage);
                    updateCmd.ExecuteNonQuery();
                }
            }
            else
            {
                using (var insertCmd = new SqlCommand(@"
                            INSERT INTO dbo.saldo_cofre_snapshot (
                                data_tmst_end_datetime, id_cofre, cofre_nome, info_id, balance, balance_id,
                                cod_loja, id_loja, cod_cliente, id_cliente)
                            VALUES (
                                @data_tmst_end_datetime, @id_cofre, @cofre_nome, @info_id, @balance, @balance_id,
                                @cod_loja, @id_loja, @cod_cliente, @id_cliente)", connection))
                {
                    AddSnapshotParameters(insertCmd, cofre, latestMessage);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }


        private static void AddSnapshotParameters(SqlCommand cmd, CofreData cofre, MessageData msg)
        {
            cmd.Parameters.AddWithValue("@data_tmst_end_datetime", msg.DataTmstEndDatetime != null ? (object)msg.DataTmstEndDatetime : DBNull.Value);
            cmd.Parameters.AddWithValue("@id_cofre", cofre.IdCofre);
            cmd.Parameters.AddWithValue("@cofre_nome", cofre.CofreNome != null ? (object)cofre.CofreNome : DBNull.Value);
            cmd.Parameters.AddWithValue("@info_id", msg.InfoId != null ? (object)msg.InfoId : DBNull.Value);
            cmd.Parameters.AddWithValue("@balance", msg.Balance.HasValue ? (object)msg.Balance.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@balance_id", msg.BalanceId != null ? (object)msg.BalanceId : DBNull.Value);
            cmd.Parameters.AddWithValue("@cod_loja", cofre.CodLoja != null ? (object)cofre.CodLoja : DBNull.Value);
            cmd.Parameters.AddWithValue("@id_loja", cofre.IdLoja.HasValue ? (object)cofre.IdLoja.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@cod_cliente", cofre.CodCliente != null ? (object)cofre.CodCliente : DBNull.Value);
            cmd.Parameters.AddWithValue("@id_cliente", cofre.IdCliente.HasValue ? (object)cofre.IdCliente.Value : DBNull.Value);
        }
    }

    public class CofreInfo
    {
        public long CofreId { get; set; }
        public string IdCofre { get; set; }
        public string CofreNome { get; set; }
        public string CodLoja { get; set; }
        public long LojaId { get; set; }
        public string CodCliente { get; set; }
        public long ClienteId { get; set; }
    }

    public class MessageInfo
    {
        public string IdCofre { get; set; }
        public DateTime? DataTmstEndDatetime { get; set; }
        public string InfoId { get; set; }
        public decimal? Balance { get; set; }
        public string BalanceId { get; set; }
    }

    public class MessageData
    {
        public string IdCofre { get; set; }
        public DateTime? DataTmstEndDatetime { get; set; }
        public string InfoId { get; set; }
        public decimal? Balance { get; set; }
        public string BalanceId { get; set; }
    }

    public class CofreData
    {
        public string IdCofre { get; set; }
        public string CofreNome { get; set; }
        public string CodLoja { get; set; }
        public long? IdLoja { get; set; }
        public string CodCliente { get; set; }
        public long? IdCliente { get; set; }
    }
}

