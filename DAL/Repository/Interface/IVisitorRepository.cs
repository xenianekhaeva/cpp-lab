using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repository.Interface
{
    public interface IVisitorRepository
    {
        IEnumerable<Visitor> GetVisitorsList(); // получение всех объектов
        Visitor GetVisitor(int id); // получение одного объекта по id
        void Create(Visitor item); // создание объекта
        void Update(Visitor item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
