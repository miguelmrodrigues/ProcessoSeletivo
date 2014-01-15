using NHibernate;
using ProcessoSeletivo.Models.Nhibernate;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProcessoSeletivo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public static ISession CurrentSession
        {
            get { return (ISession)HttpContext.Current.Items["Nhibernate.Session"]; }
            set { HttpContext.Current.Items["Nhibernate.Session"] = value; }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (CurrentSession != null)
                CurrentSession.Dispose();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CurrentSession = NHibernateHelper.SessionFactory.OpenSession();
        }

    }
}
