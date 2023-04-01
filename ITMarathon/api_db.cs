using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Windows.Forms.Design.AxImporter;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Data;
using Guna.UI2.WinForms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ITMarathon
{
    internal class api_db
    {

        public static string user = "", password = "";

        public bool session(string user, string pass)
        {

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var jsonData = "{\"username\":\""+user+"\",\"password\":\""+ pass + "\"}";
                var response = client.UploadString("https://uxhackathon.ro/api/activeSession.php", jsonData);

                dynamic customersList = JsonConvert.DeserializeObject(response);
                Console.WriteLine(customersList);
                if (customersList["loginSession"] == 1)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public bool check(string user, string pass)
        {

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var jsonData = "{\"username\":\"" + user + "\",\"password\":\"" + pass + "\"}";
                var response = client.UploadString("https://uxhackathon.ro/api/login.php", jsonData);

                dynamic customersList = JsonConvert.DeserializeObject(response);
                Console.WriteLine(customersList);
                if (customersList["loginSession"] == 1)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public void logout(string user, string pass)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var jsonData = "{\"username\":\"" + user + "\",\"password\":\"" + pass + "\"}";
                var response = client.UploadString("https://uxhackathon.ro/api/logout.php", jsonData);

                dynamic customersList = JsonConvert.DeserializeObject(response);
                Console.WriteLine(customersList);
                
            }
            
        }

        public void start_db()
        {
            var app = new app();
            app.conn.Close();
            if (app.conn.State != System.Data.ConnectionState.Open)
            {
                app.conn.Open();
                Console.WriteLine("DATABASE OK");
            }
        }

        public string name_get(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT * from users where username = @username", app.conn);
            cmd.Parameters.Add("@username", username);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read() != null)
                {
                    return read["nume"].ToString() + " " + read["prenume"].ToString();
                }
            }
            return "";
        }

        public void last_connect()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from last_conn", app.conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read() != null)
            {
                user = read["username"].ToString();
                password = read["password"].ToString();
                break;
            }
        }

        public void add_last_connect(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("UPDATE last_conn set username = @usr,  password = @pass", app.conn);
            cmd.Parameters.Add("@usr", SqlDbType.NVarChar).Value = username;
            cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = password;
            cmd.ExecuteNonQuery();
        }

        public bool in_db(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT * from users where username = @user", app.conn);
            cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = username;
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                return true;
            }
            else
                return false;
        }

        public MemoryStream image()
        {
            byte[] img = null;
            MemoryStream avatar = null;
            SqlCommand cmd = new SqlCommand("SELECT * from users where username = @user", app.conn);
            cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = app.username;
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                read.Read();
                if (read["foto"] != DBNull.Value)
                {
                    img = (byte[])(read["foto"]);
                    avatar = new MemoryStream(img);
                    return avatar;
                }
            }
            return null;
        }

        public void add_profil(SqlCommand cmd)
        {
            cmd.ExecuteNonQuery();
        }
    }
}
