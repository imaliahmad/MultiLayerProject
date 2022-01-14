using BOL_BusinessObjectLayer_;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_DataAccessLayer_
{
    public interface IProductDb
    {
        //100% abstractions
        IEnumerable<Products> GetAll();
        Products GetById(int id);
        bool Insert(Products obj);
        bool Update(Products obj);
        bool Delete(int id);
    }
    public class ProductDb : IProductDb
    {
        //standard --> pattern (repository)

        private AppDbContext context;

        public ProductDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Products> GetAll()
        {
            //add, update,remove
            return context.Products;
        }
        public Products GetById(int id)
        {
            var obj = context.Products.Find(id);
            return obj;
            //return context.Products.Find(id);
        }

        public bool Insert(Products obj)
        {
            context.Products.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Products obj)
        {
            context.Products.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Products.Find(id);
            context.Products.Remove(obj);
            context.SaveChanges();

            return true;
        }


    }
}
