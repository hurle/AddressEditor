using Core.Application.Interfaces;
using Core.Domain.Entities;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public AddressRepository(IDbContextFactory<ApplicationDbContext> contextFactory) 
        {
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable<Address>> GetAllAsync() 
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var addresses = await context.Address.AsNoTracking().ToListAsync();
                return addresses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }
        public async Task UpdateAsync(Address address)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Entry(address).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
