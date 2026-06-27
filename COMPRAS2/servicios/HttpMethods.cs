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

        public static string url = "https://avsinventoryswagger25.azurewebsites.net/api/v1/";

        //static HttpClient client = new HttpClient();
        public static async Task<StatusMessage> Post(string url, string objeto)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var stringcontent = new StringContent(objeto, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(url, stringcontent);
                    var estado = await result.Content.ReadAsStringAsync();
                    StatusMessage mensaje = new StatusMessage();
                    mensaje.statuscode = (int)result.StatusCode;

                    // Validar que la respuesta sea exitosa y tenga contenido
                    if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(estado))
                    {
                        mensaje.message = result.ReasonPhrase ?? "Error en la solicitud";
                        return mensaje;
                    }

                    Dictionary<string, object> htmlAttributes = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(estado, new Dictionary<string, object>());

                    // Validar que la deserialización fue exitosa
                    if (htmlAttributes == null)
                    {
                        mensaje.message = "Error al procesar la respuesta del servidor";
                        return mensaje;
                    }

                    if (htmlAttributes.ContainsKey("message"))
                    {
                        mensaje.message = htmlAttributes["message"].ToString();
                    }

                    if (htmlAttributes.ContainsKey("data"))
                    {
                        if (htmlAttributes.TryGetValue("data", out var name))
                        {
                            var valueAsString = name?.ToString();
                            htmlAttributes.Add("data2", valueAsString ?? "unknown");
                        }

                        mensaje.data = htmlAttributes["data2"].ToString();
                    }

                    return mensaje;
                }

            }
            catch (Exception e)
            {
                StatusMessage statusmessage = new StatusMessage();
                statusmessage.statuscode = 500;
                statusmessage.message = e.Message;
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
                    statusmessage.statuscode = (int)response.StatusCode;

                    // Validar que la respuesta sea exitosa y tenga contenido
                    if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(stringres))
                    {
                        statusmessage.message = response.ReasonPhrase ?? "Error en la solicitud";
                        return statusmessage;
                    }

                    Dictionary<string, object> htmlAttributes = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(stringres, new Dictionary<string, object>());

                    // Validar que la deserialización fue exitosa
                    if (htmlAttributes == null)
                    {
                        statusmessage.message = "Error al procesar la respuesta del servidor";
                        return statusmessage;
                    }

                    if (htmlAttributes.ContainsKey("message"))
                    {
                        statusmessage.message = htmlAttributes["message"].ToString();
                    }

                    if (htmlAttributes.ContainsKey("data"))
                    {
                        if (htmlAttributes.TryGetValue("data", out var name))
                        {
                            var valueAsString = name?.ToString();
                            htmlAttributes.Add("data2", valueAsString ?? "unknown");
                        }

                        statusmessage.data = htmlAttributes["data2"].ToString();
                    }
                    else if (htmlAttributes.ContainsKey("data2"))
                    {
                        statusmessage.data = htmlAttributes["data2"].ToString();
                    }

                    return statusmessage;
                }

            }
            catch (Exception e)
            {
                StatusMessage statusmessage = new StatusMessage();
                statusmessage.statuscode = 500;
                statusmessage.message = e.Message;
                return statusmessage;
            }

        }

        public static async Task<StatusMessage> get(string path,string value)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("value", value);
                    var response = await client.GetAsync(path);

                    var stringres = await response.Content.ReadAsStringAsync();

                    StatusMessage statusmessage = new StatusMessage();
                    statusmessage.statuscode = (int)response.StatusCode;

                    // Validar que la respuesta sea exitosa y tenga contenido
                    if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(stringres))
                    {
                        statusmessage.message = response.ReasonPhrase ?? "Error en la solicitud";
                        return statusmessage;
                    }

                    Dictionary<string, object> htmlAttributes = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(stringres, new Dictionary<string, object>());

                    // Validar que la deserialización fue exitosa
                    if (htmlAttributes == null)
                    {
                        statusmessage.message = "Error al procesar la respuesta del servidor";
                        return statusmessage;
                    }

                    if (htmlAttributes.ContainsKey("message"))
                    {
                        statusmessage.message = htmlAttributes["message"].ToString();
                    }

                    if (htmlAttributes.ContainsKey("data"))
                    {
                        if (htmlAttributes.TryGetValue("data", out var name))
                        {
                            var valueAsString = name?.ToString();
                            htmlAttributes.Add("data2", valueAsString ?? "unknown");
                        }

                        statusmessage.data = htmlAttributes["data2"].ToString();
                    }
                    else if (htmlAttributes.ContainsKey("data2"))
                    {
                        statusmessage.data = htmlAttributes["data2"].ToString();
                    }

                    return statusmessage;
                }

            }
            catch (Exception e)
            {
                StatusMessage statusmessage = new StatusMessage();
                statusmessage.statuscode = 500;
                statusmessage.message = e.Message;
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
                    statusmessage.statuscode = (int)response.StatusCode;

                    // Validar que la respuesta sea exitosa y tenga contenido
                    if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(estado))
                    {
                        statusmessage.message = response.ReasonPhrase ?? "Error en la solicitud";
                        return statusmessage;
                    }

                    Dictionary<string, object> htmlAttributes = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(estado, new Dictionary<string, object>());

                    // Validar que la deserialización fue exitosa
                    if (htmlAttributes == null)
                    {
                        statusmessage.message = "Error al procesar la respuesta del servidor";
                        return statusmessage;
                    }

                    if (htmlAttributes.ContainsKey("message"))
                    {
                        statusmessage.message = htmlAttributes["message"].ToString();
                    }

                    if (htmlAttributes.ContainsKey("data"))
                    {
                        if (htmlAttributes.TryGetValue("data", out var name))
                        {
                            var valueAsString = name?.ToString();
                            htmlAttributes.Add("data2", valueAsString ?? "unknown");
                        }

                        statusmessage.data = htmlAttributes["data2"].ToString();
                    }
                    else if (htmlAttributes.ContainsKey("data2"))
                    {
                        statusmessage.data = htmlAttributes["data2"].ToString();
                    }

                    return statusmessage;
                }


            }
            catch (Exception ex)
            {
                StatusMessage statusmessage = new StatusMessage();
                statusmessage.statuscode = 500;
                statusmessage.message = ex.Message;
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
                    statusmessage.statuscode = (int)response.StatusCode;

                    // Validar que la respuesta sea exitosa y tenga contenido
                    if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(estado))
                    {
                        statusmessage.message = response.ReasonPhrase ?? "Error en la solicitud";
                        return statusmessage;
                    }

                    Dictionary<string, object> htmlAttributes = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(estado, new Dictionary<string, object>());

                    // Validar que la deserialización fue exitosa
                    if (htmlAttributes == null)
                    {
                        statusmessage.message = "Error al procesar la respuesta del servidor";
                        return statusmessage;
                    }

                    if (htmlAttributes.ContainsKey("message"))
                    {
                        statusmessage.message = htmlAttributes["message"].ToString();
                    }

                    if (htmlAttributes.ContainsKey("data"))
                    {
                        if (htmlAttributes.TryGetValue("data", out var name))
                        {
                            var valueAsString = name?.ToString();
                            htmlAttributes.Add("data2", valueAsString ?? "unknown");
                        }

                        statusmessage.data = htmlAttributes["data2"].ToString();
                    }
                    else if (htmlAttributes.ContainsKey("data2"))
                    {
                        statusmessage.data = htmlAttributes["data2"].ToString();
                    }

                    return statusmessage;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                StatusMessage statusmessage = new StatusMessage();
                statusmessage.statuscode = 500;
                statusmessage.message = e.Message;
                return statusmessage;
            }


        }

    }
}
