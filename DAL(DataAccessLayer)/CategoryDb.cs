using BOL_BusinessObjectLayer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_DataAccessLayer_
{
    // poly morphism --> overloading, overriding
    public interface ICategoryDb
    {
        //100% abstractions
       IEnumerable<Categorys>  GetAll();
       Categorys  GetById(int id);
        bool Insert(Categorys obj);
        bool Update(Categorys obj);
        bool Delete(int id);
    }
    public class CategoryDb:ICategoryDb
    {
        //standard --> pattern (repository)

        private AppDbContext context;

        public CategoryDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Categorys> GetAll()
        {
            //add, update,remove
            return context.Categorys;
        }
        public Categorys GetById(int id)
        {
            var obj = context.Categorys.Find(id);
            return obj;
            //return context.Categorys.Find(id);
        }

        public bool Insert(Categorys obj)
        {
            context.Categorys.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Categorys obj)
        {
            context.Categorys.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Categorys.Find(id);
            context.Categorys.Remove(obj);
            context.SaveChanges();

            return true;
        }


    }
}
