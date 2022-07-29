using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repository;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfPersonelRepository : GenericRepository<Personel>, IPersonelRepository
    {
        public EfPersonelRepository(DbContext context) : base(context)
        {
        }
        private EmkaContext EmkaContext
        {
            get { return _context as EmkaContext; }
        }


    }
}
