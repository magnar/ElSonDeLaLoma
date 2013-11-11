using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElSonDeLaLoma.Domain
{
    public class Promo
    {
        public Promo()
        {
            var now = DateTime.Now;

            ID = Guid.NewGuid();
            Name = "New Promo";
            Description = "Desc";
            Email = "owner@example.com";
            Tags = new List<String>();
            LatLong = "0.0,0.0";
            ImageURL = "about:blank";
            StartDate = DateTime.Now;
            EndDate = now;
            DateCreated = now;
            CreatedBy = "SYSTEM";
            LastEditDate = now;
            LastEditBy = "SYSTEM";
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public List<string> Tags { get; set; }
        public string LatLong { get; set; }
        public string ImageURL { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string LastEditBy { get; set; }

        public void Validate()
        {
            if (StartDate > EndDate)
                throw new Exception("Las fechas de la promo están mal.");
        }

    }
}
