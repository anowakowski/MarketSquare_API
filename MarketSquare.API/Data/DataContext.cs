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

    }
}