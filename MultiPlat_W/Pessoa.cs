using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySqlConnector;

namespace MultiPlat_W
{
    public class Pessoa
    {
        public int id_pessoa { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string celular { get; set; }

        readonly MySqlConnection conn = new MySqlConnection(@"server=sql.freedb.tech;port=3306;database=freedb_dbMultiPlat;user id=freedb_PedWat;password=k8PT4G&Dt?kb$k2;charset=utf8");

        public List<Pessoa> Listar()
        {
            try
            {
                List<Pessoa> li = new List<Pessoa>();

                string sql = "SELECT * FROM pessoas";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pessoa p = new Pessoa()
                    {
                        id_pessoa = (int)dr["id_pessoa"],
                        nome = dr["nome"].ToString(),
                        cidade = dr["cidade"].ToString(),
                        celular = dr["celular"].ToString()
                    };

                    li.Add(p);
                }
                dr.Close();

                conn.Close();

                return li;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
