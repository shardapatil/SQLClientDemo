
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;

namespace NEWLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            do
            {
                Console.WriteLine("Enter Your Choice: " +
                    "\n1 to Add Customer" +
                    "\n2 to Update customer" +
                    "\n3 to delete a customer based on ID" +
                    "\n4 to Show Customers" +
                    "\n5 to search Customers" +
                    "\n6 to Exit!!");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Customer cust = new Customer();
                        Console.WriteLine("Enter Customer ID: ");
                        cust.CustID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Customer Name: ");
                        cust.Name = Console.ReadLine();

                        Console.WriteLine("Enter Customer Address: ");
                        cust.Address = Console.ReadLine();

                        Console.WriteLine("Enter Customer Email: ");
                        cust.Email = Console.ReadLine();

                        Console.WriteLine("Enter Customer Mobile Number: ");
                        cust.Mobile = Console.ReadLine();

                        Insert(cust);

                        break;
                    case 2:

                        Customer cust1 = new Customer();
                        Console.WriteLine("Enter Customer ID: ");
                        cust1.CustID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Customer Name: ");
                        cust1.Name = Console.ReadLine();

                        Console.WriteLine("Enter Customer Address: ");
                        cust1.Address = Console.ReadLine();

                        Console.WriteLine("Enter Customer Email: ");
                        cust1.Email = Console.ReadLine();

                        Console.WriteLine("Enter Customer Mobile Number: ");
                        cust1.Mobile = Console.ReadLine();

                        Update(cust1);

                        break;

                    case 3:
                        Console.WriteLine("Enter Customer ID: ");
                        int CustID = int.Parse(Console.ReadLine());

                        Delete(CustID);
                        break;
                    case 4:
                       // Console.WriteLine("CustID   Name    Address      Email       Mobile");
                        List<Customer> cLst = getAllCustomer();

                        foreach (Customer c in cLst)
                        {
                            Console.WriteLine("CustID: "+ c.CustID + " Name: " + c.Name + " Address: " + c.Address + " Email: " + c.Email + " Mobile: " + c.Mobile);
                        }

                        break;
                    case 5:

                        Console.WriteLine("Enter Customer ID: ");
                        int custid1 = int.Parse(Console.ReadLine());

                        Customer c2 = searchCustomer(custid1);

                        Console.WriteLine("CustID: " + c2.CustID + "  Name: " + c2.Name + "  Address: " + c2.Address + "  Email: " + c2.Email + "  Mobile: " + c2.Mobile);

                        /*Console.WriteLine(c2.CustID);
                        Console.WriteLine(c2.Name);
                        Console.WriteLine(c2.Address);
                        Console.WriteLine(c2.Email);
                        Console.WriteLine(c2.Mobile);*/

                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        choice = 0;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            while (choice != 0);
        }


        //insert customer
        static void Insert(Customer obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertCustomer";

                cmd.Parameters.AddWithValue("@CustID", obj.CustID);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);

                int status = cmd.ExecuteNonQuery();

                if (status == 0)
                {
                    Console.WriteLine("failed to insert");
                }
                else
                {
                    Console.WriteLine("insert successfull!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


        //update customer
        static void Update(Customer obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateCustomer";

                cmd.Parameters.AddWithValue("@CustID", obj.CustID);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);

                int status = cmd.ExecuteNonQuery();

                if (status == 0)
                {
                    Console.WriteLine("failed to Update");
                }
                else
                {
                    Console.WriteLine("Update successfull!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        //delete customer
        static void Delete(int custid)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteCustomer";

                cmd.Parameters.AddWithValue("@CustID", custid);

                int status = cmd.ExecuteNonQuery();

                if (status == 0)
                {
                    Console.WriteLine("failed to delete");
                }
                else
                {
                    Console.WriteLine("delete successfull!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        //delete customer
        static List<Customer> getAllCustomer()
        {

            List<Customer> custLst = new List<Customer>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Customers";

                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Customer c = new Customer();
                    c.CustID = dr.GetInt32("CustID");
                    c.Name = dr.GetString("Name");
                    c.Address = dr.GetString("Address");
                    c.Email = dr.GetString("Email");
                    c.Mobile = dr.GetString("Mobile");

                    custLst.Add(c);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return custLst;
        }


        //delete customer
        static Customer searchCustomer(int custno)
        {

            Customer c = new Customer();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Customers where CustID = @CustID";

                cmd.Parameters.AddWithValue("@CustID", custno);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //Customer c = new Customer();
                    c.CustID = dr.GetInt32("CustID");
                    c.Name = dr.GetString("Name");
                    c.Address = dr.GetString("Address");
                    c.Email = dr.GetString("Email");
                    c.Mobile = dr.GetString("Mobile");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return c;
        }
    }

    class Customer
    {
        //CustID, Name, Address, Email, Mobile

        public int CustID { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
