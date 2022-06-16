using System.Collections.Generic;

namespace ShopManager
{
    internal interface DBInterface
    {
        public List<Item> getItems();
        public void deleteItemById(int id);
        public void addItem(Item item);
        public void editItem(Item item);

    }
}
