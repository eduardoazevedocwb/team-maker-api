using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace team_maker.Models
{
    public interface IBase
    {
        IList<string> GetListColumn();
    }
}