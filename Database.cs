using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace ERPsystem
{
    class Database
    {
        private static SqlConnection connection = new SqlConnection();
        static Database()
        {
            string connectionstring = File.ReadAllText("../../../connectionString.txt");
            connection = new SqlConnection(connectionstring);
            connection.Open();
        }
        public static void Insert(Item item)
        {
            string insertstring = "INSERT INTO Item (Itemnumber, Name, Amount, SalePrice, PurchasePrice, Inventoryplace)VALUES(" + item.Itemnumber + ", '" + item.name + "', " + item.amount + ", " + item.SalePrice.ToString().Replace(',','.') + ", " + item.PurchasePrice.ToString().Replace(',', '.') + ", " + item.Invetoryplace + "); select SCOPE_IDENTITY();";
            SqlCommand insert = new SqlCommand(insertstring, connection);
            SqlDataReader ID = insert.ExecuteReader();
            while (ID.Read())
            {
                item.ID = ID.GetInt32(0);
            }
        }
        public static void Insert(Order order)
        {
            string insertstring = "INSERT INTO Orders (CostumorID, Delivery)VALUES(" + order.CosutormorID + ", "+order.date+ "); select SCOPE_IDENTITY();";
            SqlCommand insert = new SqlCommand(insertstring, connection);
            SqlDataReader ID = insert.ExecuteReader();
            while (ID.Read())
            {
                order.ID = ID.GetInt32(0);
            }

        }
        public static void Insert(OrderLine orderLine)
        {
            string insertstring = "INSERT INTO Orders (OrderID, ItemID, Amount)VALUES(" + orderLine.OrderID + ", " + orderLine.ItemID + ", "+orderLine.Amount+ "); select SCOPE_IDENTITY();";
            SqlCommand insert = new SqlCommand(insertstring, connection);
            SqlDataReader ID = insert.ExecuteReader();
            while (ID.Read())
            {
                orderLine.ID = ID.GetInt32(0);
            }
        }
        public static List<Item> GetItems()
        {
            List<Item> result = new();
            SqlCommand getitems = new SqlCommand("select Itemnumber, Name, Amount, SalePrice, PurchasePrice, Inventoryplace, Id from Item", connection);
            SqlDataReader sqlresult = getitems.ExecuteReader();
            while (sqlresult.Read())
            {
                Item newItem = new();
                newItem.Itemnumber = sqlresult.GetInt32(0);
                newItem.name = sqlresult.GetString(1);
                newItem.amount = sqlresult.GetInt32(2);
                newItem.SalePrice = sqlresult.GetDouble(3);
                newItem.PurchasePrice = sqlresult.GetDouble(4);
                newItem.Invetoryplace = sqlresult.GetInt32(5);
                newItem.ID = sqlresult.GetInt32(6);
                result.Add(newItem);
            }
            return result;
        }
        public static List<Order> GetOrders()
        {
            List<Order> result = new();
            SqlCommand getitems = new SqlCommand("select ID, CosumorID, DeliveryDate from Orders", connection);
            SqlDataReader sqlresult = getitems.ExecuteReader();
            while (sqlresult.Read())
            {
                Order newOrder = new();
                newOrder.ID = sqlresult.GetInt32(0);
                newOrder.CosutormorID = sqlresult.GetInt32(1);
                newOrder.date = sqlresult.GetDateTime(2);
                result.Add(newOrder);
            }
            return result;
        }
        public static void Update(Item item)
        {
            SqlCommand UpdateItem = new SqlCommand("update Item set Itemnumber = "+item.Itemnumber+", Name = '" + item.name + "', Amount = " + item.amount + ", SalePrice = " + item.SalePrice.ToString().Replace(',', '.') + ", PurchasePrice = " + item.PurchasePrice.ToString().Replace(',', '.') + ", Inventoryplace  = " + item.Invetoryplace + " where Id = "+item.ID+" ",connection);
            UpdateItem.ExecuteNonQuery();
        }
        public static void Update(Order order)
        {
            SqlCommand UpdateOrders = new SqlCommand("update Orders set CosturmorID = " + order.CosutormorID + ", DeliveryDate = " + order.date + " where ID = " + order.ID + "", connection);
            UpdateOrders.ExecuteNonQuery();
        }

    }
}
