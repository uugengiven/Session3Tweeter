using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Session3Tweeter.Models;

namespace Session3Tweeter.Controllers
{
    public class TweetsController : Controller
    {
        // GET: Tweets
        public ActionResult Index()
        {
            TweetDbContext db = new TweetDbContext();
            var myList = db.Tweets.ToList();

            ViewBag.ListOfUsers = db.TweetUsers.ToList();
            return View(myList);
        }

        public ActionResult AddTweet(string Text, int userID)
        {
            TweetDbContext db = new TweetDbContext();
            Tweet tempTweet = new Tweet();
            tempTweet.Text = Text;
            tempTweet.Date = DateTime.Now;
            tempTweet.visible = true;
            TweetUser tempUser = db.TweetUsers.Find(userID);
            tempTweet.TweetUser = tempUser;

            db.Tweets.Add(tempTweet);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult UndeleteAll(int id)
        {
            TweetDbContext db = new TweetDbContext();
            // TweetUser currentUser
            var currentUser = db.TweetUsers.Find(id);
            // List<Tweet> userTweets
            var userTweets = currentUser.Tweets.Where(x => x.visible == false).ToList();

            foreach(Tweet tweet in userTweets)
            {
                tweet.visible = true;
            }
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Delete(int id)
        {
            TweetDbContext db = new TweetDbContext();
            var tweet = db.Tweets.Find(id);
            tweet.visible = false;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}