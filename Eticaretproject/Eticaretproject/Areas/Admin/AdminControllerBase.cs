﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eticaretproject.Areas.Admin
{
    public class AdminControllerBase:Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            var IsLogin = false;
            if (requestContext.HttpContext.Session["AdminLoginUser"]==null)
            {
                //admin girişi yapılmamış
                requestContext.HttpContext.Response.Redirect("/Admin/AdminLogin");
              
            }
            else
            {
                //sorun yok sayfayı çalıştır.
                base.Initialize(requestContext);
            }




           
        }



    }
}