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
    public class PlayersController : ApiController
    {
        // GET: api/Players
        public IEnumerable<Player> Get()
        {
            IList<Player> listPlayer = new List<Player>();
            var msg = "";
            var column = "Player";
            var listCol = new Player().GetListColumn();
            DBMySql DBPlayer = new DBMySql();
            var listReturn = DBPlayer.Get(column, listCol, ref msg);
            return listReturn != null ? listReturn.Cast<Player>().ToList() : null;
        }

        // GET: api/Players/5
        public Player Get(int id)
        {
            var msg = "";
            var column = "Player";
            var listCol = new Player().GetListColumn();
            DBMySql DBPlayer = new DBMySql();
            var item = DBPlayer.GetById(column, listCol, id, ref msg);
            return item != null ? (Player)item : null;
        }

        // POST: api/Players
        public void Post([FromBody]Player player)
        {
            var msg = "";
            var listCol = new Player().GetListColumn();
            var listValues = new List<object>(){
                    player.id,player.name,player.nickname,player.contact,player.male,player.female,
                    player.email,player.address,player.num,player.compl,player.city,player.state,player.postalCode,
                    player.posPrim,player.posSec,player.qldTecnic,player.partic,player.qldGroup,player.birth,player.ative
                };
            DBMySql DBPlayer = new DBMySql();
            DBPlayer.Set("Player", listCol, listValues, ref msg);
        }

        // PUT: api/Players/5
        public void Put(Player player)
        {
            var msg = "";
            var listCol = new Player().GetListColumn();
            var listValues = new List<object>(){
                    player.id,player.name,player.nickname,player.contact,player.male,player.female,
                    player.email,player.address,player.num,player.compl,player.city,player.state,player.postalCode,
                    player.posPrim,player.posSec,player.qldTecnic,player.partic,player.qldGroup,player.birth,player.ative
                };
            DBMySql DBPlayer = new DBMySql();
            DBPlayer.Set("Player", listCol, listValues, ref msg);
        }

        // DELETE: api/Players/5
        public void Delete(int id)
        {
            var msg = "";
            var listCol = new Player().GetListColumn();
            DBMySql DBPlayer = new DBMySql();
            DBPlayer.Delete("Player", listCol, id, ref msg);
        }
    }
}
