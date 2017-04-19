using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Session3Tweeter.Models;

namespace Session3Tweeter.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index(int id)
        {
            TweetDbContext db = new TweetDbContext();
            var currentUser = db.TweetUsers.Find(id); 
            // if user @ id is null, go to some other page
            // instead of the profile page - maybe an error?
            if (currentUser == null)
            {
                // go to a 404 page
                return HttpNotFound();
            }

            return View(currentUser);
        }
    }
}