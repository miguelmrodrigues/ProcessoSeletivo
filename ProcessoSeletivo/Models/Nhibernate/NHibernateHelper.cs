using NHibernate;
using NHibernate.Cfg;
using System.Web;

namespace ProcessoSeletivo.Models.Nhibernate
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;        

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static IStatelessSession OpenStatelessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = CreateConfiguration();
                }
                return _configuration;
            }
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\hibernate.cfg.xml");
            configuration.Configure(configurationPath);

            var categoryConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\Domain\Mapping\Category.hbm.xml");
            var productConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\Domain\Mapping\Product.hbm.xml");

            configuration.AddFile(categoryConfigurationFile);
            configuration.AddFile(productConfigurationFile);

            return configuration;
        }     
    }
}