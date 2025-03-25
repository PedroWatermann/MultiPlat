using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar: {ex.Message}");
                return null;
            }
        }

        public void Inserir(Pessoa p)
        {
            try
            {
                string sql = "INSERT INTO pessoas (nome, cidade, celular) VALUES (@nome, @cidade, @celular)";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@nome", MySqlDbType.String).Value = p.nome;
                cmd.Parameters.Add("@cidade", MySqlDbType.String).Value = p.cidade;
                cmd.Parameters.Add("@celular", MySqlDbType.String).Value = p.celular;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir: {ex.Message}");
            }
        }

        public void Atualizar(Pessoa p)
        {
            try
            {
                string sql = "UPDATE pessoas SET nome = @nome, cidade = @cidade, celular = @celular WHERE id_pessoa = @id_pessoa";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@nome", MySqlDbType.String).Value = p.nome;
                cmd.Parameters.Add("@cidade", MySqlDbType.String).Value = p.cidade;
                cmd.Parameters.Add("@celular", MySqlDbType.String).Value = p.celular;
                cmd.Parameters.Add("@id_pessoa", MySqlDbType.Int32).Value = p.id_pessoa;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar: {ex.Message}");
            }
        }

        public void Excluir(int id_pessoa)
        {
            try
            {
                string sql = "DELETE FROM pessoas WHERE id_pessoa = @id_pessoa";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@id_pessoa", MySqlDbType.String).Value = id_pessoa;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}");
            }
        }

        public void Localizar(int id_pessoa)
        {
            try
            {
                string sql = "SELECT * FROM pessoas WHERE id_pessoa = @id_pessoa";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@id_pessoa", MySqlDbType.String).Value = id_pessoa;
                cmd.CommandType = CommandType.Text;
                
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    nome = dr["nome"].ToString();
                    cidade = dr["cidade"].ToString();
                    celular = dr["celular"].ToString();
                }
                dr.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}");
            }
        }

        public bool RegistroRepetido(string nome, string celular)
        {
            try
            {
                string sql = "SELECT * FROM pessoas WHERE nome = @nome AND celular = @celular";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@nome", MySqlDbType.String).Value = nome;
                cmd.Parameters.Add("@celular", MySqlDbType.String).Value = celular;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                object res = cmd.ExecuteScalar();
                if (res != null)
                {
                    conn.Close();
                    return (int)res > 0;
                }

                conn.Close();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}");
                return false;
            }
        }
    }
}
