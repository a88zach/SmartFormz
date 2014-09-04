using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using NodaTime;
using SmartFormz.Business.Configuration;
using SmartFormz.Business.Models.Folder;
using SmartFormz.Business.Models.Form;
using SmartFormz.Business.Models.Form.Interfaces;
using SmartFormz.Business.Models.Security;

namespace SmartFormz.Data.Infrastructure
{
    public class SmartFormzContext : IdentityDbContext<SmartFormzUser>
    {
        private static readonly string DefaultConnectionString = ((SmartFormzConfiguration)ConfigurationManager.GetSection("smartFormzConfiguration")).ConnectionString;

        public SmartFormzContext()
            : this(DefaultConnectionString)
        {
        }
        public SmartFormzContext(string connStr) : base(connStr) { }

        public static SmartFormzContext Create()
        {
            return new SmartFormzContext();
        }


        //Folder
        public DbSet<Folder> Folder { get; set; }
        //Form
        public DbSet<Form> Form { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }

        public DbSet<FormPage> FormPage { get; set; }
        public DbSet<PageQuestion> PageQuestion { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }

        public override int SaveChanges()
        {

            foreach (ObjectStateEntry entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                var added = entry.Entity as IGenerateDates;
                if (added != null && entry.State == EntityState.Added)
                {
                    added.CreatedDate = SystemClock.Instance.Now.ToDateTimeUtc();
                    added.LastUpdatedDate = SystemClock.Instance.Now.ToDateTimeUtc();
                }
                else if (added != null && entry.State == EntityState.Modified)
                {
                    added.LastUpdatedDate = SystemClock.Instance.Now.ToDateTimeUtc();
                }

            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {

            foreach (ObjectStateEntry entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                var added = entry.Entity as IGenerateDates;
                if (added != null && entry.State == EntityState.Added)
                {
                    added.CreatedDate = SystemClock.Instance.Now.ToDateTimeUtc();
                    added.LastUpdatedDate = SystemClock.Instance.Now.ToDateTimeUtc();
                }
                else if (added != null && entry.State == EntityState.Modified)
                {
                    added.LastUpdatedDate = SystemClock.Instance.Now.ToDateTimeUtc();
                }

            }

            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<SmartFormzUser>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");

        }
    }
}
