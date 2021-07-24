using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace foodlist
{
    public class mysql
    {
        static string connectionString = "server=localhost;user=root;database=foodlist;port=3306;password=grW1314!";

        public static food RunQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                food comida = new food();
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comida.id = (int)reader["id"];
                    comida.nome = reader["nome"].ToString();
                    comida.tipo = reader["tipo"].ToString();
                    comida.tempo = (int)reader["tempo"];
                    comida.categoria = reader["categoria"].ToString();
                    comida.nota = float.Parse(reader["nota"].ToString());
                    comida.dificuldade = reader["dificuldade"].ToString();
                }
                return comida;
            }
        }
    }
}