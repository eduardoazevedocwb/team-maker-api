using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace team_maker.Models
{
    public class Player_Team_Championship : Base, IBase
    {
        public int? idPlayer { get; set; }
        public int? idChampionship { get; set; }
        public int? idTeam { get; set; }
        public IList<string> GetListColumn()
        {
            var list = new List<string>()
            {
                "id","idPlayer","idChampionship","idTeam", "name","ative"
            };
            return list;
        }
        public IList<Player_Team_Championship> ConvertDataReader(MySqlDataReader dataReader)
        {
            var list = new List<Player_Team_Championship>();
            while (dataReader.Read())
            {
                var id = Convert.ToInt32(dataReader["id"].ToString().Trim());
                var name = dataReader["name"].ToString().Trim();
                var idPlayer = Convert.ToInt32(dataReader["idPlayer"].ToString().Trim());
                var idChampionship = Convert.ToInt32(dataReader["idChampionship"].ToString().Trim());
                var idTeam = Convert.ToInt32(dataReader["idTeam"].ToString().Trim());
                var ative = dataReader["ative"].ToString().Trim() == "0" ? false : true;

                var item = new Player_Team_Championship()
                {
                    id = id,
                    name = name,
                    idPlayer = idPlayer,
                    idChampionship = idChampionship,
                    idTeam = idTeam,
                    ative = ative
                };
                list.Add(item);
            }
            return list;
        }
    }
}