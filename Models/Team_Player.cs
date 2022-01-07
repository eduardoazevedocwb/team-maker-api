using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace team_maker.Models
{
    public class Team_Player : Base, IBase
    {
        public int? idPlayer { get; set; }
        public int? idTeam { get; set; }
        public IList<string> GetListColumn()
        {
            var list = new List<string>()
            {
                "id","idPlayer","idTeam", "name","ative"
            };
            return list;
        }
        public IList<Team_Player> ConvertDataReader(MySqlDataReader dataReader)
        {
            var list = new List<Team_Player>();
            while (dataReader.Read())
            {
                var id = Convert.ToInt32(dataReader["id"].ToString().Trim());
                var name = dataReader["name"].ToString().Trim();
                var idPlayer = Convert.ToInt32(dataReader["idPlayer"].ToString().Trim());
                var idTeam = Convert.ToInt32(dataReader["idTeam"].ToString().Trim());
                var ative = dataReader["ative"].ToString().Trim() == "0" ? false : true;

                var item = new Team_Player()
                {
                    id = id,
                    name = name,
                    idPlayer = idPlayer,
                    idTeam = idTeam,
                    ative = ative
                };
                list.Add(item);
            }
            return list;
        }
    }
}