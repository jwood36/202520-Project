using System.Web.Routing;

using Microsoft.AspNet.FriendlyUrls;

namespace quiz {
	public static class RouteConfig {
		public static void RegisterRoutes ( RouteCollection routes ) {
			
			//Landing Page Route
            routes.MapPageRoute(
				"QuizLanding", "{termid}-{crn}/{shortname}", "~/Default.aspx");

			// Define the custom route for InProgress Page
			RouteTable.Routes.MapPageRoute(
				"InProgressRoute","{termid}-{crn}/{shortname}/in-progress", "~/In_Progress.aspx");

            RouteTable.Routes.MapPageRoute(
                "ResultsRoute","{termid}-{crn}/{shortname}/results", "~/Results.aspx" 
            );

            var settings = new FriendlyUrlSettings();
			settings.AutoRedirectMode = RedirectMode.Permanent;
			routes.EnableFriendlyUrls ( settings );

		}
	}
}
