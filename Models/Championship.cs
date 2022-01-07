using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using team_maker.Models;

namespace team_maker_api.Models
{
    public class Championship : Base, IBase
    {
        public DateTime initialDate { get; set; }
        public DateTime finalDate { get; set; }
        public int maxTeams { get; set; }
        public int minTeams { get; set; }
        public string place { get; set; }
        public bool male { get; set; }
        public bool female { get; set; }
        public int minAge { get; set; }
        public int maxAge { get; set; }
        public IList<string> GetListColumn()
        {
            var list = new List<string>()
            {
                "id","name","initialDate","finalDate","maxTeams","minTeams","place","male","female","minAge","maxAge","ative"
            };
            return list;
        }
        public IList<Championship> ConvertDataReader(MySqlDataReader dataReader)
        {
            var list = new List<Championship>();
            while (dataReader.Read())
            {
                var id = Convert.ToInt32(dataReader["id"].ToString().Trim());
                var name = dataReader["name"].ToString().Trim();
                var initialDate = string.IsNullOrEmpty(dataReader["initialDate"].ToString().Trim()) ?
                            new DateTime() : Convert.ToDateTime(dataReader["initialDate"].ToString().Trim());
                var finalDate = string.IsNullOrEmpty(dataReader["finalDate"].ToString().Trim()) ?
                            new DateTime() : Convert.ToDateTime(dataReader["finalDate"].ToString().Trim());
                var maxTeams = Convert.ToInt32(dataReader["maxTeams"].ToString().Trim());
                var minTeams = Convert.ToInt32(dataReader["minTeams"].ToString().Trim());
                var place = dataReader["place"].ToString().Trim();
                var male = dataReader["male"].ToString().Trim() == "0" ? false : true;
                var female = dataReader["female"].ToString().Trim() == "0" ? false : true;
                var minAge = Convert.ToInt32(dataReader["minAge"].ToString().Trim());
                var maxAge = Convert.ToInt32(dataReader["maxAge"].ToString().Trim());
                var ative = dataReader["ative"].ToString().Trim() == "0" ? false : true;

                var item = new Championship()
                {
                    id = id,
                    name = name,
                    initialDate = initialDate,
                    finalDate = finalDate,
                    maxTeams = maxTeams,
                    minTeams = minTeams,
                    place = place,
                    male = male,
                    female = female,
                    minAge = minAge,
                    maxAge = maxAge,
                    ative = ative
                };
                list.Add(item);
            }
            return list;
        }
    }
}