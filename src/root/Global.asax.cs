using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace coding_lms {
	public class Global : HttpApplication {
		void Application_Start ( object sender , EventArgs e ) {
			// Code that runs on application startup
			GlobalConfiguration.Configure ( WebApiConfig.Register );
			RouteConfig.RegisterRoutes ( RouteTable.Routes );
			BundleConfig.RegisterBundles ( BundleTable.Bundles );
		}
	}
}