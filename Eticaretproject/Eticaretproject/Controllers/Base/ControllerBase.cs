using eticaretsitesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eticaretproject
{
    public class AndControllerBase:Controller
    {
        /// <summary>
        /// kULLANICI LOGİN KONTROLÜ
        /// </summary>
        public bool IsLogin { get;private set; }
        /// <summary>
        /// GİRİŞ YAPMIŞ KİŞİNİN ID Sİ
        /// </summary>
        
           public int LoginUserID { get; private set; }
        /// <summary>
        /// LoginUserEntity
        /// </summary>
        public User LoginUserEntity { get; private set; }



        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Session["LoginUserID"] !=null)
            {
                //KULLANICI GİRİŞ YAPMIŞ
                IsLogin = true;
                LoginUserID = (int)requestContext.HttpContext.Session["LoginUserID"];
                LoginUserEntity = (eticaretsitesi.Entity.User)requestContext.HttpContext.Session["LoginUser"];

            }
            //Session["LoginUserID"] 
            //Session["LoginUser"]
            
            //todo:üye giriş işlemleri sonrası değişecek

            base.Initialize(requestContext);
        }
        

    }
}