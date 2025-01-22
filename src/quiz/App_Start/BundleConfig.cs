using System.Web.Optimization;
using System.Web.UI;

namespace quiz {
	public class BundleConfig {
		// For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
		public static void RegisterBundles ( BundleCollection bundles ) {
			RegisterJQueryScriptManager ();

			// Use the Development version of Modernizr to develop with and learn from. Then, when you’re
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need
			bundles.Add ( new ScriptBundle ( "~/bundles/modernizr" ).Include (
							"~/Scripts/modernizr-*" ) );
		}

		public static void RegisterJQueryScriptManager () {
			ScriptManager.ScriptResourceMapping.AddDefinition ( "jquery" ,
				new ScriptResourceDefinition {
					Path = "~/scripts/jquery-3.7.0.min.js" ,
					DebugPath = "~/scripts/jquery-3.7.0.js" ,
					CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.min.js" ,
					CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.js"
				} );
		}
	}
}