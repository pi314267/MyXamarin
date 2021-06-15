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
        //private List<Item> repository;
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
                //this.repository = Item;
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

        public async void ExecutePullToRefreshCommand()
        {
            IsBusy = true;

            try
            {
                Item = await DataStore.GetItemsAsyncList(true);

                IsRefreshing = false;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                
            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }
        }

        public void ExecuteLoadMoreCommand()
        {
            IsBusy = true;

            try
            {
                if (Item != null)
                {
                    List<Item> it = new List<Item>(){
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Old item 1", Description="This is an Old item 1 description.", Uri="https://homepages.cae.wisc.edu/~ece533/images/airplane.png" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Old item 2", Description="This is an Old item 2 description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/arctichare.png"}
                    };

                    Item.AddRange(it);


                    IsRefreshing = false;
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }
        }
        #endregion
    }
}
