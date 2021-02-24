using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelListing.DbContexts;
using HotelListing.IRepository;
using HotelListing.Models;

namespace HotelListing.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private  IGenericRepository<Country> _countries;
        private  IGenericRepository<Hotel> _hotels;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
