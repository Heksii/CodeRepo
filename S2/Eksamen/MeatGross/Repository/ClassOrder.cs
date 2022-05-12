using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Denne class har ansvaret for at holde på verdier om en bestilling som
    /// en bruger har lavet.
    /// </summary>
    public class ClassOrder : ClassNotify
    {
        private ClassApiRates _apiRates;
        private ClassMeat _orderMeat;
        private ClassCustomer _orderCustomer;
        private int _orderWeight;
        private double _orderPriceDKK;
        private double _orderPriceValuta;
        private string _priceDKK;
        private string _priceValuta;

        public ClassOrder(ClassApiRates inApiRates)
        {
            orderMeat = new ClassMeat();
            orderCustomer = new ClassCustomer();
            orderWeight = 0;
            orderPriceDKK = 0;
            orderPriceValuta = 0;
            apiRates = inApiRates;
        }

        public ClassApiRates apiRates
        {
            get { return _apiRates; }
            set { _apiRates = value; }
        }
        public string priceValuta
        {
            get { return _priceValuta; }
            set
            {
                if (_priceValuta != value)
                {
                    _priceValuta = value;
                }
                Notify("priceValuta");
            }
        }
        public string priceDKK
        {
            get { return _priceDKK; }
            set
            {
                if (_priceDKK != value)
                {
                    _priceDKK = value;
                }
                Notify("priceDKK");
            }
        }
        public double orderPriceValuta
        {
            get { return _orderPriceValuta; }
            set
            {
                if (_orderPriceValuta != value)
                {
                    _orderPriceValuta = value;
                }
                Notify("orderPriceValuta");
            }
        }
        public double orderPriceDKK
        {
            get { return _orderPriceDKK; }
            set
            {
                if (_orderPriceDKK != value)
                {
                    _orderPriceDKK = value;
                }
                Notify("orderPriceDKK");
            }
        }
        public int orderWeight
        {
            get { return _orderWeight; }
            set
            {
                if (_orderWeight != value)
                {
                    // Hvis der ikke er valgt en kød type,
                    // eller hvis den indtastede verdi er mere end der er på lager, så sæt ikke verdien af fieldet
                    if (int.TryParse(orderMeat.stock, out int x) && value <= Convert.ToInt32(orderMeat.stock))
                    {
                        _orderWeight = value;
                    }
                    
                    CalculateAllPrices();
                }
                Notify("orderWeight");
            }
        }
        public ClassCustomer orderCustomer
        {
            get { return _orderCustomer; }
            set
            {
                if (_orderCustomer != value)
                {
                    _orderCustomer = value;
                    CalculateAllPrices();
                }
                Notify("orderCustomer");
            }
        }
        public ClassMeat orderMeat
        {
            get { return _orderMeat; }
            set
            {
                if (_orderMeat != value)
                {
                    _orderMeat = value;
                    CalculateAllPrices();
                }
                Notify("orderMeat");
            }
        }
    
        private void CalculateAllPrices()
        {
            if (orderCustomer == null) return;
            if (apiRates == null) return;

            double dkkKurs = apiRates.Rates["DKK"]; 

            orderPriceDKK = orderMeat.pricePerKG * orderWeight;
            orderPriceValuta = orderMeat.pricePerKG * orderWeight * (orderCustomer.country.valutaRate / dkkKurs);

            priceDKK = orderPriceDKK.ToString("##0.0000");
            priceValuta = orderPriceValuta.ToString("##0.0000");
        }
    }
}
