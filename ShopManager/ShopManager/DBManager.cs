using System.Collections.Generic;

namespace ShopManager
{
    public class DBManager
    {
        private DBInterface _dbInterface;

        public DBManager(DBInterface db) { _dbInterface = db; }

        public List<Item> GetItems()
        {
            return _dbInterface.getItems();
        }

        public void deleteItemById(int id)
        {
            _dbInterface.deleteItemById(id);
        }
        public void addItem(Item item)
        {
            _dbInterface.addItem(item);
        }
        public void editItem(Item item)
        {
            _dbInterface.editItem(item);
        }

        public int GetNewId()
        {
            return _dbInterface.getNewId();
        }
    }
}
