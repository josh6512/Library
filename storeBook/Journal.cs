using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace storeBook
{

    public class Journal : AbstractIteam, IComparable<Journal>, INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    
        public string ISBN { get; set; }
        public GenerJournal _generJournal { get; set; }
        public Journal(string name, int price, string isbn) : base(name, price)
        {
            ISBN = isbn;

        }

        int IComparable<Journal>.CompareTo(Journal other)
        {
            return name.CompareTo(other.name);
        }

        public override bool Equals(object obj)
        {
            return obj is Journal journal &&
                   ISBN == journal.ISBN;
        }

        public override int GetHashCode()
        {
            return 324950537 + EqualityComparer<string>.Default.GetHashCode(ISBN);
        }
    }
}
