using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager
{
    internal class DBManager
    {
        public static DBInterface db { get; set; }

        public List<Item> GetItems()
        {
            return db.getItems();
        }

        public void deleteItemById(int id)
        {
            db.deleteItemById(id);
        }
        public void addItem(Item item)
        {
            db.addItem(item);
        }
        public void editItem(Item item)
        {
            db.editItem(item);
        }


    }
}
