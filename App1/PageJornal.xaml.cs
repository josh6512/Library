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
using storeBook;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageJornal : Page
    {
        ListManger _listManger;
        ObservableCollection<Journal> _journals;
        bool _removeflag;
        GenerJournal _GenerJournal;
        public PageJornal()
        {
            this.InitializeComponent();
        }
        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {

            if (!int.TryParse(priceBox.Text, out int price) || nameBox.Text == "" || ISBNBox.Text == "" || GenerComboBox is null)
            {
                Message();
                return;
            }

            ComboBox comboBox = GenerComboBox as ComboBox;
            ComboBoxItem comboBoxItem = comboBox.SelectedItem as ComboBoxItem;

            GenerJournal genersSelected = GenerJournal.unnon;
            switch (comboBoxItem.Content)
            {
                case "business":
                    genersSelected = GenerJournal.business;
                    break;
                case "kids":
                    genersSelected = GenerJournal.kids;
                    break;
                case "woman":
                    genersSelected = GenerJournal.woman;
                    break;
                case "man":
                    genersSelected = GenerJournal.man;
                    break;
                case "unnon":
                    genersSelected = GenerJournal.unnon;
                    break;
                default:
                    break;
            }

            _journals.Add(new Journal("k", 0, "u") { name = nameBox.Text, price = price, ISBN = ISBNBox.Text, _generJournal= genersSelected });

            nameBox.Text = "";
            priceBox.Text = "";
            ISBNBox.Text = "";
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _listManger = e.Parameter as ListManger;
            _journals = new ObservableCollection<Journal>(_listManger.GetAllJourenals());
            lijournal.ItemsSource = _journals;
            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            
            _listManger.SaveToStock(_journals, _removeflag);
            base.OnNavigatingFrom(e);
        }

        private void GoToBooks(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage),_listManger);
        }

        public async void Message()
        {

            ContentDialog dialog = new ContentDialog
            {

                Title = " One or more of the fields are incomplete",
                Content = "You must fill in the fields:\n Journal name, ISBN, price ",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await dialog.ShowAsync();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
           Journal journalToReemove = lijournal.SelectedItem as Journal;
            if (journalToReemove == null)
            {
                Massgeremove();
            }
            _journals.Remove(lijournal.SelectedItem as Journal);
            _listManger.RemoveFromStock(journalToReemove);
            _removeflag = true;
        }


        private void GenerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Buy_Button(object sender, RoutedEventArgs e)
        {
            Journal journalToReemove = lijournal.SelectedItem as Journal;
            if (journalToReemove == null)
            {
                MassgeBuy();
            }
            _journals.Remove(lijournal.SelectedItem as Journal);
            _listManger.RemoveFromStock2(journalToReemove);
            _removeflag = true;
        }
        private async void Massgeremove()
        {
            ContentDialog _content = new ContentDialog
            {
                Title = " No jornal selected.",
                Content = "You need select jornal to remove. ",
                CloseButtonText = "OK"
            };
            ContentDialogResult _result = await _content.ShowAsync();


        }
        private async void MassgeBuy()
        {
            ContentDialog _content = new ContentDialog
            {
                Title = " No jornal selected.",
                Content = "You need select jornal to buy. ",
                CloseButtonText = "OK"
            };
            ContentDialogResult _result = await _content.ShowAsync();
        }

    }
}
