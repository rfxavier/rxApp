using System;
using System.Collections.Generic;
using System.Linq;
using rxApp.Models;

namespace rxApp.dataObjClasses
{
    public class dsCofre
    {
        public class CofreDiffComm
        {
            public string id_cofre { get; set; }
            public string cofre_nome { get; set; }
            public string cofre_serie { get; set; }
            public string cofre_tipo { get; set; }
            public string cofre_marca { get; set; }
            public string cofre_modelo { get; set; }
            public string cofre_tamanho_lote { get; set; }
            public Nullable<System.DateTime> comm_date { get; set; }
            public int? secDiff { get; set; }
            public long? id_cliente { get; set; }
            public string cod_cliente { get; set; }
            public string nome_cliente { get; set; }
            public string razao_social_cliente { get; set; }
            public long? id_loja { get; set; }
            public string cod_loja { get; set; }
            public string nome_loja { get; set; }
            public string razao_social_loja { get; set; }
            public string commRemark { get; set; }
            public string commStatus { get; set; }
            public string commStatusCode { get; set; }
            public string cofre_loja_key { get; set; }
        }

        public class Cofre
        {
            public string id_cofre { get; set; }
            public string cofre_nome { get; set; }
            public string cofre_serie { get; set; }
            public string cofre_tipo { get; set; }
            public string cofre_marca { get; set; }
            public string cofre_modelo { get; set; }
            public string cofre_tamanho_lote { get; set; }
            public long? id_cliente { get; set; }
            public string cod_cliente { get; set; }
            public string nome_cliente { get; set; }
            public string razao_social_cliente { get; set; }

        }

        public static List<CofreDiffComm> GetCofreCommStatus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cofreList = ctx.Database.SqlQuery<CofreDiffComm>(
                    "select c.id_cofre, c.nome cofre_nome, c.serie cofre_serie, c.marca cofre_marca, c.modelo cofre_modelo, c.tamanho_malote cofre_tamaho_malote, cli.id id_cliente, cli.cod_cliente, cli.nome nome_cliente, cli.razao_social razao_social_cliente, l.id id_loja, l.cod_loja, l.nome nome_loja, l.razao_social razao_social_loja,right('            ' + COALESCE(c.id_cofre,''), 12) + right('      ' + COALESCE(c.cod_loja,''), 6) cofre_loja_key from cofre c INNER JOIN loja l ON c.cod_loja = l.cod_loja INNER JOIN cliente cli ON l.cod_cliente = cli.cod_cliente").ToList();

                var cofreCommList = ctx.Database.SqlQuery<CofreDiffComm>(
                    $"select id_cofre, max(cofre_nome) cofre_nome, max(cofre_serie) cofre_serie, max(cofre_tipo) cofre_tipo, max(cofre_marca) cofre_marca, max(cofre_modelo) cofre_modelo, max(cofre_tamanho_malote) cofre_tamaho_malote, max(data_tmst_end_datetime) comm_date, DATEDIFF(second, max(data_tmst_end_datetime), GETDATE()) secDiff, max(id_cliente) id_cliente, max(cod_cliente) cod_cliente, max(nome_cliente) nome_cliente, max(razao_social_cliente) razao_social_cliente, max(id_loja) id_loja, max(cod_loja) cod_loja, max(nome_loja) nome_loja, max(razao_social_loja) razao_social_loja, CAST(DATEDIFF(Minute, max(data_tmst_end_datetime), GETDATE())/60/24 as Varchar(50)) ++ 'd ' ++ CAST((DATEDIFF(Minute, max(data_tmst_end_datetime), GETDATE())/60)-((DATEDIFF(Minute, max(data_tmst_end_datetime), GETDATE())/60/24)*24) as Varchar(50)) ++ 'h ' ++ CAST((DATEDIFF(Minute, max(data_tmst_end_datetime), GETDATE())) - (DATEDIFF(HOUR, max(data_tmst_end_datetime), GETDATE())*60) as Varchar(50)) ++ 'm' commRemark, right('            ' + COALESCE(id_cofre,''), 12) + right('      ' + COALESCE(cod_loja,''), 6) cofre_loja_key from message_view group by id_cofre, cod_loja").ToList();

                foreach (var cofreComm in cofreCommList)
                {
                    cofreComm.commStatus = "Sem dados";
                    cofreComm.commStatusCode = "00";

                    if (cofreComm.secDiff != null)
                    {
                        cofreComm.commStatus = "Dentro de 24h";
                        cofreComm.commStatusCode = "01";
                        if (cofreComm.secDiff > 86400 && cofreComm.secDiff <= 172800)
                        {
                            cofreComm.commStatus = "Entre 24 e 48h";
                            cofreComm.commStatusCode = "02";
                        }
                        else
                        {
                            cofreComm.commStatus = "Acima de 48h";
                            cofreComm.commStatusCode = "03";
                        }
                    }
                }

                foreach (var cofre in cofreList)
                {
                    if (cofreCommList.All(cc => cc.cofre_loja_key != cofre.cofre_loja_key))
                    {
                        cofreCommList.Add(new CofreDiffComm()
                        {
                            id_cofre = cofre.id_cofre,
                            cofre_nome = cofre.cofre_nome,
                            cofre_serie = cofre.cofre_serie,
                            cofre_tipo = cofre.cofre_tipo,
                            cofre_marca = cofre.cofre_marca,
                            cofre_modelo = cofre.cofre_modelo,
                            cofre_tamanho_lote = cofre.cofre_tamanho_lote,
                            id_cliente = cofre.id_cliente,
                            cod_cliente = cofre.cod_cliente,
                            nome_cliente = cofre.nome_cliente,
                            razao_social_cliente = cofre.razao_social_cliente,
                            id_loja = cofre.id_loja,
                            cod_loja = cofre.cod_loja,
                            nome_loja = cofre.nome_loja,
                            razao_social_loja = cofre.razao_social_loja,
                            commStatus = "Sem dados",
                            commStatusCode = "00"
                        });
                    }
                }

                cofreCommList = cofreCommList.Where(item => cofreList.Any(cofre => cofre.cofre_loja_key.Equals(item.cofre_loja_key)) || item.commStatusCode == "00").ToList();

                return cofreCommList;
            }
        }
        public static List<CofreDiffComm> GetCofreCommStatusPorCliente(long clienteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cofreList = ctx.Database.SqlQuery<CofreDiffComm>(
                    $"select c.id_cofre, c.nome cofre_nome, c.serie cofre_serie, c.marca cofre_marca, c.modelo cofre_modelo, c.tamanho_malote cofre_tamaho_malote, cli.id id_cliente, cli.cod_cliente, cli.nome nome_cliente, cli.razao_social razao_social_cliente,right('            ' + COALESCE(c.id_cofre,''), 12) + right('      ' + COALESCE(c.cod_loja,''), 6) cofre_loja_key from cofre c INNER JOIN loja l ON c.cod_loja = l.cod_loja INNER JOIN cliente cli ON l.cod_cliente = cli.cod_cliente where cli.id = {clienteId.ToString()}").ToList();

                var cofreCommList = ctx.Database.SqlQuery<CofreDiffComm>(
                    $"select id_cofre, max(cofre_nome) cofre_nome, max(cofre_serie) cofre_serie, max(cofre_tipo) cofre_tipo, max(cofre_marca) cofre_marca, max(cofre_modelo) cofre_modelo, max(cofre_tamanho_malote) cofre_tamaho_malote, max(data_tmst_end_datetime) comm_date, DATEDIFF(second, max(data_tmst_end_datetime), GETDATE()) secDiff, max(id_cliente) id_cliente, max(cod_cliente) cod_cliente, max(nome_cliente) nome_cliente, max(razao_social_cliente) razao_social_cliente, max(id_loja) id_loja, max(cod_loja) cod_loja, max(nome_loja) nome_loja, max(razao_social_loja) razao_social_loja, CAST(DATEDIFF(Minute, max(data_tmst_end_datetime), GETDATE())/60/24 as Varchar(50)) ++ 'd ' ++ CAST((DATEDIFF(Minute, max(data_tmst_end_datetime), GETDATE())/60)-((DATEDIFF(Minute, max(data_tmst_end_datetime), GETDATE())/60/24)*24) as Varchar(50)) ++ 'h ' ++ CAST((DATEDIFF(Minute, max(data_tmst_end_datetime), GETDATE())) - (DATEDIFF(HOUR, max(data_tmst_end_datetime), GETDATE())*60) as Varchar(50)) ++ 'm' commRemark, right('            ' + COALESCE(id_cofre,''), 12) + right('      ' + COALESCE(cod_loja,''), 6) cofre_loja_key from message_view where id_cliente = {clienteId.ToString()} group by id_cofre, cod_loja").ToList();

                foreach (var cofreComm in cofreCommList)
                {
                    cofreComm.commStatus = "Sem dados";
                    cofreComm.commStatusCode = "00";

                    if (cofreComm.secDiff != null)
                    {
                        cofreComm.commStatus = "Dentro de 24h";
                        cofreComm.commStatusCode = "01";
                        if (cofreComm.secDiff > 86400 && cofreComm.secDiff <= 172800)
                        {
                            cofreComm.commStatus = "Entre 24 e 48h";
                            cofreComm.commStatusCode = "02";
                        }
                        else
                        {
                            cofreComm.commStatus = "Acima de 48h";
                            cofreComm.commStatusCode = "03";
                        }
                    }
                }

                foreach (var cofre in cofreList)
                {
                    if (cofreCommList.All(cc => cc.cofre_loja_key != cofre.cofre_loja_key))
                    {
                        cofreCommList.Add(new CofreDiffComm()
                        {
                            id_cofre = cofre.id_cofre,
                            cofre_nome = cofre.cofre_nome,
                            cofre_serie = cofre.cofre_serie,
                            cofre_tipo = cofre.cofre_tipo,
                            cofre_marca = cofre.cofre_marca,
                            cofre_modelo = cofre.cofre_modelo,
                            cofre_tamanho_lote = cofre.cofre_tamanho_lote,
                            id_cliente = cofre.id_cliente,
                            cod_cliente = cofre.cod_cliente,
                            nome_cliente = cofre.nome_cliente,
                            razao_social_cliente = cofre.razao_social_cliente,
                            id_loja = cofre.id_loja,
                            cod_loja = cofre.cod_loja,
                            nome_loja = cofre.nome_loja,
                            razao_social_loja = cofre.razao_social_loja,
                            commStatus = "Sem dados",
                            commStatusCode = "00"
                        });
                    }
                }

                cofreCommList = cofreCommList.Where(item => cofreList.Any(cofre => cofre.cofre_loja_key.Equals(item.cofre_loja_key)) || item.commStatusCode == "00").ToList();

                return cofreCommList;
            }
        }

    }
}