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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db):base(db)
        {
            _db = db;    
        }
      

        public void Update(ShoppingCart obj)
        {
            _db.ShoppingCarts.Update(obj); 
        }
    }
}
