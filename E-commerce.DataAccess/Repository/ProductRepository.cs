using E_commerce.DataAccess.Data;
using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.DataAccess.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
            _db= db;

        }

        public void Update(Product product)
        {
            var objFormDb = _db.Products
                .FirstOrDefault(x => x.Id == product.Id);
            if (objFormDb != null)
            {
                objFormDb.Id = product.Id;
                objFormDb.Title = product.Title;
                objFormDb.Author = product.Author;
                objFormDb.Description = product.Description;
                objFormDb.CategoryId = product.CategoryId;
                objFormDb.ListPrice = product.ListPrice;
                objFormDb.Price = product.Price;
                objFormDb.Price100 = product.Price100;
                objFormDb.Price50 = product.Price50;
                if (objFormDb.ImageUrl != null)
                {
                    objFormDb.ImageUrl = product.ImageUrl;
                }

            }

            _db.Products.Update(objFormDb); 
        }
    }
}
