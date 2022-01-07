using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MySql.Data.MySqlClient;
using team_maker.Models;
using team_maker_api.Models;

namespace team_maker_api.DataBase
{
     public class DBMySql
    {
         private string database;

         private MySqlConnection connection;
         private MySqlConnection Config(string table)
        {
            database = "`team-maker`.`" + table.ToLower() + "` ";
            return new MySqlConnection("server=localhost ; database=team-maker ; uid='root' ; pwd='polegada'");
        }
         public IList<Object> Get(string table, IList<string> listCol, ref string msg)
        {
            var listObject = new List<Object>();

            msg = string.Empty;
            if (string.IsNullOrEmpty(table) || listCol.Count <= 0)
            {
                msg = "01 - Não foram informadas as informações necessárias para a consulta no banco de dados";
                return null;
            }

            using (var connection = Config(table))
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand();
                query.Connection = connection;

                #region Query text
                query.CommandText = "SELECT ";
                foreach (var col in listCol)
                {
                    query.CommandText += query.CommandText == "SELECT " ? col : "," + col;
                }
                query.CommandText += " FROM " + database;
                #endregion

                listObject = ConvertDataReader(table, query.ExecuteReader());
                connection.Close();
            }

            return listObject;
        }
         public Object GetById(string table, IList<string> listCol, int id, ref string msg)
        {
            object obj = null;
            msg = string.Empty;

            if (string.IsNullOrEmpty(table) || listCol.Count <= 0)
            {
                msg = "02 - Não foram informadas as informações necessárias para a consulta no banco de dados";
                return null;
            }

            using (var connection = Config(table))
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand();
                query.Connection = connection;

                #region Query text
                query.CommandText = "SELECT ";
                foreach (var col in listCol)
                {
                    query.CommandText += query.CommandText == "SELECT " ? col : "," + col;
                }
                query.CommandText += " FROM " + database;
                query.CommandText += " WHERE ID = " + id;
                #endregion

                obj = ConvertDataReader(table, query.ExecuteReader())?.FirstOrDefault();
                connection.Close();
            }

            return obj;
        }
         public void Set(string table, IList<string> listCol, IList<object> listValue, ref string msg)
        {
            msg = string.Empty;

            #region validation
            if (string.IsNullOrEmpty(table) || listCol.Count <= 0 || listValue.Count <= 0)
            {
                msg = "03 - Não foram informadas as informações necessárias para a consulta no banco de dados";
                return;
            }
            if (listCol.Count != listValue.Count)
            {
                msg = "03 - Foram informados um número diferente de valores para os campos disponíveis no banco de dados";
                return;
            }
            #endregion

            //verifica se já existe
            if (GetById(table, listCol, (int)listValue[0], ref msg) != null)
            {
                Update(table, listCol, listValue, ref msg);
            }
            else
            {
                #region Create
                using (var connection = Config(table))
                {
                    connection.Open();
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = connection;

                    #region Query text
                    query.CommandText = "INSERT INTO " + database;
                    foreach (var col in listCol)
                    {
                        query.CommandText += query.CommandText == "INSERT INTO " + database ? "(" + col : "," + col;
                    }
                    query.CommandText += ")";
                    foreach (var col in listCol)
                    {
                        query.CommandText += !query.CommandText.Contains("VALUES") ? "VALUES(@" + col : ",@" + col + "";
                    }
                    query.CommandText += ")";
                    for (int i = 0; i < listCol.Count; i++)
                    {
                        query.Parameters.AddWithValue("@" + listCol[i], listValue[i]);
                    }
                    #endregion

                    query.ExecuteNonQuery();
                    query.Dispose();
                    connection.Close();
                }
                #endregion
            }
        }
         public void Delete(string table, IList<string> listCol, int id, ref string msg)
        {
            using (var connection = Config(table))
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand();
                query.Connection = connection;
                query.CommandText = "DELETE FROM " + database + " WHERE ID=" + id;
                query.ExecuteNonQuery();
                connection.Close();
            }
        }
        private  void Update(string table, IList<string> listCol, IList<object> listValue, ref string msg)
        {
            using (var connection = Config(table))
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand();
                query.Connection = connection;

                #region Query text
                var tempText = "UPDATE " + database + " SET ";
                query.CommandText = tempText;
                for (int i = 0; i < listCol.Count; i++)
                {
                    var value = listCol[i] + "=@" + listCol[i];
                    query.CommandText += query.CommandText == tempText ? value : "," + value;
                }
                query.CommandText += " WHERE ID=" + (int)listValue[0];
                for (int i = 0; i < listCol.Count; i++)
                {
                    query.Parameters.AddWithValue("@" + listCol[i], listValue[i]);
                }
                #endregion

                query.ExecuteNonQuery();
                connection.Close();
            }
        }
        private  List<object> ConvertDataReader(string table, MySqlDataReader dataReader)
        {
            var listObject = new List<Object>();
            switch (table)
            {
                case "Player":
                    var listPlayer = new Player().ConvertDataReader(dataReader);
                    listObject = listPlayer == null ? null : listPlayer.Cast<Object>().ToList();
                    break;
                case "Team":
                    var listTem = new Team().ConvertDataReader(dataReader);
                    listObject = listTem == null ? null : listTem.Cast<Object>().ToList();
                    break;
                case "Championship":
                    var listChampionship = new Championship().ConvertDataReader(dataReader);
                    listObject = listChampionship == null ? null : listChampionship.Cast<Object>().ToList();
                    break;
                case "Championship_Team":
                    var listChampionship_Team = new Championship_Team().ConvertDataReader(dataReader);
                    listObject = listChampionship_Team == null ? null : listChampionship_Team.Cast<Object>().ToList();
                    break;
                case "Player_Team_Championship":
                    var listPlayer_Team_Championship = new Player_Team_Championship().ConvertDataReader(dataReader);
                    listObject = listPlayer_Team_Championship == null ? null : listPlayer_Team_Championship.Cast<Object>().ToList();
                    break;
                case "Team_Player":
                    var listTeam_Player = new Team_Player().ConvertDataReader(dataReader);
                    listObject = listTeam_Player == null ? null : listTeam_Player.Cast<Object>().ToList();
                    break;
            }
            return listObject;
        }
    }
}