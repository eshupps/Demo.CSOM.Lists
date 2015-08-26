using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Client;

namespace Demo.CSOM.ListsWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Uri redirectUrl;
            switch (SharePointContextProvider.CheckRedirectionStatus(Context, out redirectUrl))
            {
                case RedirectionStatus.Ok:
                    return;
                case RedirectionStatus.ShouldRedirect:
                    Response.Redirect(redirectUrl.AbsoluteUri, endResponse: true);
                    break;
                case RedirectionStatus.CanNotRedirect:
                    Response.Write("An error occurred while processing your request.");
                    Response.End();
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(Context);

            ClientContext ctx = spContext.CreateUserClientContextForSPHost();
                List testList = ctx.Web.Lists.GetByTitle("Test List");

                CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
                Microsoft.SharePoint.Client.ListItemCollection items = GetListItems(ctx, testList, query);
                BindListItems(items);

                

                
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            listItemsContent.InnerHtml = "";
            
            //TODO: View Logic

        }

        protected static Microsoft.SharePoint.Client.ListItemCollection GetListItems(ClientContext context, Microsoft.SharePoint.Client.List list, CamlQuery query)
        {
            Microsoft.SharePoint.Client.ListItemCollection coll = null;

            coll = list.GetItems(query);

            context.Load(coll);
            context.ExecuteQuery();

            return coll;
        }

        protected void BindListItems(Microsoft.SharePoint.Client.ListItemCollection items)
        {
            string outHtml = "<ul>";
            
            if (items.Count > 0)
            {
                foreach (Microsoft.SharePoint.Client.ListItem listItem in items)
                {
                    // We have all the list item data. For example, Title. 
                    outHtml += string.Format("<li>{0}</li>", listItem["Title"]);
                }
            }
            else
            {
                outHtml += "<li>No items found</li>";
            }

            outHtml += "</ul>";

            listItemsContent.InnerHtml = outHtml;
        }
    }
}