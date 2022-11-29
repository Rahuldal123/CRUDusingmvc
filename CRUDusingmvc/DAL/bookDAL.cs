using System.Data.SqlClient;
namespace CRUDusingmvc.DAL
{
    public class bookDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public bookDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string str= this.configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(str);
        }
        public List<Book> Getallbooks()
        {
            List<Book> books = new List<Book>();
            cmd = new SqlCommand("select * from Book", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Book b = new Book();
                    b.Id = Convert.ToInt32(dr["id"]);
                    b.Name = dr["name"].ToString();
                    b.Price = Convert.ToInt32(dr["price"]);
                    books.Add(b);
                }

            }
            con.Close();
            return books;

        }
        public Book GetBookById(int id)
        {
            Book b = new Book();
            string qry = "select * from book where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    b.Id = Convert.ToInt32(dr["id"]);
                    b.Name = dr["name"].ToString();
                    b.Price = Convert.ToInt32(dr["price"]);
                }

            }
            con.Close();
            return b;
        }
        public int AddBook(Book b)
        {
            string qry = "insert into book values(@name,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", b.Name);
            cmd.Parameters.AddWithValue("@price", b.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateBook(Book b)
        {
            string qry = "update book set name=@name,price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", b.Name);
            cmd.Parameters.AddWithValue("@price", b.Price);
            cmd.Parameters.AddWithValue("@id", b.Id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteBook(int id)
        {
            string qry = "delete from book where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
