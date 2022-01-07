using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace team_maker.Models
{
    public class Championship_Team : Base, IBase
    {
        public int? idChampionship { get; set; }
        public int? idTeam { get; set; }
        public IList<string> GetListColumn()
        {
            var list = new List<string>()
            {
                "id","idChampionship","idTeam", "name","ative"
            };
            return list;
        }
        public IList<Championship_Team> ConvertDataReader(MySqlDataReader dataReader)
        {
            var list = new List<Championship_Team>();
            while (dataReader.Read())
            {
                var id = Convert.ToInt32(dataReader["id"].ToString().Trim());
                var name = dataReader["name"].ToString().Trim();
                var idChampionship = Convert.ToInt32(dataReader["idChampionship"].ToString().Trim());
                var idTeam = Convert.ToInt32(dataReader["idTeam"].ToString().Trim());
                var ative = dataReader["ative"].ToString().Trim() == "0" ? false : true;

                var item = new Championship_Team()
                {
                    id = id,
                    name = name,
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