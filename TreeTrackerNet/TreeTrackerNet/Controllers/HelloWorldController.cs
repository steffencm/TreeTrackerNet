using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreeTrackerNet.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "This is my <b>default </b> action";
        }

        // GET HelloWorld/Welcome
        public string Welcome(string name, int num_times=1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + " Num times = " + num_times);
        }
        // GET HelloWorld/IdCheck
        public string IdCheck(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + " Id equals " + ID); 
        }
    }
}