﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace coding_lms {
	public partial class SiteMaster : MasterPage {
		protected void Page_Load ( object sender , EventArgs e ) {

		}

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Response.Redirect("~/Login.aspx");
            DialogDiv.Style["Display"] = "block";
        }

        protected void CancelButton_OnClick(object sender, EventArgs e)
        {
            DialogDiv.Style["Display"] = "none";
        }
    }
}