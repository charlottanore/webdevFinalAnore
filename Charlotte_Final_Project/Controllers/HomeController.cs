using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charlotte_Final_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult input()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String firstName = fc["FirstName"];
            String lastName = fc["LastName"];
            String email = fc["Email"];
            String diko = fc["Password"];

            user use = new user();
            use.firstname = firstName;
            use.lastname = lastName;
            use.email = email;
            use.password = diko;
            use.roleID = 1;

            friendsEntities fe = new friendsEntities();
            fe.users.Add(use);
            fe.SaveChanges();

            //insert the code that will save these information to the DB

            return RedirectToAction("Input");
        }

        public ActionResult UserUpdate()
        {
            friendsEntities rdbe = new friendsEntities();
            user u = (from a in rdbe.users
                      where a.userId == 1
                      select a).FirstOrDefault();
            u.firstname = "Anore";
            u.lastname = "Charlotte";
            u.email = "Roselle@gmail.com";
            u.password = "guapa kaayo";
            u.roleID = 1;
            rdbe.SaveChanges();

            return View();
        }

        public ActionResult UserDelete()
        {
            friendsEntities rdbe = new friendsEntities();
            user u = (from a in rdbe.users
                      where a.userId == 2
                      select a).FirstOrDefault();
            rdbe.users.Remove(u);
            rdbe.SaveChanges();

            return View();
        }

        public ActionResult ShowUser()
        {
            friendsEntities fe = new friendsEntities();
            var userList = (from a in fe.users
                            select a).ToList();

            ViewData["UserList"] = userList;
            return View();
        }


    }
}