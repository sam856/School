using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SchoolProject.Data.Entites;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Infrastruture.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Ins_Subject> Ins_Subject { get; set; }
        public DbSet<UserRefreshToken> userRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ins_Subject>().HasKey(x => new { x.SubId, x.InsId });
            modelBuilder.Entity<DepartmetSubject>().HasKey(x => new { x.SubID, x.DID });

            modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.SubID, x.StudID });
            modelBuilder.Entity<Instructor>()
                .HasOne(x => x.Supervisior).WithMany(x => x.Instructors)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
              .HasOne(x => x.Instructor)
              .WithOne(x => x.DepartmentManager)
              .HasForeignKey<Department>(x => x.Manager)
              .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(modelBuilder);
        }


    }
}