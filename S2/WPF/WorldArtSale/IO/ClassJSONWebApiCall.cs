using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace IO
{
    public class ClassJSONWebApiCall
    {
        public ClassJSONWebApiCall()
        {
            
        }

        public async Task<string> GetURLContentAsync(string URL)
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
