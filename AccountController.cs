using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using The_Pizzatorium.Models;


namespace The_Pizzatorium.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.userAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (OurDbContext db = new OurDbContext())
                    {
                        db.userAccounts.Add(account);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("","{Please check your Database:::")            }

            return View();
        }

        // Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                try
                {
                    var usr = db.userAccounts.Single(u => u.Username == user.Username && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["UserID"] = usr.UserID.ToString();
                        Session["Username"] = usr.Username.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is wrong.");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("","Database cannot be accessed::::::");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}