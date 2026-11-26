using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Standard
{
    public class SalesOrderDetail
    {
        private int _orderQty = 0;
        private double _unitPrice = 0;
        private double _unitPriceDiscount = 0;
        private double _lineTotal = 0;
        private DateTime _ModifiedDate = DateTime.Now;

        String SalesOrderID {get; set;}
        String SalesOrderDetailID {get; set;}
        int OrderQty
        {
            get { return _orderQty; }
            set { _orderQty = value; }        
        }
        String ProductID {get; set;}
        Double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        Double UnitPriceDiscount
        {
            get { return _unitPriceDiscount; }
            set { _unitPriceDiscount = value; }
        }
        Double LineTotal
        {
            get { return OrderQty * UnitPrice; }
            set { _lineTotal = value; }
        }
        String rowguid {get; set;}
        DateTime ModifiedDate 
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; } 
        }

        public SalesOrderDetail() { }

        public SalesOrderDetail(String SalesOrderDetailID) 
        { 
            String strQuery = Config.getAppSettings("sql_OrderDetailInfofromOrderDetailID");
            using(SqlConnection con = new SqlConnection(Config.getConnectionString()))
            {
                SqlCommand com = new SqlCommand(strQuery, con);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@SalesOrderDetailID", SalesOrderDetailID);

                con.Open();

                SqlDataReader datReader = com.ExecuteReader();
                if (datReader.HasRows)
                { 
                    while(datReader.Read())
                    {
                        SalesOrderID = datReader["SalesOrderID"].ToString();
                        SalesOrderDetailID = datReader["SalesOrderDetailID"].ToString();
                        try { OrderQty = Convert.ToInt32(datReader["OrderQty"].ToString()); }
                        catch (Exception) { OrderQty = 0; }
                        ProductID = datReader["ProductID"].ToString();
                        try { UnitPrice = Convert.ToDouble(datReader["UnitPrice"].ToString()); }
                        catch (Exception) { UnitPrice = 0; }
                        try { UnitPriceDiscount = Convert.ToDouble(datReader["UnitPriceDiscount"].ToString()); }
                        catch (Exception) { UnitPriceDiscount = 0; }
                        try { LineTotal = Convert.ToDouble(datReader["LineTotal"].ToString()); }
                        catch (Exception) { LineTotal = 0; }
                        rowguid = datReader["rowguid"].ToString();
                        try { ModifiedDate = Convert.ToDateTime(datReader["ModifiedDate"].ToString()); }
                        catch (Exception) { }
                    }
                }

                con.Close();
            }
        }

        public String displayInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SalesOrder ID is: {0} ", SalesOrderID);
            sb.AppendFormat("SalesOrderDetail ID is: {0} ", SalesOrderDetailID);
            sb.AppendFormat("Product ID is: {0} ", ProductID);
            sb.AppendFormat("Unit Price is: {0} ", UnitPrice);
            sb.AppendFormat("Unit Price Discount is: {0} ", UnitPriceDiscount);
            sb.AppendFormat("Line Total is: {0} ", LineTotal);
            sb.AppendFormat("Modified Date is: {0} ", ModifiedDate);

            return sb.ToString();
        }

        public DataSet getSalesOrderDetailDataSet()
        {
            DataSet ds = new DataSet();
            using(SqlConnection con = new SqlConnection(Config.getConnectionString()))
            {
                con.Open();
                SqlDataAdapter SalesOrderDetailAdapter = getSalesOrderDetailAdapter(con);
                SalesOrderDetailAdapter.Fill(ds);
                con.Close();
            }

            return ds;
        }

        private SqlDataAdapter getSalesOrderDetailAdapter(SqlConnection con)
        {
            String strQuery = Config.getAppSettings("sql_OrderDetailInfo");
            SqlCommand com = new SqlCommand(strQuery, con);
            SqlDataAdapter salesOrderDetailAdapter = new SqlDataAdapter(com);
            salesOrderDetailAdapter.TableMappings.Add("Table", "SalesOrderDetail");

            return salesOrderDetailAdapter;
        }

        public DataSet getCustomerDataSet(String strQuery)
        {
            DataSet ds = new DataSet();
            using(SqlConnection con = new SqlConnection(Config.getConnectionString()))
            {
                con.Open();
                SqlDataAdapter customerAdapter = new SqlDataAdapter(strQuery, con);
                customerAdapter.Fill(ds, "Customer");
                con.Close();
            }

            return ds;
        }

        public int insertTest(String name, int qty)
        {
            int newid = 0;

            using(SqlConnection con = new SqlConnection(Config.getConnectionString()))
            {
                SqlCommand com = new SqlCommand("spCreateTest", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                
                SqlParameter paraName = com.Parameters.Add("@name", SqlDbType.VarChar, 10);
                paraName.Value = name;
                paraName.Direction = ParameterDirection.Input;

                SqlParameter paraQty = com.Parameters.Add("@qty", SqlDbType.Int);
                paraQty.Value = qty;
                paraQty.Direction = ParameterDirection.Input;

                SqlParameter paraid = com.Parameters.Add("@testid", SqlDbType.Int);
                paraid.Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();
                try { newid = Convert.ToInt32(com.Parameters["@testid"].Value.ToString()); }catch(Exception){}

                con.Close();

            }

            return newid;
        }
    }
}