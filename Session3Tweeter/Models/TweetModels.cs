using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(140)]
        public string Text { get; set; }
        public bool visible { get; set; }
        public DateTime Date { get; set; }

        public virtual TweetUser TweetUser { get; set; }

    }

    public class Follower
    {
        public int id { get; set; }

        public virtual TweetUser TweetUser { get; set; }
        public virtual TweetUser Followee { get; set; }
    }

    // Database
    public class TweetDbContext : DbContext
    {
        // Tables
        public DbSet<TweetUser> TweetUsers { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Follower> Followers { get; set; }
    }


}