using Presentation.Data.Context;
using Presentation.Data.Entites;

namespace Presentation.Data.Repositories;

public class GuestAdressRepository(DataContext context) : BaseRepository<GuestAdressEntity>(context), IGuestAdressRepository 
{
}
