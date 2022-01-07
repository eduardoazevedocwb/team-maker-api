using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using team_maker_api.DataBase;
using team_maker_api.Models;

namespace Championship_maker.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ChampionshipsController : ApiController
    {
        // GET: api/Championships
        [HttpGet]
        public IEnumerable<Championship> Get()
        {
            IList<Championship> listChampionship = new List<Championship>();
            var msg = "";
            var column = "Championship";
            var listCol = new Championship().GetListColumn();
            DBMySql DBChampionship = new DBMySql();
            var listReturn = DBChampionship.Get(column, listCol, ref msg);
            return listReturn != null ? listReturn.Cast<Championship>().ToList() : null;
        }

        // GET: api/Championships/5
        [HttpGet]
        public Championship Get(int id)
        {
            var msg = "";
            var column = "Championship";
            var listCol = new Championship().GetListColumn();
            DBMySql DBChampionship = new DBMySql();
            var item = DBChampionship.GetById(column, listCol, id, ref msg);
            return item != null ? (Championship)item : null;
        }

        // POST: api/Championships
        [HttpPost]
        public void Post(Championship item)
        {
            var msg = "";
            var listCol = new Championship().GetListColumn();
            var listValues = new List<object>(){
                    item.id,item.name,item.initialDate, item.finalDate,
                    item.maxTeams,item.minTeams,item.place,item.male,
                    item.female,item.minAge,item.maxAge,item.ative
                };
            DBMySql DBChampionship = new DBMySql();
            DBChampionship.Set("Championship", listCol, listValues, ref msg);
        }

        // PUT: api/Championships/5
        [HttpPut]
        public void Put(Championship item)
        {
            var msg = "";
            var listCol = new Championship().GetListColumn();
            var listValues = new List<object>(){
                    item.id,item.name,item.initialDate, item.finalDate,
                    item.maxTeams,item.minTeams,item.place,item.male,
                    item.female,item.minAge,item.maxAge,item.ative
                };
            DBMySql DBChampionship = new DBMySql();
            DBChampionship.Set("Championship", listCol, listValues, ref msg);
        }

        // DELETE: api/Championships/5
        [HttpDelete]
        public void Delete(int id)
        {
            var msg = "";
            var listCol = new Championship().GetListColumn();
            DBMySql DBChampionship = new DBMySql();
            DBChampionship.Delete("Championship", listCol, id, ref msg);
        }
    }
}
