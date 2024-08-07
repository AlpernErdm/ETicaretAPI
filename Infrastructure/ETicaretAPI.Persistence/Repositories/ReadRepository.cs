using ETicaret.Domain.Common;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context, bool tracking = true)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query=Table.AsQueryable(); //tracking sorgusu oluşturuldu
            if(!tracking)//eğer false dönerse ilişki kes 
                query=query.AsNoTracking();//ilişki kesme=AsNoTracking
            return query;//true ise track etmeye devam et
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {

            var query = Table.Where(method);
            if(!tracking)
                query=query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        //   =>await Table.FirstOrDefaultAsync(p => p.Id==Guid.Parse(id));
        {
            var query=Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

        }
 

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query=query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
    }
}
