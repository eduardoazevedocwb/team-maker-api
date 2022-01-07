using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using team_maker.Models;

namespace team_maker_api.Models
{
    public class Team : Base, IBase
    {
        public string captainName { get; set; }
        public IList<string> GetListColumn()
        {
            var list = new List<string>()
            {
                "id","name","captainName","ative"
            };
            return list;
        }
        public IList<Team> ConvertDataReader(MySqlDataReader dataReader)
        {
            var list = new List<Team>();
            while (dataReader.Read())
            {
                var id = Convert.ToInt32(dataReader["id"].ToString().Trim());
                var name = dataReader["name"].ToString().Trim();
                var captainName = dataReader["captainName"].ToString().Trim();
                var ative = dataReader["ative"].ToString().Trim() == "0" ? false : true;

                var item = new Team()
                {
                    id = id,
                    name = name,
                    captainName = captainName,
                    ative = ative
                };
                list.Add(item);
            }
            return list;
        }
    }
}