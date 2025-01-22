using System;
using System.Web.UI;

namespace quiz {
	public partial class SiteMaster : MasterPage {

		public string CopyrightYear {
			get {
				var yr = DateTime.Now.Year;
				string ret = $"{yr}";

				// 2024 is the Hard-coded Year the application was created
				if ( yr > 2024 ) {
					ret = $"2024-{yr}";
				}

				return ret;
			}
		}

		#region Events
		protected void Page_Load ( object sender , EventArgs e ) {

		}
		#endregion
	}
}