using KendoWindow_Ajax_Form.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Serialization;

namespace KendoWindow_Ajax_Form.Helpers
{
    public class SRBinderHelper
    {
        public static IEnumerable<SRViewModel> RetrunListOfOrders()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/SRData.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);
            var result = new List<SRViewModel>();
            result = (from rows in ds.Tables[0].AsEnumerable()
                        select new SRViewModel
                        {
                            SRID = Convert.ToInt32(rows[0].ToString()),
                            CustomerID = rows[1].ToString(),
                            ContactName = rows[2].ToString(),
                            SRDate = DateTime.Parse(rows[3].ToString()),
                            ShippedDate = DateTime.Parse(rows[4].ToString())

                        }).ToList();
            return result;
        }

        public static void AddOrder(SRViewModel order)
        {
            var list = RetrunListOfOrders().ToList();
            list.Add(order);

            WriteListOfOrders(list);
        }

        public static IEnumerable<SRViewModel> WriteListOfOrders(IEnumerable<SRViewModel> orders)
        { 
            DataSet ds = ToDataTable(orders);
            ds.WriteXml(HttpContext.Current.Server.MapPath("~/App_Data/SRData.xml"));


            return RetrunListOfOrders();
        }

        public static DataSet ToDataTable(IEnumerable<SRViewModel> items)
        {
            var ds = new DataSet();
            var tb = new DataTable(typeof(SRViewModel).Name);

            PropertyInfo[] props = typeof(SRViewModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            ds.Tables.Add(tb);

            return ds;
        }
    }
}