using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODotNet
{
    public class CustomerModel
    {
        public string Customername { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public int id { get;  set; }
    }
    public class Customer
    {
        public static void CreateDataBase()
        {

            SqlConnection con = new SqlConnection("data source=ITS-HEMANT-PC\\SQLEXPRESS; initial catalog=master; integrated security=true");
            try
            {
                //writing sql query
                string query = "create database Customer";
                SqlCommand cm = new SqlCommand(query, con);

                //opening connection
                con.Open();

                //executing sql query

                cm.ExecuteNonQuery();

                //Displaying a message

                Console.WriteLine("Database created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong" + e.Message);
            }
            //Closing the connection
            finally
            {
                con.Close();
            }
        }
        public static SqlConnection con = new SqlConnection("data source=ITS-HEMANT-PC\\SQLEXPRESS; initial catalog=Customer; integrated security=true");

        public static void CreateTable()
        {

            try
            {
                //writing sql query
                string query = "create table CustomerData (ID int identity(1,1) primary key,Customername varchar(20),Address varchar(200))";
                SqlCommand cm = new SqlCommand(query, con);

                //opening connection
                con.Open();

                //ExecuteNonQuery() function is used to execute our insert query

                cm.ExecuteNonQuery();

                //Displaying a message

                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong" + e.Message);
            }
            //Closing the connection
            finally
            {
                con.Close();
            }
        }

        public bool insert(CustomerModel model)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_insert", con);

                    cmd.CommandType = CommandType.StoredProcedure;              //excuting stored proc
                    cmd.Parameters.AddWithValue("@customername", model.Customername);
                    cmd.Parameters.AddWithValue("@address", model.Address);
                    cmd.Parameters.AddWithValue("@email", model.email);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {

                        Console.WriteLine("Executed");    //use when return type void

                        return true;   

                    }
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong  " + e.Message);
            }
            // Closing the connection  (no need to use finally block when we use using block to close)

            //finally
            //{
            //    con.Close();
            //}
            return false;
        }

        public bool delete(CustomerModel model)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_delete", con);

                    cmd.CommandType = CommandType.StoredProcedure;//excuting stored proc
                    //cmd.Parameters.AddWithValue("@id", model.id);

                    cmd.Parameters.AddWithValue("@customername", model.Customername);
                    cmd.Parameters.AddWithValue("@address", model.Address);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Executed");    //use when return type void

                        return true;   //use when return type is bool

                    }
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong  " + e.Message);
            }
            return false;
        }

        public bool Update(CustomerModel model)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;              //excuting stored proc
                    cmd.Parameters.AddWithValue("@customername", model.Customername);
                    cmd.Parameters.AddWithValue("@email", model.email);
                    cmd.Parameters.AddWithValue("@address", model.Address);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {

                        Console.WriteLine("Executed");    //use when return type void

                        return true;

                    }
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong  " + e.Message);
            }
            return false;
        }



        public void insertanddisplay(CustomerModel model)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_insert", con);

                    cmd.CommandType = CommandType.StoredProcedure;//excuting stored proc
                    cmd.Parameters.AddWithValue("@customername", model.Customername);
                    cmd.Parameters.AddWithValue("@email", model.email);
                    cmd.Parameters.AddWithValue("@address", model.Address);


                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        string query = "Select  * from CustomerData";
                        SqlCommand command = new SqlCommand(query, con);
                        SqlDataReader sqldatareader = command.ExecuteReader();
                        if (sqldatareader.HasRows)
                        {
                            Console.WriteLine("-----------Data------------");
                            while (sqldatareader.Read())
                            {
                                model.id = Convert.ToInt32(sqldatareader["id"]);
                                model.Customername = Convert.ToString(sqldatareader["Customername"]);
                                model.Address = Convert.ToString(sqldatareader["address"]);
                                model.email= Convert.ToString(sqldatareader["email"]);
                                Console.WriteLine("CustomerId:{0}\nCustomerName:{1}\nAddress:{2}\nEmail:{3}",model.id,model.Customername,model.Address,model.email);
                                Console.WriteLine("::::::::::::::::::::::::::::::::;");

                            }
                        }
                        Console.WriteLine("Executed");    //use when return type void
                    }
                    //return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong  " + e.Message);
            }

        }

        public void Display()
        {
            try
            {
                using (con)
                {
                    CustomerModel model = new CustomerModel();
                    string query = "Select * from CustomerData";
                    SqlCommand command=new SqlCommand(query,con);
                    con.Open();
                    SqlDataReader sqldatareader = command.ExecuteReader();
                    if (sqldatareader.HasRows)
                    {
                        //While loop is used to Print all the data sequencially
                        while (sqldatareader.Read())
                        { 
                            model.id = Convert.ToInt32(sqldatareader["id"]);
                            model.Customername = Convert.ToString(sqldatareader["Customername"]);
                            model.Address = Convert.ToString(sqldatareader["address"]);
                            model.email = Convert.ToString(sqldatareader["email"]);
                            Console.WriteLine("CustomerId:{0}\nCustomerName:{1}\nAddress:{2}\nEmail:{3}", model.id, model.Customername, model.Address, model.email);
                            Console.WriteLine("::::::::::::::::::::::::::::::::;");

                        }

                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Something Wnet Wrong :" , e.Message);
            }
        }
    }
}
