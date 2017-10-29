using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;



namespace Data.Model
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public DbSet<User> Userss { get; set; }
        public DbSet<UsersRole> UsersRoles { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Data.Model.UserDetailsDTO> UserDetailsDTOes { get; set; }
    }
}
