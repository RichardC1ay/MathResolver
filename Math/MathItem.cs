using System;
using System.Collections.Generic;
using System.Text;

namespace MathResolver.Math
{
    public class MathItem
    {
        public int coef = 1;
        public int num;
        public Dictionary<char, int> unk;
        public int Nums { get { return coef * num; } }

        public MathItem()
        {
            unk = new Dictionary<char, int>();
        }

        public override string ToString()
        {
            string str = "";
            str += Nums;
            
            if (unk != null)
                foreach (var item in unk)
                    if(item.Value > 0)
                        str += item.Key + "^" + item.Value;
            return str;
        }

        public static int NumAndIndex(int num, int index)
        {
            if (index == 0)
                return 1;

            int sum = 1;
            for (int l = 0; l < index; l++)
                sum *= num;
            return sum;
        }
    }
}
