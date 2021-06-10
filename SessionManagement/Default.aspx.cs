using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnLogIn_Click(object sender, EventArgs e)
		{
			if (txtUser.Text=="bgates" && txtPassword.Text=="billions")
			{
				string user = txtUser.Text;
				string pass = txtPassword.Text;
				Response.Redirect("ThirdPage.aspx?u=" + txtUser.Text + "&p=" + txtPassword.Text);
			}
			if (txtUser.Text == "jmiller" && txtPassword.Text == "games")
			{
				string user = txtUser.Text;
				string pass = txtPassword.Text;
				Response.Redirect("ThirdPage.aspx?u=" + txtUser.Text + "&p=" + txtPassword.Text);
			}
			else
			{
				lblMessage.Text = "Account not recognized";
			}
	
		}
	}
}