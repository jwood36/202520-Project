using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute ( typeof ( coding_lms.Startup ) )]
namespace coding_lms {
	public partial class Startup {
		public void Configuration ( IAppBuilder app ) {
			ConfigureAuth ( app );
		}
	}
}
