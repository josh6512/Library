using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using storeBook;
using Windows.UI.Popups;


namespace App1
{
    public sealed partial class MainPage : Page
    {
        Book book;
        List<Book> _book = new List<Book>();
        ObservableCollection<Book> _books;
        ListManger _listManger;
        GenerBook _generBook;
        bool _removeFlag;
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {

            if (!int.TryParse(priceBox.Text, out int price) || nameBox.Text == "" || authorBox.Text == "")
            {

                Message();
                return;
            }

            ComboBox comboBox = GenerComboBox as ComboBox;
            ComboBoxItem comboBoxItem = comboBox.SelectedItem as ComboBoxItem;

            GenerBook genersSelecte = GenerBook.action ;
            switch (comboBoxItem.Content)
            {
                case "drama":
                    genersSelecte = GenerBook.drama;
                    break;
                case "kids":
                    genersSelecte = GenerBook.kids;
                    break;
                case "adventure":
                    genersSelecte = GenerBook.adventure;
                    break;
                case "crime":
                    genersSelecte = GenerBook.crime;
                    break;
                case "action":
                    genersSelecte = GenerBook.action;
                    break;
                default:
                    break;
            }

            _books.Add(new Book("q", 1, "G", 1) { name = nameBox.Text, price = price, AuthorName = authorBox.Text, _generBook = genersSelecte }) ;
            nameBox.Text = "";
            priceBox.Text = "";
            authorBox.Text = "";
            GenerComboBox = default;
            //  _books = new ObservableCollection<Book>(_listManger.GetAllBooks());

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _listManger = e.Parameter as ListManger;
            _books = new ObservableCollection<Book>(_listManger.GetAllBooks());
            liBook.ItemsSource = _books;
            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            _listManger.SaveToStock(_books, _removeFlag);
            base.OnNavigatingFrom(e);
        }


        private void GoToJorenal(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PageJornal), _listManger);

        }

        public async void Message()
        {

            ContentDialog dialog = new ContentDialog
            {

                Title = " One or more of the fields are incomplete",
                Content = "You must fill in the fields:\n book name, author name, price ",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await dialog.ShowAsync();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)

        {
            Book bookToReemove = liBook.SelectedItem as Book;
            if (bookToReemove == null)
            {
                Massgeremove();
            }
            _books.Remove(liBook.SelectedItem as Book);
            _listManger.RemoveFromStock(bookToReemove);
            _removeFlag = true;
        }

        //i
        private void buyBtn_Click(object sender, RoutedEventArgs e)
        {
            Book bookToReemove = liBook.SelectedItem as Book;
            if (bookToReemove == null)
            {
                MassgeBuy();
            }
            _books.Remove(liBook.SelectedItem as Book);
            _listManger.RemoveFromStock2(bookToReemove);
            _removeFlag = true;


        }



        private void GenerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private async void Massgeremove()
        {
            ContentDialog _content = new ContentDialog
            {
                Title = " No book selected.",
                Content = "You need select book to remove. ",
                CloseButtonText = "OK"
            };
            ContentDialogResult _result = await _content.ShowAsync();
        }
        private async void MassgeBuy()
        {
            ContentDialog _content = new ContentDialog
            {
                Title = " No book selected.",
                Content = "You need select book to buy. ",
                CloseButtonText = "OK"
            };
            ContentDialogResult _result = await _content.ShowAsync();
        }

      
    }
}
