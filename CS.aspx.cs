using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;


public partial class CS : System.Web.UI.Page
{
    public static int val = 0;
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //Constructor
    /*public CS()
    {
        Initialize();
    }*/

    //Initialize values
    private void Initialize()
    {
       
        server = text1.Text;
      
        database = text2.Text;
       
        uid = text3.Text;
     
        password = text4.Text;
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }


    //open connection to database
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            //When handling errors, you can your application's response based on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            switch (ex.Number)
            {
                case 0:
                   break;
                case 1045:
                    break;
            }
            return false;
        }
    }

    //Close connection
    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
           
            return false;
        }
    }

    protected void ExportCSV(object sender, EventArgs e)
    {
        Initialize();

        List<string>[] list;
        list = Select();

        string path = @"D:\MyTest.csv";
       
        for (int k = 0; k < list[0].Count; k++)
        {
            if (k == k)
            { File.AppendAllText(path, "\n", Encoding.UTF8); }

            for (int i2 = 0; i2 < val; i2++)
            {

                File.AppendAllText(path, list[i2][k] + ";", Encoding.UTF8);
            }
        }
    }
        
        public List<string>[] Select()
    {
        string query = "SELECT * FROM " + "`" + text5.Text+ "`";

        //Create a list to store the result
        List<string>[] list = new List<string>[8];
        for (int i = 0; i < 8; i++)
        {
            list[i] = new List<string>();
        }

        string path2 = @"D:\MyTest.csv";
       
        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            

            //Read the data and store them in the list
            while (dataReader.Read())
            {

                for (int b = 0; b < dataReader.FieldCount; b++)
                {
                    ;
                    list[b].Add(dataReader[b] + "");
                    val = dataReader.FieldCount;
                }
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }
}


