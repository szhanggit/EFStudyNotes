using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Standard
{
    public partial class Default : System.Web.UI.Page
    {
        SalesOrderDetail sod;
        DataSet dsSalesOrderDetail;

        public int newid
        {
            get
            {
                if(ViewState["newid"] != null)
                {
                    return (int)ViewState["newid"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["newid"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sod = new SalesOrderDetail();
                dsSalesOrderDetail = new DataSet();

                if (Session["SalesOrderDetailDataSet"] == null)
                {
                    dsSalesOrderDetail = sod.getSalesOrderDetailDataSet();
                    Session["SalesOrderDetailDataSet"] = dsSalesOrderDetail;
                }
                else
                {
                    dsSalesOrderDetail = (DataSet)Session["SalesOrderDetailDataSet"];
                }

                gvSalesOrderDetail.DataSource = dsSalesOrderDetail;
                gvSalesOrderDetail.DataBind();
            }
        }

        protected void btnSearchBySalesOrderDetailID_Click(object sender, EventArgs e)
        {
            sod = new SalesOrderDetail(txtSalesOrderDetailID.Text.Trim());
            lblDisplayBoard.Text = sod.displayInfo();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from SalesLT.Customer where 1=1 ");
            if (txtTitle.Text.Trim() != "")
            {
                sb.AppendFormat("and title like '%{0}%' ", txtTitle.Text.Trim());    
            }
            if (txtSuffix.Text.Trim() != "")
            {
                sb.AppendFormat("and suffix like '%{0}%' ", txtSuffix.Text.Trim());
            }
            if (txtSalesPerson.Text.Trim() != "")
            {
                sb.AppendFormat("and SalesPerson like '%{0}%' ", txtSalesPerson.Text.Trim());
            }

            String strQuery = sb.ToString();
            sod = new SalesOrderDetail();
            DataSet ds = new DataSet();
            ds = sod.getCustomerDataSet(strQuery);

            gvSalesOrderDetail.DataSource = ds;
            gvSalesOrderDetail.DataBind();

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            sod = new SalesOrderDetail();
            newid = sod.insertTest(txtName.Text.Trim(), Convert.ToInt32(txtQTY.Text.Trim()));
            lblDisplayBoard.Text = "The new id is: " + newid;
        }
    }
}