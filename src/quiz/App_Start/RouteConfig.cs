using System.Web.Routing;

using Microsoft.AspNet.FriendlyUrls;

namespace quiz {
	public static class RouteConfig {
		public static void RegisterRoutes ( RouteCollection routes ) {
			
			//Landing Page Route
            routes.MapPageRoute(
				"QuizLanding", "{termid}-{crn}/{shortname}", "~/Default.aspx");

            var settings = new FriendlyUrlSettings();
			settings.AutoRedirectMode = RedirectMode.Permanent;
			routes.EnableFriendlyUrls ( settings );

		}
	}
}
