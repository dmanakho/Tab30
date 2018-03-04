using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tab30.Models;

namespace Tab30.DAL
{
    public class Tab30Initializer : CreateDatabaseIfNotExists<TabDBContext>
    {
        protected override void Seed(TabDBContext context)
        {
        }
        
    }
}