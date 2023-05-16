using storeBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Open : Page
    {
        ListManger _listManager;
        public Open()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ListManger lm)
            {
                _listManager = lm;
            }
            else _listManager = new ListManger();
                base.OnNavigatedTo(e);  
        }
        private void GoToJorenal(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PageJornal), _listManager);
        }

        private void GoToBook(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), _listManager);
        }
    }
}
