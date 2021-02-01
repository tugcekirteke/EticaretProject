using System.Web.Mvc;

namespace Eticaretproject.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                //buraya controller="default",ekledik admin de ilk default kontroller açılsın diye
                new { controller="default",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}