using System.Web.Routing;

using Microsoft.AspNet.FriendlyUrls;

namespace coding_lms {
	public static class RouteConfig {
		public static void RegisterRoutes ( RouteCollection routes ) {
			// Handle non-Friendly URLs; redirect old URLs with file-ext to non-extension urls
			var settings = new FriendlyUrlSettings();
			settings.AutoRedirectMode = RedirectMode.Permanent;
			routes.EnableFriendlyUrls ( settings );

		}
	}
}
