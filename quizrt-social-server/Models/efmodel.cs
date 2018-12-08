using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace quizartsocial_backend.Models
{
    public class SocialContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Follower> Followers { get; set; }


        public SocialContext(DbContextOptions<SocialContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasMany(n => n.posts).WithOne().HasForeignKey(c => c.topicId);
            modelBuilder.Entity<Post>().HasMany(n => n.comments).WithOne().HasForeignKey(c => c.postId);
            
            modelBuilder.Entity<User>().HasMany(n => n.posts).WithOne().HasForeignKey(c => c.userId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasMany(n => n.comments).WithOne().HasForeignKey(c => c.userId).OnDelete(DeleteBehavior.Restrict);
            
            // Configuring Many to Many Relationship between Topic and Users
            modelBuilder.Entity<Follower>().HasKey(t => new { t.TopicId, t.UserId });
            modelBuilder.Entity<Follower>().HasOne(t => t.Topic).WithMany(t => t.followers).HasForeignKey(t => t.TopicId);
            modelBuilder.Entity<Follower>().HasOne(t => t.User).WithMany(t => t.FollowedTopics).HasForeignKey(t => t.UserId);

            // Seeddata
            
            // modelBuilder.Entity<Topic>().HasData(
            //     new { topicId = 1, topicName = "Topic-1" },
            //     new { topicId = 2, topicName = "Topic-2" },
            //     new { topicId = 3, topicName = "Topic-3" },
            //     new { topicId = 4, topicName = "Topic-4" }
            // );
        }
    }
}

// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// {
//    optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=QuizRTSocialDb;Trusted_Connection=True;");
// }