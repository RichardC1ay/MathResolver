using MathResolver.Math;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathResolver.Pages
{
    /// <summary>
    /// Interaction logic for BinomialExpansionPage.xaml
    /// </summary>
    public partial class BinomialExpansionPage : Page
    {
        public BinomialExpansionPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var inputText = Input.Text;
            if (string.IsNullOrWhiteSpace(inputText))
                return;
            //var bi = MathResolverCollection.GetBinomial(inputText);
            var bi = new Binomial(inputText);
            if(bi != null)
            {
                Output.Text = Binomial.GetExpansion(bi).ToString();
            }
        }
    }
}
