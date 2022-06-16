using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;

namespace ShopManager
{
    internal class SQLite : DBInterface
    {
        public void addItem(Item item)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();
            string sql = @"INSERT INTO items (id, name, quantity, price) VALUES (@id, @name, @quantity, @price)";
            conn.Execute(sql, item);
            conn.Close();
        }

        public void deleteItemById(int id)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();
            string sql = $"DELETE FROM items WHERE id = {id}";
            conn.Execute(sql);
            conn.Close();
        }

        public void editItem(Item item)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();
            string sql = $"UPDATE items SET name = @Name, quantity = @Quantity, price = @Price WHERE id = @Id";
            conn.Execute(sql, item);
            conn.Close();
        }

        public List<Item> getItems()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();

            string sql = "SELECT * FROM items";
            List<Item> items = conn.Query<Item>(sql).AsList();

            conn.Close();
            return items;
        }
    }
}
