using Microsoft.EntityFrameworkCore;

namespace PO.Infrastructure
{
    public class PirateOdysseyContext(DbContextOptions options) : DbContext(options)
    {
    }
}
