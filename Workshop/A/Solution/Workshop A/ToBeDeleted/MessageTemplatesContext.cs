using Microsoft.EntityFrameworkCore;
using Wincubate.WorkshopA.Data;

namespace Data.EF
{
    public class MessageTemplatesContext : DbContext
    {
        public DbSet<MessageTemplate> MessageTemplates { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=89076_WorkshopA;Trusted_Connection=True;");
        }
    }
}
