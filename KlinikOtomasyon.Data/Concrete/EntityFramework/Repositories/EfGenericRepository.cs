using System.Linq.Expressions;
using KlinikOtomasyon.Data.Concrete.EntityFramework.Contexts;
using KlinikOtomasyon.Shared.Data.Abstract;
using KlinikOtomasyon.Shared.Entities.Abstract;
using KlinikOtomasyon.Shared.Utilities.Abstract;
using KlinikOtomasyon.Shared.Utilities.ComplexTypes;
using KlinikOtomasyon.Shared.Utilities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Repositories
{
public class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly KlinikOtomasyonContext _context;
        
        public EfGenericRepository(KlinikOtomasyonContext context)
        {
            _context = context;
        }

        public async Task<IResult> AddAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                try
                {
                    await _context.SaveChangesAsync();
                    return new Result(ResultStatus.SUCCESS, "başarıyla eklendi");
                }
                catch (System.Exception exception)
                {
                    
                    return new Result(ResultStatus.ERROR, "eklenirken Save() aşamasında hata ile karşılaşıldı", exception);
                }
            }
            catch (System.Exception exception)
            {
                
                return new Result(ResultStatus.ERROR, "eklenirken Set<> aşamasında bir hata ile karşılaşıldı", exception);
            }
        }

        public async Task<IResult> UpdateAsync(TEntity entity)
        {
            try
            {
                await Task.Run(() => _context.Set<TEntity>().Update(entity));
                try
                {
                    await _context.SaveChangesAsync();
                    return new Result(ResultStatus.SUCCESS, "başarıyla güncellendi");
                }
                catch (System.Exception exception)
                {
                    return new Result(ResultStatus.ERROR, "güncellenirken Save() aşamasında hata ile karşılaşıldı", exception);
                }
            }
            catch (System.Exception exception)
            {
                
                return new Result(ResultStatus.ERROR, "güncellenirken Set<> aşamasında bir hata ile karşılaşıldı", exception);
            }
        }

        public async Task<IResult> DeleteAsync(TEntity entity)
        {
            try
            {
                await Task.Run(() => _context.Remove(entity));
                try
                {
                    await _context.SaveChangesAsync();
                    return new Result(ResultStatus.SUCCESS, "başarıyla veritabanından silindi");
                }
                catch (System.Exception exception)
                {
                    return new Result(ResultStatus.ERROR, "veritabanından silinirken Save() aşamasında hata ile karşılaşıldı", exception);
                }
            }
            catch (System.Exception exception)
            {
                
                return new Result(ResultStatus.ERROR, "veritabanından silinirken Set<> aşamasında bir hata ile karşılaşıldı", exception);
            }
        }

        public async Task<DataResult<TEntity>> GetByIdAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                IQueryable<TEntity> query = _context.Set<TEntity>();
                query = query.Where(predicate);

                if (includeProperties.Any())
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                var data = await query.SingleOrDefaultAsync();
                if (data == null)
                {
                    return new DataResult<TEntity>(ResultStatus.WARNING, "böyle bir kayıt bulunamadı", new TEntity());
                }
                return new DataResult<TEntity>(ResultStatus.SUCCESS, data);
            }
            catch (System.Exception exception)
            {
                
                return new DataResult<TEntity>(ResultStatus.ERROR, "veri getirilirken Set<> aşamasında bir hata ile karşılaşıldı", new TEntity(), exception);
            }
        }

        public async Task<DataResult<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                IQueryable<TEntity> query = _context.Set<TEntity>();

                if (predicate != null)
                    query = query.Where(predicate);

                if (includeProperties.Any())
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query.Include(includeProperty);
                    }
                }

                var datas = await query.ToListAsync();
                if (datas.Count < 0)
                {
                    return new DataResult<TEntity>(ResultStatus.WARNING, "Böyle bir data bulunamadı!", new List<TEntity>());
                }
                return new DataResult<TEntity>(ResultStatus.SUCCESS, datas);
            }
            catch (System.Exception exception)
            {
                return new DataResult<TEntity>(ResultStatus.ERROR, "Datalar getirilirken bir hatayla karşılaşıldı!", new List<TEntity>(), exception);
            }
        }

        public async Task<DataResult<TEntity>> GetListAsync(IQueryable<TEntity> query)
        {
            try
            {
                var datas = await query.ToListAsync();
                if (datas.Count < 0)
                {
                    return new DataResult<TEntity>(ResultStatus.WARNING, "Böyle bir data bulunamadı!", new List<TEntity>());
                }
                return new DataResult<TEntity>(ResultStatus.SUCCESS, datas);
            }
            catch (System.Exception exception)
            {
                return new DataResult<TEntity>(ResultStatus.ERROR, "Datalar getirilirken bir hatayla karşılaşıldı!", new List<TEntity>(), exception);
            }
        }

        public IQueryable<TEntity> SetQuery()
        {
            return _context.Set<TEntity>();
        }
    }
}