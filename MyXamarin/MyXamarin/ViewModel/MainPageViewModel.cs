using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MyXamarin.Model;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyXamarin.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private List<Item> item;

        public List<Item> Item
        {
            get { return item; }
            set
            {
                SetProperty(ref item, value);
            }
        }



        bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                SetProperty(ref isRefreshing, value);
            }
        }

        public string Uri { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        Item selectedContact;
        public Item SelectedContact
        {
            get { return selectedContact; }
            set
            {
                if (selectedContact != value)
                {
                    selectedContact = value;
                }
            }
        }

        #region Getter Fuction
        public ICommand PageAppearingCommand { protected set; get; }
        public ICommand PullToRefreshCommand { protected set; get; }
        public ICommand LoadMoreCommand { protected set; get; }
        public MainPageViewModel()
        {
            PageAppearingCommand = new Command(PageAppearing);
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
            LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        }

        private async void PageAppearing(object obj)
        {
            IsBusy = true;
            try
            {
                
                Item = await DataStore.GetItemsAsyncList(true);

                //IsRefreshing = false;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        public void ExecutePullToRefreshCommand()
        {
            IsBusy = true;

            try
            {
                List<Item> it = new List<Item>()
                {
                    new Item { Id = Guid.NewGuid().ToString(), Text = "9 item", Description="This is an 7 item description.", Uri="https://homepages.cae.wisc.edu/~ece533/images/airplane.png" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "10 item", Description="This is an 8 item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/arctichare.png"},
                };

                item.AddRange(it);

                IsRefreshing = false;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void ExecuteLoadMoreCommand()
        {
            IsBusy = true;

            try
            {
                List<Item> it = new List<Item>()
                {
                    new Item { Id = Guid.NewGuid().ToString(), Text = "7 item", Description="This is an 7 item description.", Uri="https://homepages.cae.wisc.edu/~ece533/images/airplane.png" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "8 item", Description="This is an 8 item description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/arctichare.png"},
                };

                item.AddRange(it);

                IsRefreshing = false;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
