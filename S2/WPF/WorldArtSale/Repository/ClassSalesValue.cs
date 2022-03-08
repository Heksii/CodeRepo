using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassSalesValue : ClassNotify
    {
        private string _bidUSD;
        private string _bidEUR;
        private string _bidOwnValuta;
        private string _priceWithFeeUSD;
        private string _priceWithFeeEUR;
        private string _priceWithFeeOwnValuta;
        private ClassCurrency _classCurrency;

        public ClassSalesValue()
        {
            bidUSD = "";
            bidEUR = "";
            bidOwnValuta = "";
            priceWithFeeUSD = "";
            priceWithFeeEUR = "";
            priceWithFeeOwnValuta = "";
            customerValutaCode = "USD";

            classCurrency = new ClassCurrency();
        }
        public string customerValutaCode { get; set; }

        public ClassCurrency classCurrency
        {
            get { return _classCurrency; }
            set
            {
                if (_classCurrency != value)
                {
                    _classCurrency = value;
                }
                Notify("classCurrency");
            }
        }
        public string priceWithFeeOwnValuta
        {
            get { return _priceWithFeeOwnValuta; }
            set
            {
                if (_priceWithFeeOwnValuta != value)
                {
                    _priceWithFeeOwnValuta = value;
                }
                Notify("priceWithFeeOwnValuta");
            }
        }
        public string priceWithFeeEUR
        {
            get { return _priceWithFeeEUR; }
            set
            {
                if (_priceWithFeeEUR != value)
                {
                    _priceWithFeeEUR = value;
                }
                Notify("priceWithFeeEUR");
            }
        }
        public string priceWithFeeUSD
        {
            get { return _priceWithFeeUSD; }
            set
            {
                if (_priceWithFeeUSD != value)
                {
                    _priceWithFeeUSD = value;
                }
                Notify("priceWithFeeUSD");
            }
        }
        public string bidOwnValuta
        {
            get { return _bidOwnValuta; }
            set
            {
                if (_bidOwnValuta != value)
                {
                    _bidOwnValuta = value;
                }
                Notify("bidOwnValuta");
            }
        }
        public string bidEUR
        {
            get { return _bidEUR; }
            set
            {
                if (_bidEUR != value)
                {
                    _bidEUR = value;
                }
                Notify("bidEUR");
            }
        }
        public string bidUSD
        {
            get { return _bidUSD; }
            set
            {
                if (_bidUSD != value)
                {
                    if (double.TryParse(value, out double x))
                    {
                        _bidUSD = value;
                        SetBidOnArt();
                    }
                }
                Notify("bidUSD");
            }
        }

        public void SetBidOnArt()
        {
            decimal.TryParse(bidUSD, out decimal decimalBidUSD);
            decimal EURKurs = classCurrency.rates["EUR"];
            decimal ownValutaKurs = classCurrency.rates[customerValutaCode];

            bidEUR = (EURKurs * decimalBidUSD).ToString("##0.0000");
            bidOwnValuta = (ownValutaKurs * decimalBidUSD).ToString("##0.0000");

            priceWithFeeUSD = (decimalBidUSD * 1.05M).ToString("##0.0000");
            priceWithFeeEUR = (Convert.ToDecimal(bidEUR) * 1.05M).ToString("##0.0000");
            priceWithFeeOwnValuta = (Convert.ToDecimal(bidOwnValuta) * 1.05M).ToString("##0.0000");
        }
    }
}
