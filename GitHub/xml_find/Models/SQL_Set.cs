using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQL
{
    public class SQL_Set
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vivian\Documents\Visual Studio 2015\Projects\k105-2\GitHub\xml_find\xml_find\SQL_Data\PlaySQL.mdf;Integrated Security=True";


        public void CreatePlay(Models.play plays)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    play_sql(number,title,people,adress,travel,money,stay,CreateTime)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}')
",plays.number,plays.title,plays.people,plays.adress,plays.travel,plays.money,plays.stay,plays.CreateTime.ToString("yyyy/MM/dd"));
            //上為資料庫；下為對應要的資料
            command.ExecuteNonQuery();


            connection.Close();
        }

        public List<Models.play> ReadPlay()
        {
            var result = new List<Models.play>();
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select * from play_sql");
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.play item = new Models.play();
                item.number = reader["number"].ToString();
                item.title = reader["title"].ToString();
                item.people = reader["people"].ToString();
                item.adress = reader["adress"].ToString();
                item.travel = reader["travel"].ToString();
                item.money = reader["money"].ToString();
                item.stay = reader["stay"].ToString();
                //item.CreateTime = reader["CreateTime"].ToString();
                result.Add(item);
            }

            connection.Close();
            return result;

        }
    }//class
}//namespace
