using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo;
using IO;
using Newtonsoft.Json;

namespace BIZ
{
    public class ClassBiz : ClassNotify
    {
        private ClassJSONWebApiCall apiCall = new ClassJSONWebApiCall();
        private ExchangeRates _valuta;
        private string apiURL = "https://openexchangerates.org/api/latest.json?app_id=2cb05a5bf7804828b118ddd3e58a2e60&base=USD";

        public ClassBiz()
        {
            valuta = new ExchangeRates();
        }

        public ExchangeRates valuta
        {
            get { return _valuta; }
            set
            {
                if (_valuta != value)
                {
                    _valuta = value;
                }
                Notify("valuta");
            }
        }

        public async Task StartCurrencyApiCall()
        {
            byte[] urlContent = await apiCall.GetURLContentAsync(apiURL);

            string strJson = Encoding.UTF8.GetString(urlContent);
            valuta = JsonConvert.DeserializeObject<ExchangeRates>(strJson);
        }
    }
}
