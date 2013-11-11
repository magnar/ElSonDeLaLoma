using ElSonDeLaLoma.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElSonDeLaLoma.Business
{
    public class PromoesMngr : IDisposable
    {
        DB db = new DB();

        public IQueryable<Promo> GetPromoes()
        {
            return db.Promoes;
        }

        public Promo Find(Guid id)
        {
            return db.Promoes.Find(id);
        }

        public void Save(Promo promo)
        {
            db.Entry(promo).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void New(Promo promo)
        {
            db.Promoes.Add(promo);
            db.SaveChanges();
        }

        public void Delete(Promo promo)
        {
            db.Promoes.Remove(promo);
            db.SaveChanges();      
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
