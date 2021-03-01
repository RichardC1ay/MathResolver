using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MathResolver.Math
{
    public class Binomial
    {
        public static readonly Regex BinomialMatcher = new Regex("[(]-?[0-9]*[a-z]*[+-]-?[0-9]*[a-z][)]^[0-9]{1,3}");
        public static readonly Regex BinomialParser = new Regex("[(]?<first>?<second>[)]^?<index>");
        public string Expression { get; set; }
        public MathItem A { get; set; }
        public MathItem B { get; set; }
        public int Index { get; set; }

        public Binomial(string expression)
        {
            Expression = expression;
            var array = expression.ToCharArray();

            string aN = "";
            char aU = ' ';
            string bN = "";
            char bU = ' ';
            string iN = "";
            bool opPass = false;
            bool over = false;

            for(int l = 0; l < array.Length; l++)
            {
                if (l == 0)
                    continue;
                char c = array[l];

                if (c == '-' && l == 1)
                    aN += c;
                else if (c == '-')
                {
                    opPass = true;
                    bN += c;
                }
                else if (c == '+')
                    opPass = true;
                else if (c == ')')
                    over = true;
                else if (c == '^') //后期更改应使此处可以处理未知数的指数
                    continue;

                if(c >= 47 && c <= 58)
                {
                    if (!over)
                    {
                        if (!opPass)
                            aN += c;
                        else
                            bN += c;
                    }
                    else
                        iN += c;
                }

                if(c >= 97 && c <= 122)
                {
                    if (!opPass)
                        aU = c;
                    else
                        bU = c;
                }
            }

            A = new MathItem { num = int.Parse(aN) };
            if(aU != ' ')
                A.unk.Add(aU, 1);
            B = new MathItem { num = int.Parse(bN) };
            if(bU != ' ')
                B.unk.Add(bU, 1);
            Index = int.Parse(iN);
        }

        public Binomial()
        {
            
        }

        public override string ToString()
        {
            string str = "";
            str += A;
            if (B.Nums > 0)
                str += "+" + B;
            else
                str += B;

            if (Index != 0)
                str = "(" + str + ")^" + Index;
            return str;
        }

        public static Polynomial GetExpansion(Binomial binomial)
        {
            var po = new Polynomial();
            for (int l = 0; l <= binomial.Index; l++)
            {
                int left = binomial.Index - l;
                var item = new MathItem
                {
                    coef = NCR(binomial.Index, l),
                    num = MathItem.NumAndIndex(binomial.A.num, left) * MathItem.NumAndIndex(binomial.B.num, l),
                };

                foreach (var u in binomial.A.unk)
                    item.unk.Add(u.Key, left);
                foreach (var u in binomial.B.unk)
                    item.unk.Add(u.Key, l);

                po.Items.Add(item);
            }
            return po;
        }

        public static int NCR(int n, int r) => F(n) / (F(n - r) * F(r));

        public static int F(int i)
        {
            if (i == 0)
                return 1;

            int sum = 1;
            for (int l = 1; l <= i; l++)
                sum *= l;
            return sum;
        }
    }
}
