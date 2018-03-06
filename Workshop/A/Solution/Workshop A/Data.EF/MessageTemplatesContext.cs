using Microsoft.EntityFrameworkCore;

namespace Wincubate.WorkshopA.Data.EF
{
    /// <summary>
    /// Entity Framework context class for accessing
    /// <see cref="MessageTemplate"/> instances in the underlying
    /// database.
    /// </summary>
    public class MessageTemplatesContext : DbContext
    {
        /// <summary>
        /// Provides IQueryable-access to the <see cref="MessageTemplate"/>
        /// instances in the underlying table.
        /// </summary>
        public DbSet<MessageTemplate> MessageTemplates { get; set; }

        /// <summary>
        /// Configures Entity Framework to use the SQL Express database.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=89076_WorkshopA;Trusted_Connection=True;");
        }
    }
}