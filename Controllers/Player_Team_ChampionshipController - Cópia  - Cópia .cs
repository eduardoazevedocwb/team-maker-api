using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using team_maker.Models;
using team_maker_api.DataBase;

namespace Player_Team_Championship_maker.Controllers
{
    public class Player_Team_ChampionshipController : ApiController
    {
        // GET: api/Player_Team_Championship
        public IEnumerable<Player_Team_Championship> Get()
        {
            IList<Player_Team_Championship> listPlayer_Team_Championship = new List<Player_Team_Championship>();
            var msg = "";
            var column = "Player_Team_Championship";
            var listCol = new Player_Team_Championship().GetListColumn();
            DBMySql DBPlayer_Team_Championship = new DBMySql();
            var listReturn = DBPlayer_Team_Championship.Get(column, listCol, ref msg);
            return listReturn != null ? listReturn.Cast<Player_Team_Championship>().ToList() : null;
        }

        // GET: api/Player_Team_Championship/5
        public Player_Team_Championship Get(int id)
        {
            var msg = "";
            var column = "Player_Team_Championship";
            var listCol = new Player_Team_Championship().GetListColumn();
            DBMySql DBPlayer_Team_Championship = new DBMySql();
            var item = DBPlayer_Team_Championship.GetById(column, listCol, id, ref msg);
            return item != null ? (Player_Team_Championship)item : null;
        }

        // POST: api/Player_Team_Championship
        public void Post([FromBody] Player_Team_Championship item)
        {
            var msg = "";
            var listCol = new Player_Team_Championship().GetListColumn();
            var listValues = new List<object>(){
                    item.id,item.name,item.idPlayer,item.idTeam,item.idChampionship,item.ative
                };
            DBMySql DBPlayer_Team_Championship = new DBMySql();
            DBPlayer_Team_Championship.Set("Player_Team_Championship", listCol, listValues, ref msg);
        }

        // PUT: api/Player_Team_Championship/5
        public void Put(Player_Team_Championship item)
        {
            var msg = "";
            var listCol = new Player_Team_Championship().GetListColumn();
            var listValues = new List<object>(){
                   item.id,item.name,item.idPlayer,item.idTeam,item.idChampionship,item.ative
                };
            DBMySql DBPlayer_Team_Championship = new DBMySql();
            DBPlayer_Team_Championship.Set("Player_Team_Championship", listCol, listValues, ref msg);
        }

        // DELETE: api/Player_Team_Championship/5
        public void Delete(int id)
        {
            var msg = "";
            var listCol = new Player_Team_Championship().GetListColumn();
            DBMySql DBPlayer_Team_Championship = new DBMySql();
            DBPlayer_Team_Championship.Delete("Player_Team_Championship", listCol, id, ref msg);
        }
    }
}
