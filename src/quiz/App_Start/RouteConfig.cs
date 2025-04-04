using System.Web.Routing;

using Microsoft.AspNet.FriendlyUrls;

namespace quiz {
	public static class RouteConfig {
		public static void RegisterRoutes ( RouteCollection routes ) {

			// Test Page Route
			routes.MapPageRoute ( routeName: ""
				, routeUrl: "test/{testname}" , physicalFile: "~/test.aspx" );
			
			//Landing Page Route
            routes.MapPageRoute(
				"QuizLanding", "{termid}-{crn}/{shortname}", "~/LandingPage.aspx");

			// Define the custom route for InProgress Page
			RouteTable.Routes.MapPageRoute(
				"InProgressRoute","{termid}-{crn}/{shortname}/in-progress", "~/In_Progress.aspx");

            var settings = new FriendlyUrlSettings();
			settings.AutoRedirectMode = RedirectMode.Permanent;
			routes.EnableFriendlyUrls ( settings );

		}
	}
}
