using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repository.Interface;

namespace DAL.Repository.Implementation
{
    public class VisitorRepository: IVisitorRepository
    {
        private KppContext db;

        public VisitorRepository()
        {
            this.db = new KppContext();
        }

        public IEnumerable<Visitor> GetVisitorsList()
        {
            return db.Visitors;
        }

        public Visitor GetVisitor(int id)
        {
            return db.Visitors.Find(id);
        }

        public void Create(Visitor item)
        {
            db.Visitors.Add(item);
        }

        public void Update(Visitor item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Visitor book = db.Visitors.Find(id);
            if (book != null)
                db.Visitors.Remove(book);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
