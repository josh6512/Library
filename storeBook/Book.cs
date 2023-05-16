using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace storeBook
{
    public class Book : AbstractIteam, IComparable<Book>, INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;

        public static int counter;
        public GenerBook _generBook { get; set; }
        public int stoke { get; set; }
        public string AuthorName { get; set; }
        public static int Counter
        {
            get { return counter; }
        }

        public Book(string name, int price, string authorName,int st  ) : base(name, price)
        {
            stoke = st;
            
            AuthorName = authorName;

            counter++;
        }
    
        public int CompareTo(Book other)
        {
            return name.CompareTo(other.name);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                name.Equals(book.name);
        }

    } 
   
}
