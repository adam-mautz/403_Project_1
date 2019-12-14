using _403_Project_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _403_Project_1.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext() : base("MissionContext")
        {
        }

        public DbSet<Users> users { get; set; }
        public DbSet<Missions> missions { get; set; }
        public DbSet<MissionQuestions> missionQuestions { get; set; }

    }
}