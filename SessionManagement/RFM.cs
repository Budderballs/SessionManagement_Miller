using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Threading;
using System.Text;
using System.Security.Cryptography;

namespace SessionManagement
{
    public class RFM : IHttpModule
    {
		Dictionary<string, string> t = new Dictionary<string, string>();
		public void Dispose()
		{
			// nothing to dispose
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += new EventHandler(OnBeginRequest);
		}

		private void OnBeginRequest(object sender, EventArgs e)
		{
			HttpContext context = ((HttpApplication)sender).Context;

			string URL = context.Request.Path;
			string user = context.Request.QueryString["u"];
			string pass = context.Request.QueryString["p"];
			string encryptUser = string.Empty;
			string encryptPass = string.Empty;

			if (user != null)
			{
				if(!t.ContainsKey(encryptUser))
                {
					encryptUser = encrypt(user);
					encryptPass = encrypt(pass);
					t.Add(encryptUser, user);
					t.Add(encryptPass, pass);
				}

				if(URL.Contains("ThirdPage") && t.Count > 4)
                {
					URL = "MembersMain.aspx";
                }

				context.RewritePath(URL, string.Empty, "u=" + encryptUser + "&p=" + encryptPass, true);

				if(t.ContainsKey(user) && t.ContainsValue(user))
                {
					context.RewritePath(URL, string.Empty, "u=" + t[user] + "&p=" + t[pass], true);
                }

				 else if(t.ContainsValue(user))
                {
					context.Response.Redirect(context.Request.Url.ToString());
                }
			}
		}

		public string encrypt(string info)
        {
			Random r = new Random(DateTime.Now.Millisecond);
			Thread.Sleep(5);
			string salt = r.Next(100000, 999999).ToString();
			int a;
			byte[] b;
			byte[] c;
			b = ASCIIEncoding.ASCII.GetBytes(info);
			c = new MD5CryptoServiceProvider().ComputeHash(b);
			StringBuilder output = new StringBuilder(c.Length);
			for(a=0; a < c.Length; a++)
            {
				output.Append(c[a].ToString("X2"));
            }
			return output.ToString().Substring(0, 8) + salt + output.ToString().Substring(8);
        }
	}
}