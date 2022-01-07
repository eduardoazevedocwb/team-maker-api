using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using team_maker.Models;
using team_maker_api.DataBase;

namespace Team_Player_maker.Controllers
{
    public class Team_PlayerController : ApiController
    {
        // GET: api/Team_Player
        public IEnumerable<Team_Player> Get()
        {
            IList<Team_Player> listTeam_Player = new List<Team_Player>();
            var msg = "";
            var column = "Team_Player";
            var listCol = new Team_Player().GetListColumn();
            DBMySql DBTeam_Player = new DBMySql();
            var listReturn = DBTeam_Player.Get(column, listCol, ref msg);
            return listReturn != null ? listReturn.Cast<Team_Player>().ToList() : null;
        }

        // GET: api/Team_Player/5
        public Team_Player Get(int id)
        {
            var msg = "";
            var column = "Team_Player";
            var listCol = new Team_Player().GetListColumn();
            DBMySql DBTeam_Player = new DBMySql();
            var item = DBTeam_Player.GetById(column, listCol, id, ref msg);
            return item != null ? (Team_Player)item : null;
        }

        // POST: api/Team_Player
        public void Post([FromBody] Team_Player item)
        {
            var msg = "";
            var listCol = new Team_Player().GetListColumn();
            var listValues = new List<object>(){
                    item.id,item.name,item.idPlayer,item.idTeam,item.ative
                };
            DBMySql DBTeam_Player = new DBMySql();
            DBTeam_Player.Set("Team_Player", listCol, listValues, ref msg);
        }

        // PUT: api/Team_Player/5
        public void Put(Team_Player item)
        {
            var msg = "";
            var listCol = new Team_Player().GetListColumn();
            var listValues = new List<object>(){
                   item.id,item.name,item.idPlayer,item.idTeam,item.ative
                };
            DBMySql DBTeam_Player = new DBMySql();
            DBTeam_Player.Set("Team_Player", listCol, listValues, ref msg);
        }

        // DELETE: api/Team_Player/5
        public void Delete(int id)
        {
            var msg = "";
            var listCol = new Team_Player().GetListColumn();
            DBMySql DBTeam_Player = new DBMySql();
            DBTeam_Player.Delete("Team_Player", listCol, id, ref msg);
        }
    }
}
