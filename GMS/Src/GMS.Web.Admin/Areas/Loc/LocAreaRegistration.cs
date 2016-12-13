using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Loc
{
    public class LocAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Loc";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Loc_default",
                "Loc/{controller}/{action}/{id}",
                new { action = "Default", id = UrlParameter.Optional }
            );
        }
    }
}
