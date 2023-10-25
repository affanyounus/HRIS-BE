using Microsoft.EntityFrameworkCore;

namespace HRIS.Basic.Data
{
    public class BasicDbContext: DbContext
    {
        public BasicDbContext(DbContextOptions<BasicDbContext> basicDbContextOptions): base(basicDbContextOptions)
        {
                
        }
    }
}
