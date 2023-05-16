using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeBook
{
    public abstract class AbstractIteam
    {
        public string name { get; set; }
        public int price { get; set; }
        public DateTime _data { get; set; }


        public AbstractIteam(string Name, int Price)
        {
            name = Name;
            price = Price;
            //    _data = data;
        }

        public int CompareTo(object obj)
        {
            Book book = (Book)obj;

            if (name == book.name)
                return 1;


            if (name != book.name)
                return 1;
            return 0;

        }




    }
}
