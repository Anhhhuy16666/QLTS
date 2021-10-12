using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTThang2.Models;
using System.Web.Security;

namespace BTThang2.Controllers
{
    public class IdentityController : Controller
    {
        [HttpGet]
        public ActionResult Register()// Cho phep hien thi danh sach quyen co the chon
        {
            string[] Roles = System.Web.Security.Roles.GetAllRoles();
            List<String> RolesList = new List<string>();
            foreach (var r in Roles)
            {
                if (HttpContext.User.IsInRole("Admin"))
                    RolesList.Add(r);
                else
                {
                    if(r!="Admin")
                    {
                        RolesList.Add(r);
                    }
                }
            }
            UsersModel usermodel = new UsersModel();
            usermodel.Roles = RolesList;
            return View(usermodel);
        }


        [HttpPost]

        public ActionResult Register(UsersModel usermodel)
        {
            MembershipCreateStatus memCreSta;
            Membership.CreateUser(usermodel.usernname,usermodel.password,usermodel.email,
                usermodel.passwordquestion,usermodel.passwordanswer,usermodel.isapproved,out memCreSta);
            if(memCreSta==MembershipCreateStatus.Success)
            {
                Roles.AddUsersToRole(new[] { usermodel.usernname }, usermodel.Roles[0]);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        // GET: Identity
        public ActionResult Index()
        {
            return View();
        }
    }
}