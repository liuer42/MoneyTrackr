using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyTycoon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            var browser = new WebView();
            browser.Source = "https://www.investor.gov/financial-tools-calculators/calculators/compound-interest-calculator";
            Content = browser;
        }
    }
}