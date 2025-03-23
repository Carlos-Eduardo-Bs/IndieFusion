using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieFusionDesk.Models
{
    public class UserSession
    {
        public static int IdUser { get; set; }
        public static string Name { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }


        //change permission
        public static int UserTp { get; set; }

        //token
        public static string Token { get; set; }
    }
}
