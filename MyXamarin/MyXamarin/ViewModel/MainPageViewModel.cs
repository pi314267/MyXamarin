using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MyXamarin.Model;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading;

namespace MyXamarin.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        //ItemData data;

        private List<Item> data;
        //private List<Item> repository;
        //private List<Item> items;

        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                SetProperty(ref items, value);
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

            //this.data = new ItemData();
            //for (int i = 0;i< Items.Count;i++)
            //{
            //    data.Items.Add(items[i]);
            //}

        }

        private async void PageAppearing(object obj)
        {
            IsBusy = true;
            try
            {

                //Items = await DataStore.GetItemsAsyncList(true);
                var t = new ObservableCollection<Item>();
                List<Item> a = await DataStore.GetItemsAsyncList(true);
                a.ForEach(x => t.Add(x));
                Items = t;

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
                var t = new ObservableCollection<Item>();
                List<Item> a = await DataStore.GetItemsAsyncList(true);
                a.ForEach(x => t.Add(x));
                Items = t;

                //Items = a.ForEach(x => Items.Add(x));

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
                if (Items != null)
                {

                    #region AS-IS Source
                    //this.data = new List<Item>();
                    //for (int i = 0; i < Items.Count; i++)
                    //{
                    //    data.Add(Items[i]);
                    //}

                    //List<Item> it = new List<Item>(){
                    //new Item { Id = "001", Text = "Old item 1", Description="This is an Old item 1 description.", Uri="https://homepages.cae.wisc.edu/~ece533/images/airplane.png" },
                    //new Item { Id = "002", Text = "Old item 2", Description="This is an Old item 2 description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/arctichare.png"}
                    //};


                    //for (int i = 0; i < it.Count; i++)
                    //{
                    //    data.Add(it[i]);
                    //}

                    //Items = data;
                    #endregion



                    List<Item> it = new List<Item>(){
                    new Item { Id = "001", Text = "Old item 1", Description="This is an Old item 1 description.", Uri="https://homepages.cae.wisc.edu/~ece533/images/airplane.png" },
                    new Item { Id = "002", Text = "Old item 2", Description="This is an Old item 2 description.", Uri= "https://homepages.cae.wisc.edu/~ece533/images/arctichare.png"}
                    };

                    for (int i = 0; i < it.Count; i++)
                    {
                        Items.Add(it[i]);
                    }
                    

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
