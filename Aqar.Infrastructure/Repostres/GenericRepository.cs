using Aqar.Application.Interfaces.IRepository;
using Aqar.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.Repostres
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        //constractor Dbcontext
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {//Save changed database
           await  _context.Set<T>().AddAsync(entity);
           await  _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
            =>await _context.Set<T>().CountAsync();
        

        public async Task DeleteAsync(int id)
        {
           var entity=await _context.Set<T>().FindAsync(id);
            if (entity != null) {
                _context.Set<T>().Remove(entity);
                // save to sql 
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().AsNoTracking().ToListAsync();


        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] Includes)
        { // تحويل الجدول إلى IQueryable لبناء الاستعلام برمجياً قبل إرساله لقاعدة البيانات
            var query = _context.Set<T>().AsQueryable();

            // تطبيق كل دمج (Include) على الاستعلام
            foreach (var item in Includes)
            {
                query = query.Include(item);
            }
            // تنفيذ استعلام SQL وجلب النتائج في قائمة (List)
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entity = await query.FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
            return entity!;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity =await _context.Set<T>().FindAsync(id);
            return entity!;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
