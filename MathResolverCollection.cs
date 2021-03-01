using MathResolver.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathResolver
{
    public class MathResolverCollection
    {
        public static Binomial GetBinomial(string expression)
        {
            if (Binomial.BinomialMatcher.Match(expression).Success)
                return new Binomial(expression);
            else
                return null;
        }
    }
}
