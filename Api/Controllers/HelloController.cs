﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class HelloController : Controller
    {
       
        public string Index()
        {
            return "Hello giraffe";
        }

    }
}
