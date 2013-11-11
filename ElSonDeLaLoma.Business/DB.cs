using ElSonDeLaLoma.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElSonDeLaLoma.Business
{
    internal class DB : DbContext
    {
        public DB()
            : base("DefaultConnection")
        {

        }

        public DbSet<Promo> Promoes { get; set; }
    }
}
