using IndieFusionDesk.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IndieFusionDesk.Services
{
    public class UserTypeServices
    {
        //ListUserType
        public async static Task<List<UserType>> GetUserType()
        {
            List<UserType> users = new List<UserType>();
            try
            {
                var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(endpoint);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSession.Token);
                client.Timeout = new TimeSpan(0, 0, 30);

                HttpResponseMessage response = await client.GetAsync("UserType");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<UserType>>(content);
                }
                else
                {
                    string content = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(content);
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro!! {ex.Message}");
            }
        }

        //Create UserType
        public async static Task<bool> PostUserType(UserType userType)
        {
            bool result = false;
            try
            {
                var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(endpoint);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSession.Token);

                //Tempo de Resposta do Servidor (h, m, s)
                client.Timeout = new TimeSpan(0, 0, 30);

                //Serializando objeto
                var json = JsonConvert.SerializeObject(userType);
                var contentUserType = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("UserType", contentUserType);
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                    var content = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(content);
                }
                else
                {
                    //Pega o codigo retornado pela api
                    var content = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(content);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro!! {ex.Message}");
            }
        }

        //Update UserType
        public async static Task<bool> PutUserType(UserType userType)
        {
            try
            {
                var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(endpoint);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSession.Token);
                    client.Timeout = TimeSpan.FromSeconds(30);

                    var json = JsonConvert.SerializeObject(userType);
                    var contentUserType = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync("UserType", contentUserType);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(content);
                        return true;
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(content);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar usuário: {ex.Message}");
                return false;
            }
        }


        //Delete UserType
        public async static Task<bool> DeleteUserType(int IdUserType)
        {
            try
            {
                bool result = false;
                var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(endpoint);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSession.Token);

                //Tempo de Resposta do Servidor (h, m, s)
                client.Timeout = new TimeSpan(0, 0, 30);

                HttpResponseMessage response = await client.DeleteAsync($"UserType/{IdUserType}");
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                    var content = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(content);
                }
                else
                {
                    //Pega o codigo retornado pela api
                    var content = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(content);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro!! {ex.Message}");
            }
        }
    }
}
