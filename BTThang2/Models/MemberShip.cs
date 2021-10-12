using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTThang2.Models
{
    public class UsersModel
    {
        public string usernname { set; get; }
        public string password { set; get; }
        public string email { set; get; }
        public string passwordquestion { set; get; }
        public string passwordanswer { set; get; }
        public bool isapproved { set; get; }
        public  List<string> Roles { set; get; }
    }
    public  class RolesModel
    {
        public string rolename { set; get; }
    }
}