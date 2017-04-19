using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Session3Tweeter.Models
{
    // Table
    public class TweetUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ProfilePic { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }

    public class Tweet
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public virtual TweetUser TweetUser { get; set; }
    }

    // Database
    public class TweetDbContext : DbContext
    {
        // Tables
        public DbSet<TweetUser> TweetUsers { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
    }
}