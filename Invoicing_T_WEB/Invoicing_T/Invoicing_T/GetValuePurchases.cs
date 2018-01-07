using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;

namespace Invoicing_T
{
    public class GetValuePurchases
    {
        DBHandle tmp = new DBHandle();
        private string pur_id;
        private string p_id;
        private string pur_name;
        private decimal pur_price;
        private decimal pur_count;
        private decimal pur_total;


        public string PurID
        {
            get { return pur_id; }
            set { pur_id = value; }
        }
        public string pid
        {
            get { return p_id; }
            set { p_id = value; }
        }
        public string Name
        {
            get {
                //DataSet ds = tmp.GetProductInfo(" WHERE p_id = '"+pid+"'");
                //DataRow dr = ds.Tables["product_info"].Rows[0];
                //pur_name = dr["p_name"].ToString();
                return pur_name;
            }
            set { pur_name = value; }
        }
        public decimal Price
        {
            get { return pur_price; }
            set { pur_price = value; }
        }
        public decimal Count
        {
            get { return pur_count; }
            set { pur_count = value; }
        }
        public decimal Total
        {
            get { return pur_price * pur_count; }
        }

        public GetValuePurchases()
        {
           
        }

        /*public GetValuePurchases(string id, string name, decimal price, decimal count, decimal total)
        {
             this.pur_id = id;
            this.pur_name = name;
            this.pur_price = price;
            this.pur_count = count;
            this.pur_total = total;
        }*/
    }
}