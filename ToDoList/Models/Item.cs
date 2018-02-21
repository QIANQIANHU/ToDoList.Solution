using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList;
using System;

namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private int _id;

    public Item(string Description, int Id = 0)
    {
      _id = Id;
      _description = Description;
    }

    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public int GetId()
    {
      return _id;
    }

    public static List<Item> GetAll()
    {
        List<Item> allItems = new List<Item> {};
        MySqlConnection conn = DB.Connection();//A MySqlConnection object basically represents the database using the connection information that we set it to. As discussed at the end of the previous lesson, calling DB.Connection() establishes a connection with our MySql database, returning a conn object we can use to interact with the database.
        conn.Open();//attempt to interact with a database connection that hasn't been manually opened, an exception will be thrown.
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;//for sending SQL statements to the database.
        cmd.CommandText = @"SELECT * FROM items;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;// the rdr object represents the actual reading of the SQL database. And the MySqlDataReader class also includes a built-in Read() method that sends the SQL Commands to the database and collects whatever the database returns in response to those commands.
        while(rdr.Read())
        {
          int itemId = rdr.GetInt32(0);
          string itemDescription = rdr.GetString(1);
          Item newItem = new Item(itemDescription, itemId);
          allItems.Add(newItem);
        }//two methods on the rdr object; GetInt32() and GetString()
        conn.Close();//to close the connection to the database
        if (conn != null)
        {
            conn.Dispose();
        }
        return allItems;
    }
    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM items;";

        cmd.ExecuteNonQuery();

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
   }
    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
