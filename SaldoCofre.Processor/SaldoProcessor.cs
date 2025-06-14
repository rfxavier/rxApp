﻿using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace SaldoCofre.Processor
{
    public class SaldoProcessor
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public void ProcessCofres(
            List<string> idCofreList = null,
            List<long> idLojaList = null,
            long? idCliente = null)
        {
            try
            {
                Log.Info("Run started at " + DateTime.Now);

                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var cofres = GetCofreList(connection, idCofreList, idLojaList, idCliente);
                    var allSnapshots = GetAllSnapshots(connection);
                    var snapshotByCofreId = allSnapshots
                        .GroupBy(s => s.IdCofre)
                        .ToDictionary(g => g.Key, g => g.OrderByDescending(s => s.DataTmstEndDatetime).First());

                    foreach (var cofre in cofres)
                    {
                        snapshotByCofreId.TryGetValue(cofre.IdCofre, out var snapshot);

                        var message = snapshot != null
                            ? GetLatestMessageAfter(connection, cofre.IdCofre, snapshot.DataTmstEndDatetime)
                            : GetLatestMessageOverall(connection, cofre.IdCofre);

                        Log.Info($"Cofre: {cofre.CofreId}, Nome: {cofre.CofreNome}, Balance: {message?.Balance}, InfoID: {message?.InfoId}, Time: {message?.DataTmstEndDatetime}");

                        if (message != null)
                        {
                            Log.Info($"Resolved message for cofre {cofre.IdCofre}: {message.Balance}");

                            // ✅ Convert CofreInfo → CofreData
                            var cofreData = new CofreData
                            {
                                IdCofre = cofre.IdCofre,
                                CofreNome = cofre.CofreNome,
                                CodLoja = cofre.CodLoja,
                                IdLoja = cofre.LojaId,
                                CodCliente = cofre.CodCliente,
                                IdCliente = cofre.ClienteId
                            };

                            // ✅ Convert MessageInfo → MessageData
                            var messageData = new MessageData
                            {
                                IdCofre = message.IdCofre,
                                DataTmstEndDatetime = message.DataTmstEndDatetime,
                                InfoId = message.InfoId,
                                Balance = message.Balance,
                                BalanceId = message.BalanceId
                            };

                            UpsertSaldoCofreSnapshot(connection, cofreData, messageData);
                        }
                    }
                }

                Log.Info("Run completed successfully at " + DateTime.Now);
                Environment.ExitCode = 0; // Success
            }
            catch (Exception ex)
            {
                Log.Error("Run failed: " + ex.ToString());
                Environment.ExitCode = 1; // Failure
            }
        }

        static List<CofreInfo> GetCofreList(
            SqlConnection connection,
            List<string> idCofreList = null,
            List<long> idLojaList = null,
            long? idCliente = null)
        {
            var result = new List<CofreInfo>();

            string sql = @"
                SELECT c.id AS CofreId, c.id_cofre, c.nome AS CofreNome, c.cod_loja,
                        l.id AS LojaId, l.cod_cliente, cli.id AS ClienteId
                FROM dbo.cofre c
                JOIN dbo.loja l ON c.cod_loja = l.cod_loja
                JOIN dbo.cliente cli ON l.cod_cliente = cli.cod_cliente
                WHERE 1=1";

            var parameters = new List<SqlParameter>();

            if (idCofreList != null && idCofreList.Any())
            {
                var cofreParams = idCofreList
                    .Select((id, index) => {
                        var param = new SqlParameter($"@idCofre{index}", id);
                        parameters.Add(param);
                        return param.ParameterName;
                    });
                sql += $" AND c.id_cofre IN ({string.Join(", ", cofreParams)})";
            }

            if (idLojaList != null && idLojaList.Any())
            {
                var lojaParams = idLojaList
                    .Select((id, index) => {
                        var param = new SqlParameter($"@idLoja{index}", id);
                        parameters.Add(param);
                        return param.ParameterName;
                    });
                sql += $" AND l.id IN ({string.Join(", ", lojaParams)})";
            }

            if (idCliente.HasValue)
            {
                sql += " AND cli.id = @idCliente";
                parameters.Add(new SqlParameter("@idCliente", idCliente.Value));
            }

            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());

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

