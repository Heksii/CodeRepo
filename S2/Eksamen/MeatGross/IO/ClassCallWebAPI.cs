using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Repository;

namespace IO
{

    public class ClassCallWebAPI
    {
        public ClassCallWebAPI()
        {
            
        }

        public async Task<ClassApiRates> GetRatesFromWebApi()
        {
            ClassApiRates res = new ClassApiRates();

            string jsonResult = await GetURLContentAsync(@"https://openexchangerates.org/api/latest.json?app_id=2cb05a5bf7804828b118ddd3e58a2e60&base=DKK");
            res = JsonConvert.DeserializeObject<ClassApiRates>(jsonResult);

            return res;
        }

        private async Task<string> GetURLContentAsync(string URL)
        {
            string res = "";

            MemoryStream content = new MemoryStream();
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(URL);

            try
            {
                using (WebResponse response = await webReq.GetResponseAsync())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        await responseStream.CopyToAsync(content);
                    }
                }

                res = Encoding.UTF8.GetString(content.ToArray());
            }
            catch (IOException ex)
            {
                throw ex;
            }
            finally
            {
                content.Close();
            }

            return res;
        }


    }
}
