﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using App.BLL;

namespace App.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
      
        public BaseController()
        {
            
        }
    }
}