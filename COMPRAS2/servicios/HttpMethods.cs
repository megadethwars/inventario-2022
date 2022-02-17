using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using COMPRAS2.modelos;

namespace COMPRAS2.servicios
{
    public static class HttpMethods
    {

        public static string url = "https://avsinventoryswagger.azurewebsites.net/api/v1/";

        //static HttpClient client = new HttpClient();
        public static async Task<StatusMessage> Post(string url, string objeto)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var stringcontent = new StringContent(objeto, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(url, stringcontent).Result;
                    var estado = await result.Content.ReadAsStringAsync();
                    StatusMessage mensaje = new StatusMessage();
                    Dictionary<string, object> htmlAttributes = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(estado, new Dictionary<string, object>());

                    mensaje.message = htmlAttributes["message"].ToString();
                    if (htmlAttributes.ContainsKey("data")) {

                        if (htmlAttributes.TryGetValue("data", out var name))
                        {
                            var valueAsString = name?.ToString();
                            htmlAttributes.Add("data2", valueAsString ?? "unknown");
                        }


                        mensaje.data = htmlAttributes["data2"].ToString();
                        
                        
                    }
                    
                    mensaje.statuscode = (int)result.StatusCode;
                    return mensaje;
                }

            }
            catch (Exception e)
            {
                StatusMessage statusmessage = new StatusMessage();
                statusmessage.statuscode = 500;
                return statusmessage;
            }



        }


        public static async Task<StatusMessage> get(string path)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(path);

                    var stringres = await response.Content.ReadAsStringAsync();

                    StatusMessage statusmessage = new StatusMessage();
                    Dictionary<string, object> htmlAttributes = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(stringres, new Dictionary<string, object>());

                    statusmessage.message = htmlAttributes["message"].ToString();
                    if (htmlAttributes.ContainsKey("data"))
                    {

                        if (htmlAttributes.TryGetValue("data", out var name))
                        {
                            var valueAsString = name?.ToString();
                            htmlAttributes.Add("data2", valueAsString ?? "unknown");
                        }


                        statusmessage.data = htmlAttributes["data2"].ToString();


                    }
                    statusmessage.data = htmlAttributes["data2"].ToString();
                    statusmessage.statuscode = (int)response.StatusCode;


                    return statusmessage;
                }


            }
            catch (Exception e)
            {
                StatusMessage statusmessage = new StatusMessage();
                statusmessage.statuscode = 500;
                return statusmessage;
            }



        }



        public static async Task<StatusMessage> put(string url, string objeto)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var stringcontent = new StringContent(objeto, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(url, stringcontent);
                    var estado = await response.Content.ReadAsStringAsync();
                    StatusMessage statusmessage = new StatusMessage();
                    Dictionary<string, object> htmlAttributes = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(estado, new Dictionary<string, object>());

                    statusmessage.message = htmlAttributes["message"].ToString();
                    if (htmlAttributes.ContainsKey("data"))
                    {

                        if (htmlAttributes.TryGetValue("data", out var name))
                        {
                            var valueAsString = name?.ToString();
                            htmlAttributes.Add("data2", valueAsString ?? "unknown");
                        }


                        statusmessage.data = htmlAttributes["data2"].ToString();


                    }
                    statusmessage.data = htmlAttributes["data2"].ToString();
                    statusmessage.statuscode = (int)response.StatusCode;
                    return statusmessage;
                }


            }
            catch (Exception ex)
            {
                StatusMessage statusmessage = new StatusMessage();
                statusmessage.statuscode = 500;
                return statusmessage;
            }


        }




        public static async Task<StatusMessage> delete(string url)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    var estado = await response.Content.ReadAsStringAsync();
                    StatusMessage statusmessage = new StatusMessage();
                    Dictionary<string, object> htmlAttributes = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(estado, new Dictionary<string, object>());

                    statusmessage.message = htmlAttributes["message"].ToString();
                    if (htmlAttributes.ContainsKey("data"))
                    {

                        if (htmlAttributes.TryGetValue("data", out var name))
                        {
                            var valueAsString = name?.ToString();
                            htmlAttributes.Add("data2", valueAsString ?? "unknown");
                        }


                        statusmessage.data = htmlAttributes["data2"].ToString();


                    }
                    statusmessage.data = htmlAttributes["data2"].ToString();
                    statusmessage.statuscode = (int)response.StatusCode;
                    return statusmessage;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                StatusMessage statusmessage = new StatusMessage();
                statusmessage.statuscode = 500;
                return statusmessage;
            }


        }

    }
}
