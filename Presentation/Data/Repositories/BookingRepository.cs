using Microsoft.EntityFrameworkCore;
using Presentation.Data.Context;
using Presentation.Data.Entites;
using Presentation.Models;
using System.Linq.Expressions;

namespace Presentation.Data.Repositories;

public class BookingRepository(DataContext context) : BaseRepository<BookingEntity>(context), IBookingRepository
{

    public override async Task<RepositoryResult<IEnumerable<BookingEntity>>> GetAll()
    {
        try
        {
            var entities = await _dbSet
                .Include(x => x.BookingGuest)
                .ThenInclude(x => x!.GuestAddress)
                .ToListAsync();


            return new RepositoryResult<IEnumerable<BookingEntity>>
            {
                Succeeded = true,
                Result = entities
            };

        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<BookingEntity>>
            {
                Succeeded = false,
                Error = $"Error occurred: {ex.Message}"
            };

        }
    }
    public override async Task<RepositoryResult<BookingEntity?>> GetAsync(Expression<Func<BookingEntity, bool>> predicate)
    {
        try
        {
            var entity = await _dbSet
                .Include(x => x.BookingGuest)
                .ThenInclude(x => x!.GuestAddress)
                .FirstOrDefaultAsync(predicate);

            if (entity == null)
            {
                return new RepositoryResult<BookingEntity?>
                {
                    Succeeded = false,
                    StatusCode = 404,
                    Error = $"{nameof(BookingEntity)} not found"
                };
            }
            return new RepositoryResult<BookingEntity?>
            {
                Succeeded = true,
                Result = entity
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<BookingEntity?>
            {
                Succeeded = false,
                Error = $"Error occurred: {ex.Message}"
            };

        }
    }

}
