using APS.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.ScriptsSQL
{
    public class Query : IQuery
    {
        string conn = "Server=localhost\\SQLEXPRESS02; Database=aps_database; Trusted_Connection=True;";
        private string Name { get; set; }

        public Query(string name) 
        {
            Name = name;
        }

        List<AgrotoxicosEntity> agrotoxicoList = new List<AgrotoxicosEntity>();
        
        public List<AgrotoxicosEntity> GetAllByName()
        {
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(conn))
                {
                    sqlConnection.Open();

                    SqlCommand sql = new SqlCommand($@"SELECT 
                                dbo.[T_AGROTOXICOS].[Id]
                                ,dbo.[T_AGROTOXICOS].[Nome]
                                ,dbo.[T_AGROTOXICOS].[Grupo]
                                ,dbo.[T_AGROTOXICOS].[Classificacao]
                                ,dbo.[T_AGROTOXICOS].[Nivel]
                            FROM dbo.[T_USERS]
                                INNER JOIN dbo.[T_AGROTOXICOS] ON dbo.[T_USERS].[Nivel] >= dbo.[T_AGROTOXICOS].[Nivel]
                                    WHERE dbo.[T_USERS].[Login] = '{Name}' 
									ORDER BY dbo.[T_AGROTOXICOS].[Nivel] DESC"
                     , sqlConnection);

                    SqlDataReader dr = sql.ExecuteReader();
                    while (dr.Read())
                    {
                        AgrotoxicosEntity agrotoxico = new AgrotoxicosEntity();
                        agrotoxico.Id = int.Parse(dr.GetValue(0).ToString().Trim());
                        agrotoxico.Nome = dr.GetValue(1).ToString().Trim();
                        agrotoxico.Grupo = dr.GetValue(2).ToString().Trim();
                        agrotoxico.Classificacao = dr.GetValue(3).ToString().Trim();
                        agrotoxico.Nivel = int.Parse(dr.GetValue(4).ToString().Trim());

                        agrotoxicoList.Add(agrotoxico);
                    }
                    sqlConnection.Close();
                }
                return agrotoxicoList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
