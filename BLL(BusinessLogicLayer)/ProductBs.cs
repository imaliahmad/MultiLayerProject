using BOL_BusinessObjectLayer_;
using DAL_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_BusinessLogicLayer_
{
    public interface IProductBs
    {
        IEnumerable<Products> GetAll();
        Products GetById(int id);
        bool Insert(Products obj);
        bool Update(Products obj);
        bool Delete(int id);
    }
    public class ProductBs : IProductBs
    {
        private readonly IProductDb objDb;
        public ProductBs(IProductDb _objDb)
        {
            objDb = _objDb;
        }

        public IEnumerable<Products> GetAll()
        {
            return objDb.GetAll();
        }
        public Products GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Products obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Products obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
