using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Session3Tweeter.Models;

namespace Session3Tweeter.Controllers
{
    public class TweetUsersController : Controller
    {


        // GET: TweetUsers
        public ActionResult Index()
        {
            TweetDbContext myDb = new TweetDbContext();
            var myUsers = myDb.TweetUsers.ToList();

                        
            return View(myUsers);
        }

        public ActionResult AddUser(string Name, string Picture)
        {
            TweetDbContext myDb = new TweetDbContext();
            TweetUser newUser = new TweetUser();
            newUser.Name = Name;
            newUser.ProfilePic = Picture;

            myDb.TweetUsers.Add(newUser);
            myDb.SaveChanges();

            return Redirect("/TweetUsers/Index");
        }
    }

}