using Microsoft.EntityFrameworkCore;
using PO.Domain.Repositories.Base;

namespace PO.Infrastructure
{
    public class PirateOdysseyContext(DbContextOptions options) : DbContext(options), IUnitOfWork
    {

    }
}
