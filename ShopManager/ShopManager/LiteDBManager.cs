using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace ShopManager
{
    class LiteDBManager : DBInterface
    {
        LiteDatabase db = new LiteDatabase(@"Filename={}; Connection=Shared;");
        public void addItem(Item item)
        {
            var collection = db.GetCollection<Item>("items");
            collection.Insert(item);
        }

        public void deleteItemById(int id)
        {
            var collection = db.GetCollection<Item>("items");
            collection.Delete(id);
        }

        public void editItem(Item item)
        {
            var collection = db.GetCollection<Item>("items");
            collection.Update(item);
        }

        public List<Item> getItems()
        {
            var collection = db.GetCollection<Item>("items");
            return collection.FindAll().ToList();
        }

        public int getNewId()
        {
            var collection = db.GetCollection<Item>("items");
            if (collection.Count() != 0) return collection.Max(x => x.Id) + 1;
            else return 0;
        }
    }
}
