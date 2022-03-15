using KnockoutDemo.Interface;
using KnockoutDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductListEntities3 ProductDB = new ProductListEntities3();

        public IEnumerable<TblProductList> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return ProductDB.TblProductLists;
        }

        public TblProductList Get(int id)
        {
            // TO DO : Code to find a record in database
            return ProductDB.TblProductLists.Find(id);
        }

        public TblProductList Add(TblProductList item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            try { 
            ProductDB.TblProductLists.Add(item);
            ProductDB.SaveChanges();
            }
           
            
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return item;
        }

        public bool Update(TblProductList item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }



            // TO DO : Code to update record into database
            // TblProductList products = ProductDB.TblProductLists.Find(item);
            var products = ProductDB.TblProductLists.FirstOrDefault(a => a.Id == item.Id);
            products.Name = item.Name;
            products.Category = item.Category;
            products.Price = item.Price;
            ProductDB.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database

            TblProductList products = ProductDB.TblProductLists.Find(id);
            ProductDB.TblProductLists.Remove(products);
            ProductDB.SaveChanges();

            return true;
        }
    }
}