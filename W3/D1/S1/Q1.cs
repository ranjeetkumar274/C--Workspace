using System;
using System.Data;
using System.Data.SqlClient;
using DisconnectedArchitecture.Models;


namespace DisconnectArchitecture
{

    namespace Models{}  //in models code i kept my Product class


    public static class ConnectionStringProvider
    {
        // Replace with your actual connection string
        public static string ConnectionString { get; } = "User ID=sa;password=examlyMssql@123;server=localhost;database=appdb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
    }

    public class Program
    {
        // Replace with your actual connection string
        public static string connectionString = ConnectionStringProvider.ConnectionString;
        public static SqlConnection con = new SqlConnection(connectionString);

        static void Main(string[] args) 
        {

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. List Products");
            Console.WriteLine("3. Update Stock Quantity");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
            int ch = int.Parse(Console.ReadLine());
            switch(ch){
                case 1:
                 Console.WriteLine("Enter the details for the new product:");
                 Console.Write("ProductID: ");
                 int pid = int.Parse(Console.ReadLine());

                 Console.Write("ProductName: ");
                 string pname = Console.ReadLine();

                 Console.Write("Price: ");
                 decimal pprice = decimal.Parse(Console.ReadLine());

                 Console.Write("StockQuantity: ");
                 int pstock = int.Parse(Console.ReadLine());

                 Product p = new Product(pid,pname,pprice,pstock);
                 AddProduct(p);
                 break;

                case 2:
                 Console.WriteLine("List of Products:");
                 ListProducts();
                 break;

                case 3:
                 Console.Write("Enter the name of the product stock quantity: ");
                 string prodName = Console.ReadLine();

                 Console.Write("Enter the new stock quantity: ");
                 int nStock = int.Parse(Console.ReadLine());
                 UpdateProductStock(prodName,nStock);
                 break;

                case 4:
                Console.Write("Enter the ProductID of the product to delete: ");
                int did = int.Parse(Console.ReadLine());
                DeleteProduct(did);
                break;

                case 5:
                 return;
                 break;

                default:
                 break;
            }

        }
        // Change your method names (xyz) to appropriate name
        public static void AddProduct(Product pr)
        {
            string query = "select * from products";
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            

            da.Fill(tb);

            DataRow r = tb.NewRow();
            r[0] = pr.ProductID;
            r[1] = pr.ProductName;
            r[2] = pr.Price;
            r[3] = pr.StockQuantity;

            tb.Rows.Add(r);
            da.Update(tb);
            Console.WriteLine("Product added successfully.");
        }

        public static void ListProducts()
        {
            string query = "select * from products";
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.Fill(tb);

            foreach(DataRow r in tb.Rows){
                Console.WriteLine($"ProductID: {r[0]}, ProductName: {r[1]}, Price: {r[2]}, StockQuantity: {r[3]}");
            }
        }

        public static void UpdateProductStock(string productName, int newStockQuantity)
        {
            string query = "select * from products where ProductName = @productName";
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.SelectCommand.Parameters.AddWithValue("@productName",productName);
            da.Fill(tb);

            DataRow r = tb.Rows[0];
            r[3] = newStockQuantity;

            da.Update(tb);
            Console.WriteLine("Product stock updated successfully.");

        }

        public static void DeleteProduct(int productID)
        {
           string query = "select * from products where ProductID = @productID";
           DataTable tb = new DataTable();

           SqlDataAdapter da = new SqlDataAdapter(query,con);
           da.SelectCommand.Parameters.AddWithValue("@productID",productID);
           SqlCommandBuilder cb = new SqlCommandBuilder(da);

           da.Fill(tb);
           DataRow r = tb.Rows[0];
           r.Delete();

           da.Update(tb);
           Console.WriteLine("Product deleted successfully.");
        }
    }
}
