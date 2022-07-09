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
        }

        public static List<CofreDiffComm> GetCofreCommStatus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var resultList = ctx.Database.SqlQuery<CofreDiffComm>(
                    "select id_cofre, max(cofre_nome) cofre_nome, max(cofre_serie) cofre_serie, max(cofre_tipo) cofre_tipo, max(cofre_marca) cofre_marca, max(cofre_modelo) cofre_modelo, max(cofre_tamanho_malote) cofre_tamaho_malote, max(data_tmst_end_datetime) comm_date, DATEDIFF(second, max(data_tmst_end_datetime), GETDATE()) secDiff, max(id_cliente) id_cliente, max(cod_cliente) cod_cliente, max(nome_cliente) nome_cliente, max(razao_social_cliente) razao_social_cliente, max(id_loja) id_loja, max(cod_loja) cod_loja, max(nome_loja) nome_loja, max(razao_social_loja) razao_social_loja, '' commRemark from message_view group by id_cofre").ToList();

                return resultList;
            }
        }
    }
}