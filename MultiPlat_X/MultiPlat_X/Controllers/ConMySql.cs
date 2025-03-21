using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;
using MultiPlat_X.Models;

namespace MultiPlat_X.Controllers
{
    public class ConMySql
    {
        static readonly string conection = @"server=sql.freedb.tech;port=3306;database=freedb_dbMultiPlat;user id=freedb_PedWat;password=k8PT4G&Dt?kb$k2;charset=utf8"; // String de conexão

        public static List<ModPessoa> Listar() // 'static' só roda aqui e devolve algum retorno
        {
            try
            {
                List<ModPessoa> li = new List<ModPessoa>();

                string sql = "SELECT * FROM pessoas";

                using (MySqlConnection conn = new MySqlConnection(conection))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ModPessoa p = new ModPessoa()
                                {
                                    id_pessoa = dr.GetInt32(0),
                                    nome = dr.GetString(1),
                                    cidade = dr.GetString(2),
                                    celular = dr.GetString(3)
                                };

                                li.Add(p);
                            }
                        }
                    }

                    conn.Close();

                    return li;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Inserir(string nome, string cidade, string celular)
        {
            try
            {
                string sql = "INSERT INTO pessoas (nome, cidade, celular) VALUES (@nome, @cidade, @celular)";

                using (MySqlConnection conn = new MySqlConnection(conection))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                        cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = cidade;
                        cmd.Parameters.Add("@celular", MySqlDbType.VarChar).Value = celular;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Atualizar(ModPessoa p)
        {
            try
            {
                string sql = "UPDATE pessoas SET nome = @nome, cidade  = @cidade, celular = @celular WHERE id_pessoa = @id_pessoa";

                using (MySqlConnection conn = new MySqlConnection(conection))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = p.nome;
                        cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = p.cidade;
                        cmd.Parameters.Add("@celular", MySqlDbType.VarChar).Value = p.celular;
                        cmd.Parameters.Add("@id_pessoa", MySqlDbType.Int32).Value = p.id_pessoa;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Excluir(ModPessoa p)
        {
            string sql = "DELETE FROM pessoas WHERE id_pessoa = @id_pessoa";

            using (MySqlConnection conn = new MySqlConnection(conection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@id_pessoa", MySqlDbType.Int32).Value = p.id_pessoa;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}