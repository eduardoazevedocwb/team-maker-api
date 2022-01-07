using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using team_maker_api.DataBase;
using team_maker_api.Models;

namespace team_maker.Controllers
{
    public class TeamsController : ApiController
    {
        // GET: api/Teams
        public IEnumerable<Team> Get()
        {
            IList<Team> listTeam = new List<Team>();
            var msg = "";
            var column = "Team";
            var listCol = new Team().GetListColumn();
            DBMySql DBTeam = new DBMySql();
            var listReturn = DBTeam.Get(column, listCol, ref msg);
            return listReturn != null ? listReturn.Cast<Team>().ToList() : null;
        }

        // GET: api/Teams/5
        public Team Get(int id)
        {
            var msg = "";
            var column = "Team";
            var listCol = new Team().GetListColumn();
            DBMySql DBTeam = new DBMySql();
            var item = DBTeam.GetById(column, listCol, id, ref msg);
            return item != null ? (Team)item : null;
        }

        // POST: api/Teams
        public void Post([FromBody] Team item)
        {
            var msg = "";
            var listCol = new Team().GetListColumn();
            var listValues = new List<object>(){
                    item.id,item.name,item.captainName,item.ative
                };
            DBMySql DBTeam = new DBMySql();
            DBTeam.Set("Team", listCol, listValues, ref msg);
        }

        // PUT: api/Teams/5
        public void Put(Team item)
        {
            var msg = "";
            var listCol = new Team().GetListColumn();
            var listValues = new List<object>(){
                    item.id,item.name,item.captainName,item.ative
                };
            DBMySql DBTeam = new DBMySql();
            DBTeam.Set("Team", listCol, listValues, ref msg);
        }

        // DELETE: api/Teams/5
        public void Delete(int id)
        {
            var msg = "";
            var listCol = new Team().GetListColumn();
            DBMySql DBTeam = new DBMySql();
            DBTeam.Delete("Team", listCol, id, ref msg);
        }
    }
}
