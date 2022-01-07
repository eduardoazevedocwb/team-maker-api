using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using team_maker.Models;
using team_maker_api.DataBase;

namespace Championship_Team_maker.Controllers
{
    public class Championship_TeamController : ApiController
    {
        // GET: api/Championship_Team
        public IEnumerable<Championship_Team> Get()
        {
            IList<Championship_Team> listChampionship_Team = new List<Championship_Team>();
            var msg = "";
            var column = "Championship_Team";
            var listCol = new Championship_Team().GetListColumn();
            DBMySql DBChampionship_Team = new DBMySql();
            var listReturn = DBChampionship_Team.Get(column, listCol, ref msg);
            return listReturn != null ? listReturn.Cast<Championship_Team>().ToList() : null;
        }

        // GET: api/Championship_Team/5
        public Championship_Team Get(int id)
        {
            var msg = "";
            var column = "Championship_Team";
            var listCol = new Championship_Team().GetListColumn();
            DBMySql DBChampionship_Team = new DBMySql();
            var item = DBChampionship_Team.GetById(column, listCol, id, ref msg);
            return item != null ? (Championship_Team)item : null;
        }

        // POST: api/Championship_Team
        public void Post([FromBody] Championship_Team item)
        {
            var msg = "";
            var listCol = new Championship_Team().GetListColumn();
            var listValues = new List<object>(){
                    item.id,item.name,item.idChampionship,item.idTeam,item.ative
                };
            DBMySql DBChampionship_Team = new DBMySql();
            DBChampionship_Team.Set("Championship_Team", listCol, listValues, ref msg);
        }

        // PUT: api/Championship_Team/5
        public void Put(Championship_Team item)
        {
            var msg = "";
            var listCol = new Championship_Team().GetListColumn();
            var listValues = new List<object>(){
                    item.id,item.name,item.idChampionship,item.idTeam,item.ative
                };
            DBMySql DBChampionship_Team = new DBMySql();
            DBChampionship_Team.Set("Championship_Team", listCol, listValues, ref msg);
        }

        // DELETE: api/Championship_Team/5
        public void Delete(int id)
        {
            var msg = "";
            var listCol = new Championship_Team().GetListColumn();
            DBMySql DBChampionship_Team = new DBMySql();
            DBChampionship_Team.Delete("Championship_Team", listCol, id, ref msg);
        }
    }
}
