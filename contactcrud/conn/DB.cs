using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;



namespace contactcrud.conn
{
    class DB
    {
        public MySqlConnection Conn;
 
            public DB()
        {
            string host = "localhost";
            string db = "contactdb";
            string port = "3306";
            string user = "root";
            string constring = "datasource =" + host + "; database =" + db + "; port =" + port + "; username =" + user + ";";
            Conn = new MySqlConnection(constring);
            
        }
    }

    class CRUD:DB
    {
        public string userid { set; get; }
        public string firstname { set; get; }
        public string surname { set; get; }
        public string gender { set; get; }
        public string phonenumber { set; get; }
        public string email { set; get; }



        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();



        public void Create_data()
        {
            Conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO `data`(`firstname`, `surname`, `gender`, `phonenumber`, `email`) VALUES(@firstname, @surname, @gender, @phonenumber, @email)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Conn;

                cmd.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@phonenumber", MySqlDbType.VarChar).Value = phonenumber;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

                cmd.ExecuteNonQuery();
                Conn.Close();

            }
        }

        public void Update_data()
        {
            Conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE data SET firstname=@firstname, surname=@surname, gender=@gender, phonenumber=@phonenumber, email=@email, userid=@userid";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Conn;

                cmd.Parameters.Add("@userid", MySqlDbType.VarChar).Value = userid;
                cmd.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@phonenumber", MySqlDbType.VarChar).Value = phonenumber;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

                cmd.ExecuteNonQuery();
                Conn.Close();


            }
        }

        public void Delete_data()
        {
            Conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM data WHERE userid=@userid";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Conn;

                cmd.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@phonenumber", MySqlDbType.VarChar).Value = phonenumber;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@userid", MySqlDbType.VarChar).Value = userid;

                cmd.ExecuteNonQuery();
                Conn.Close();


            }
        }


        public void Read_data()
        {
            dt.Clear();
            string query = "SELECT * FROM `data`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, Conn);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
