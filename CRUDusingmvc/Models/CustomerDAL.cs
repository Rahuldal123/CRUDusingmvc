using System.Data.SqlClient;
namespace CRUDusingmvc.Models;

public class CustomerDAL
{
    private readonly IConfiguration configuration;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;

    public CustomerDAL(IConfiguration configuration)
    {
        this.configuration = configuration;
        string str = this.configuration.GetConnectionString("defaultConnection");
        con = new SqlConnection(str);


    }
    public int CustomerRegister(Customer cust)
    {
        string qry = "insert into Customers values (@name,@email,@contact,@password)";
        cmd = new SqlCommand(qry, con);
        cmd.Parameters.AddWithValue("@name", cust.Name);
        cmd.Parameters.AddWithValue("@email", cust.Email);
        cmd.Parameters.AddWithValue("@contact", cust.Contact);
        cmd.Parameters.AddWithValue("@password", cust.Password);
        con.Open();
        int result = cmd.ExecuteNonQuery();
        con.Close();
        return result;

    }
    public Customer CustomerLogin(Customer cust)
    {
        Customer c = new Customer();
        string qry = "select * from Customers where email=@email and password=@password";
        cmd = new SqlCommand(qry, con);
        cmd.Parameters.AddWithValue("@email", cust.Email);
        cmd.Parameters.AddWithValue("@password", cust.Password);
        con.Open();
        dr=cmd.ExecuteReader();
        if(dr.HasRows)
        {
            while(dr.Read())
            {
                c.Id = Convert.ToInt32(dr["id"]);
                c.Name = dr["name"].ToString();
                c.Email = dr["email"].ToString();
            }
            return c;
        }
        else
        {
            return null;
        }
    }
}
