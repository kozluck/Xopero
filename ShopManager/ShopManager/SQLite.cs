using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ShopManager
{
    public class SQLite : DBInterface
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");

        public void addItem(Item item)
        {
            conn.Open();
            string sql = @"INSERT INTO items (id, name, quantity, price) VALUES (@id, @name, @quantity, @price)";
            conn.Execute(sql, item);
            conn.Close();
        }

        public void deleteItemById(int id)
        {
            conn.Open();
            string sql = $"DELETE FROM items WHERE id = {id}";
            conn.Execute(sql);
            conn.Close();
        }

        public void editItem(Item item)
        {
            conn.Open();
            string sql = $"UPDATE items SET name = @Name, quantity = @Quantity, price = @Price WHERE id = @Id";
            conn.Execute(sql, item);
            conn.Close();
        }

        public List<Item> getItems()
        {
            conn.Open();
            string sql = "SELECT * FROM items";
            List<Item> items = conn.Query<Item>(sql).AsList();

            conn.Close();
            return items;
        }

        public int getNewId()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();
            string sql = "SELECT max(id) FROM items";
            if (conn.ExecuteScalar(sql) == null) return 0;
            else
            {
                int id = (int)(long)conn.ExecuteScalar(sql);
                return ++id;
            }
        }
    }
}
