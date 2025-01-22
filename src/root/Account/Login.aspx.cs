using System;
using System.Web;
using System.Web.UI;

using Microsoft.AspNet.Identity.Owin;

namespace coding_lms.Account {
	public partial class Login : Page {
		protected void Page_Load ( object sender , EventArgs e ) {
			RegisterHyperLink.NavigateUrl = "Register";
			// Enable this once you have account confirmation enabled for password reset functionality
			//ForgotPasswordHyperLink.NavigateUrl = "Forgot";
			OpenAuthLogin.ReturnUrl = Request.QueryString [ "ReturnUrl" ];
			var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
			if ( !String.IsNullOrEmpty ( returnUrl ) ) {
				RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
			}
		}

		protected void LogIn ( object sender , EventArgs e ) {
			if ( IsValid ) {
				// Validate the user password
				var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
				var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

				// This doen't count login failures towards account lockout
				// To enable password failures to trigger lockout, change to shouldLockout: true
				//var result = signinManager.PasswordSignIn(txtEmail.Text, txtPassword.Text, RememberMe.Checked, shouldLockout: false);
				var result = signinManager.PasswordSignIn(txtEmail.Text, txtPassword.Text, false, shouldLockout: false);

				switch ( result ) {
					case SignInStatus.Success:
						IdentityHelper.RedirectToReturnUrl ( Request.QueryString [ "ReturnUrl" ] , Response );
						break;
					case SignInStatus.LockedOut:
						Response.Redirect ( "/Account/Lockout" );
						break;
					case SignInStatus.RequiresVerification:
						Response.Redirect ( String.Format ( "/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}" ,
														Request.QueryString [ "ReturnUrl" ] ) ,
										  true );
						break;
					case SignInStatus.Failure:
					default:
						FailureText.Text = "Invalid login attempt";
						ErrorMessage.Visible = true;
						break;
				}
			}
		}
	}
}