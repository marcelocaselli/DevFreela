using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Skill>(x =>
                {
                    x.HasKey(x => x.Id);
                });

            builder
                .Entity<UserSkill>(x =>
                {
                    x.HasKey(x => x.Id);

                    x.HasOne(x => x.Skill)
                        .WithMany(x => x.UserSkills)
                        .HasForeignKey(x => x.IdSkill)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<ProjectComment>(x =>
                {
                    x.HasKey(x => x.Id);

                    x.HasOne(x => x.Project)
                       .WithMany(x => x.Comments)
                       .HasForeignKey(x => x.IdProject)
                       .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(x => x.User)
                        .WithMany(x => x.Comments)
                        .HasForeignKey (x => x.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<User>(x =>
                {
                    x.HasKey(x => x.Id);

                    x.HasMany(x => x.Skills)
                        .WithOne(x => x.User)
                        .HasForeignKey(x => x.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<Project>(x =>
                {
                    x.HasKey(x => x.Id);

                    x.HasOne(x => x.Freelancer)
                    .WithMany(x => x.FreelaceProjects)
                    .HasForeignKey(x => x.IdFreelancer)
                    .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(x => x.Client)
                        .WithMany(x => x.OwnedProjects)
                        .HasForeignKey(x => x.IdClient)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}
