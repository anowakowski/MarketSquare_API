using MarketSquare.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketSquare.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<UserNotice> UserNotices { get; set; }
        public DbSet<NoticeTag> NoticeTags { get; set; }
        public DbSet<UserUserSubscription> SubscribedUsers { get; set; }
        public DbSet<UserTagSubscription> SubscribedTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoticeTag>()
                .HasKey(nt => new { nt.NoticeId, nt.TagId });  
            modelBuilder.Entity<NoticeTag>()
                .HasOne(nt => nt.Notice)
                .WithMany(n => n.NoticeTags)
                .HasForeignKey(nt => nt.NoticeId);  
            modelBuilder.Entity<NoticeTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NoticeTags)
                .HasForeignKey(nt => nt.TagId);
        }
    }
}