using System;
using System.Collections.Generic;
using System.Text;

namespace MathResolver.Math
{
    public class Polynomial
    {
        public List<MathItem> Items { get; set; }

        public Polynomial()
        {
            Items = new List<MathItem>();
        }

        public override string ToString()
        {
            string str = "";
            foreach (var item in Items)
                if (item.Nums > 0)
                    str += "+" + item;
                else
                    str += item;
            return str;
        }
    }
}
