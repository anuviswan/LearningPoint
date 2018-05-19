using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCF002_WebClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HelloService.LearningServiceClient client = new HelloService.LearningServiceClient();
            Name.Text = client.GetUserName();
        }
    }
}