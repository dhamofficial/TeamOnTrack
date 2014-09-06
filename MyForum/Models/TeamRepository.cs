using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using MyForum.Entities;
using System.Text;

namespace MyForum.Models
{
    public class TeamRepository
    {
        public IEnumerable<Team> GetTeams()
        {
            IEnumerable<Team> list;

            using (var dbContext = new DBContext())
            {
                list = dbContext.Connection.Query<Team>(@" select UID,[TeamName] from Teams where active = 1", new { });
            }

            return list;
        }
         
    }
}