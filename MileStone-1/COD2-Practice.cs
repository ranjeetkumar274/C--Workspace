using System;
using System.Data;
using System.Data.SqlClient;
using COD2Test.Models;


namespace COD2Test{

    namespace Models{}
    public class Program{

        public static string conStr = "User ID=sa;password=examlyMssql@123;server=localhost;database=appdb;trusted_connection=false;Persist Security Info=False;Encrypt=False";

        public static void Main(string[] args){

            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Book throgh Object");
            Console.WriteLine("3. List Books");
            Console.WriteLine("4. Search Book By ISBN");
            Console.WriteLine("5. Delete Book By ID");
            Console.WriteLine("6. Update Book Copies");
            Console.WriteLine("7. Sort Books By Year");
            Console.WriteLine("8. Show Top Books");
            Console.WriteLine("Select options from (1-8)");

            int ch = int.Parse(Console.ReadLine());

            switch(ch){
                case 1:
                 AddBook();
                 break;

                case 2:
                 Console.Write("Title: ");
                string ti = Console.ReadLine();

                Console.Write("Author: ");
                string au = Console.ReadLine();

                Console.Write("ISBN: ");
                string isb = Console.ReadLine();

                Console.Write("Publisher: ");
                string pu = Console.ReadLine();

                Console.Write("Year: ");
                int ye = int.Parse(Console.ReadLine());

                Console.Write("Copies : ");
                int co = int.Parse(Console.ReadLine());

                Library li = new Library(ti,au,isb,pu,ye,co);

                 AddBookByObj(li);
                 break;

                case 3:
                 ListBooks();
                 break;

                case 4:
                 Console.Write("Enter ISBN: ");
                 string iisb = Console.ReadLine();
                 SearchBookByISBN(iisb);
                 break;

                case 5:
                 Console.Write("Enter Id: ");
                 int iid = int.Parse(Console.ReadLine());
                 DeleteBookById(iid);
                 break;

                case 6:
                 Console.Write("Enter Id: ");
                 int iiid = int.Parse(Console.ReadLine());

                 Console.Write("Enter newCopies: ");
                 int nCopies = int.Parse(Console.ReadLine());
                 UpdateBookCopies(iiid,nCopies);
                 break;

                case 7:
                 SortBooksByYearDescending();
                 break;

                case 8:
                 Console.Write("Enter Top Count: ");
                 int top = int.Parse(Console.ReadLine());
                 ShowTopBooks(top);
                 break;

                default:
                 Console.WriteLine("Invalid Input.");
                 return;
                 break;
            }


        }

        public static void AddBook(){

            Console.WriteLine("Enter your details:");
            Console.Write("Title: ");
            string t = Console.ReadLine();

            Console.Write("Author: ");
            string a = Console.ReadLine();

            Console.Write("ISBN: ");
            string i = Console.ReadLine();

            Console.Write("Publisher: ");
            string p = Console.ReadLine();

            Console.Write("Year: ");
            int y = int.Parse(Console.ReadLine());

            Console.Write("Copies : ");
            int c = int.Parse(Console.ReadLine());

            string query = "select * from library where ISBN = @i";

            SqlConnection con = new SqlConnection(conStr);
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.SelectCommand.Parameters.AddWithValue("@i",i);
            da.Fill(tb);

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            if(tb.Rows.Count >= 1){
                Console.WriteLine("Duplicate ISBN. Cannot add book.");
                return;
            }

            DataRow r = tb.NewRow();
            r[1] = t;
            r[2] = a;
            r[3] = i;
            r[4] = p;
            r[5] = y;
            r[6] = c;

            tb.Rows.Add(r);
            da.Update(tb);
            Console.WriteLine($"Book {t} added successfully.");
        }

        public static void AddBookByObj(Library lib){

            string query = "select * from library";

            SqlConnection con = new SqlConnection(conStr);
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.Fill(tb);

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataRow r = tb.NewRow();
            r[1] = lib.Title;
            r[2] = lib.Author;
            r[3] = lib.ISBN;
            r[4] = lib.Publisher;
            r[5] = lib.YearPublished;
            r[6] = lib.CopiesAvailable;

            tb.Rows.Add(r);
            da.Update(tb);
            Console.WriteLine($"Book {lib.Title} added successfully.");
        }

        public static void ListBooks(){
            string query = "select * from library";

            SqlConnection con = new SqlConnection(conStr);
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.Fill(tb);

            if(tb.Rows.Count >= 1){
                foreach(DataRow r in tb.Rows){
                Console.WriteLine($"BookID: {r[0]}\tTitle: {r[1]}\tAuthor: {r[2]}\tISBN: {r[3]}\tPublisher: {r[4]}\tYearPublished: {r[5]}\t CopiesAvaialble: {r[6]}");
            }
            }else{
                Console.WriteLine("No Books Avaialable.");
                return;
            } 

        }

        public static void SearchBookByISBN(string isbn){
            string query = "select * from library where ISBN = @isbn";

            SqlConnection con = new SqlConnection(conStr);
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.SelectCommand.Parameters.AddWithValue("@isbn",isbn);
            da.Fill(tb);

            if(tb.Rows.Count == 1){
                foreach(DataRow r in tb.Rows){
                Console.WriteLine($"BookID: {r[0]}\tTitle: {r[1]}\tAuthor: {r[2]}\tISBN: {r[3]}\tPublisher: {r[4]}\tYearPublished: {r[5]}\t CopiesAvaialble: {r[6]}");
            }
            }else{
                Console.WriteLine($"No Book found with {isbn}.");
                return;
            }
        }

        public static void DeleteBookById(int id){
            string query = "select * from library where BookID = @id";

            SqlConnection con = new SqlConnection(conStr);
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.SelectCommand.Parameters.AddWithValue("@id",id);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Fill(tb);

            if(tb.Rows.Count == 1){
                DataRow r = tb.Rows[0];
                r.Delete();
                da.Update(tb);
                Console.WriteLine("Book Deleted Successfully.");
            }
            else{
                Console.WriteLine($"No Book found with {id}.");
                return;
            }
        }

        public static void UpdateBookCopies(int bid, int newCopies){
            string query = "select * from library where BookID = @bid";

            SqlConnection con = new SqlConnection(conStr);
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.SelectCommand.Parameters.AddWithValue("@bid",bid);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Fill(tb);

            if(tb.Rows.Count == 1){
                DataRow r = tb.Rows[0];
                r["CopiesAvailable"] = newCopies;
                da.Update(tb);
                Console.WriteLine("Copies Updated Successfully.");
            }
            else{
                Console.WriteLine($"No Book found with {bid}.");
                return;
            }
        }

        public static void SortBooksByYearDescending(){
            string query = "select * from library order by YearPublished DESC";

            SqlConnection con = new SqlConnection(conStr);
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.Fill(tb);

            foreach(DataRow r in tb.Rows){
                Console.WriteLine($"BookID: {r[0]}\tTitle: {r[1]}\tAuthor: {r[2]}\tISBN: {r[3]}\tPublisher: {r[4]}\tYearPublished: {r[5]}\t CopiesAvaialble: {r[6]}");
            }
        }

        public static void ShowTopBooks(int tcount){
            string query = "select top @tcount * from library order by YearPublished desc";

            SqlConnection con = new SqlConnection(conStr);
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.SelectCommand.Parameters.AddWithValue("@tcount",tcount);
            da.Fill(tb);

            if(tb.Rows.Count <= 0){
                Console.WriteLine("No Books Available.");
                return;
            }

            Console.WriteLine("Top books: ");
            foreach(DataRow r in tb.Rows){
                Console.WriteLine($"BookID: {r[0]}\tTitle: {r[1]}\tAuthor: {r[2]}\tISBN: {r[3]}\tPublisher: {r[4]}\tYearPublished: {r[5]}\t CopiesAvaialble: {r[6]}");
            }
        }


    }

}
