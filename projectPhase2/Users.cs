using System;
using System.Collections.Generic;
using System.Text;

namespace projectPhase2
{
    //Users class to control permissions 
    class Users
    {
        public string username;
        public string password;
        public Permissions permissions;

        public Users(string username, string password, Permissions permissions)
        {
            this.username = username;
            this.password = password;
            this.permissions = permissions;
        }
        public Users()
        {

        }
    }
    enum Permissions
    {
        User, Admin
    }
}
