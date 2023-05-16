using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace storeBook
{

    public class ListManger
    {
        List<AbstractIteam> _stock;
        private static string _logFileName;
        public static AbstractIteam[] defaultItems =
            {
               new Book("wer", 12, "j",4) { name = "Philosopher's Stone", AuthorName = " J. K. Rowling ", price = 10, _data = Convert.ToDateTime("1/4/1998") ,stoke=10},
                new Book("wer", 12, "J",4) { name = "pinocchio", AuthorName = "Carlo Collodi", price = 11, _data = Convert.ToDateTime("1/4/1998"),stoke=10},
               new Book("wer", 12, "J",4) { name = "piter pan", AuthorName = "J. M. Barrie", price = 5, _data = Convert.ToDateTime("1/4/1998") ,stoke=10},

              new Journal("wer", 12, "f") { name = "jerosalm post", ISBN = "123-345-HJ", price = 12 },
                new Journal("wer", 12, "f") { name = " israelian", ISBN = "123-346-HJ", price = 12 },
                new Journal("wer", 12, "h") { name = "yediot aharonot", ISBN = "123-347-HJ", price = 12 }
        };
        public Book[] GetAllBooks()
        {
            List<Book> temp = new List<Book>();
            foreach (AbstractIteam item in _stock)
            {
                if (item is Book bk)
                {
                    temp.Add(bk);
                }

            }
            return temp.ToArray();
        }

        public Journal[] GetAllJourenals()
        {
            List<Journal> temp = new List<Journal>();
            foreach (AbstractIteam item in _stock)
            {
                if (item is Journal journal)
                {
                    temp.Add(journal);
                }
            }
            return temp.ToArray();
        }

        public void SaveToStock(IEnumerable<AbstractIteam> iteams, bool remove = false)
        {
            if (remove)
                RemoveFromStock(iteams);

            AddToStock(iteams);
        }


        public void AddToStock(IEnumerable<AbstractIteam> iteams)
        {
            foreach (AbstractIteam iteam in iteams)
            {
                if (!_stock.Contains(iteam))
                {
                    _stock.Add(iteam);
                }
            }
        }



        public void RemoveFromStock2(AbstractIteam item)
        {
            if (_stock.Contains(item))
            {
                _stock.Remove(item);
                Messagebuy();
            }
        }

        public void RemoveFromStock(AbstractIteam item)
        {
            if (_stock.Contains(item))
            {
                _stock.Remove(item);
            }
        }
        public void RemoveFromStock(IEnumerable<AbstractIteam> iteams)
        {


            foreach (var iteam in iteams)
            {
                if (_stock.Contains(iteam))
                {
                    _stock.Remove(iteam);
                }
            }

        }


        public ListManger()
        {
            _stock = new List<AbstractIteam>(defaultItems);
            _logFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "myLog.txt");
        }

        public async void Messagebuy()
        {

            ContentDialog dialog = new ContentDialog
            {

                Title = " thnk you fot buy",
                CloseButtonText = "OK"
            };
            ContentDialogResult result4 = await dialog.ShowAsync();
        }

        public static void ErrorLgger(string massge)
        {

            // File.AppendAllText(_logFileName, $"[{DateTime.Now}]\t[{logMessage}]\n");
        }

      
    }    
}
