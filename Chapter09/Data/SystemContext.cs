using Microsoft.EntityFrameworkCore;

namespace Chapter9.Data
{
    public class SystemContext: DbContext
    {

        public SystemContext(DbContextOptions<SystemContext> options)
            : base(options)
        {
        }
    }
}
