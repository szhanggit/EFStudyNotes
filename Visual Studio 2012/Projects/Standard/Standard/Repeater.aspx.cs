using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Standard
{
    public partial class Repeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Menu> menuA = new List<Menu>
                {
                    new Menu{name = "Stake", price = 20.34, desc = "Good", star = 4},
                    new Menu{name = "Fried Chicken", price = 10.34, desc = "Good", star = 5},
                    new Menu{name = "French Onion Soup", price = 12.43, desc = "Good", star = 2},
                    new Menu{name = "French Fried", price = 9.32, desc = "Good", star = 3}
                };

                List<Menu> menuB = new List<Menu>
                {
                    new Menu{name = "Steam Fish", price = 20.34, desc = "Good", star = 4},
                    new Menu{name = "BBQ Chicken", price = 10.34, desc = "Good", star = 5},
                    new Menu{name = "Garden Salad", price = 12.43, desc = "Good", star = 2},
                    new Menu{name = "Red Bean Bum", price = 9.32, desc = "Good", star = 3}
                };

                List<Restaurant> restaurants = new List<Restaurant>
                {
                    new Restaurant{name = "Asian Legend", address = "Address1", phone = "293478343", webaddress = "http://www.sdf.com", email = "asd@ds.com", menu = menuA},
                    new Restaurant{name = "Dragon Pearl", address = "Address2", phone = "348934754", webaddress = "http://www.sdf.com", email = "fds@dfs.com", menu = menuB }
                };

                ReptRestaurant.DataSource = restaurants;
                ReptRestaurant.DataBind();
            }
        }
    }
}