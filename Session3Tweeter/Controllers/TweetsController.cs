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
            TweetUser tempUser = db.TweetUsers.Find(userID);
            tempTweet.TweetUser = tempUser;

            db.Tweets.Add(tempTweet);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Delete(int id)
        {
            TweetDbContext db = new TweetDbContext();
            var tweet = db.Tweets.Find(id);
            db.Tweets.Remove(tweet);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}