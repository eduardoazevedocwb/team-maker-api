using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using team_maker.Models;

namespace team_maker_api.Models
{
    public class Player : Base, IBase
    {
        public string nickname { get; set; }
        public string contact { get; set; }
        public bool male { get; set; }
        public bool female { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int? num { get; set; }
        public string compl { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string posPrim { get; set; }
        public string posSec { get; set; }
        public string qldTecnic { get; set; }
        public string partic { get; set; }
        public string qldGroup { get; set; }
        public DateTime birth { get; set; }
        public IList<string> GetListColumn()
        {
            var list = new List<string>()
            {
                "id","name","nickname","contact","male","female","email","address","num","compl","city","state","postalCode",
                "posPrim","posSec","qldTecnic","partic","qldGroup","birth","ative"
            };
            return list;
        }
        public IList<Player> ConvertDataReader(MySqlDataReader dataReader)
        {
            var list = new List<Player>();
            while (dataReader.Read())
            {
                var id = Convert.ToInt32(dataReader["id"].ToString().Trim());
                var name = dataReader["name"].ToString().Trim();
                var nickname = dataReader["nickname"].ToString().Trim();
                var contact = dataReader["contact"].ToString().Trim();
                var male = dataReader["male"].ToString().Trim() == "0" ? false : true;
                var female = dataReader["female"].ToString().Trim() == "0" ? false : true;
                var email = dataReader["email"].ToString().Trim();
                var address = dataReader["address"].ToString().Trim();
                var num = Convert.ToInt32(dataReader["num"].ToString().Trim());
                var compl = dataReader["compl"].ToString().Trim();
                var city = dataReader["city"].ToString().Trim();
                var state = dataReader["state"].ToString().Trim();
                var postalCode = dataReader["postalCode"].ToString().Trim();
                var posPrim = dataReader["posPrim"].ToString().Trim();
                var posSec = dataReader["posSec"].ToString().Trim();
                var qldTecnic = dataReader["qldTecnic"].ToString().Trim();
                var partic = dataReader["partic"].ToString().Trim();
                var qldGroup = dataReader["qldGroup"].ToString().Trim();
                var birth = string.IsNullOrEmpty(dataReader["birth"].ToString().Trim()) ? 
                            new DateTime() : Convert.ToDateTime(dataReader["birth"].ToString().Trim());
                var ative = dataReader["ative"].ToString().Trim() == "0" ? false : true;


                var item = new Player()
                {
                    id = id,
                    name = name,
                    nickname = nickname,
                    contact = contact,
                    male = male,
                    female = female,
                    email = email,
                    address = address,
                    num = num,
                    compl = compl,
                    city = city,
                    state = state,
                    postalCode = postalCode,
                    posPrim = posPrim,
                    posSec = posSec,
                    qldTecnic = qldTecnic,
                    partic = partic,
                    qldGroup = qldGroup,
                    birth = birth,
                    ative = ative
                };
                list.Add(item);
            }
            return list;
        }
    }
}