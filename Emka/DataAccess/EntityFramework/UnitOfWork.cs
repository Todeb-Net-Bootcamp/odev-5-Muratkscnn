using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly EmkaContext _context;

        public UnitOfWork(EmkaContext context)
        {
            _context = context;
        }
        private EfPersonelRepository _personelRepository;
        public IPersonelRepository Personels => _personelRepository = _personelRepository ?? new EfPersonelRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

      

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
