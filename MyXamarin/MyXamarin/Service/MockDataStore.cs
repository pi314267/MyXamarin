using MyXamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyXamarin.Service
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an 1 item description.", Uri="https://homepages.cae.wisc.edu/~ece533/images/airplane.png" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an 2item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/arctichare.png"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an 3 item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/baboon.png"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an 4 item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/boat.png"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an 5 item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/cat.png"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an 6 item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/girl.png"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "7 item", Description="This is an 7 item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/girl.png"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "8 item", Description="This is an 8 item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/girl.png"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "9 item", Description="This is an 9 item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/girl.png"}
                

            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<List<Item>> GetItemsAsyncList(bool forceRefresh = false)
        {
            return items.AsEnumerable().ToList();
        }
    }
}
