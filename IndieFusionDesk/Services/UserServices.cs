using IndieFusionDesk.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace IndieFusionDesk.Services
{
    public class UserServices
    {
        //Login
        public async static Task<UserResponse> Login(UserLogin login)
        {
            UserResponse userResponse = null;
            var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(endpoint);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync("User/Login", login);
            if (response.IsSuccessStatusCode)
            {
                userResponse = JsonConvert.DeserializeObject<UserResponse>(await response.Content.ReadAsStringAsync());

            }
            return userResponse;
        }

        //ListUser
        public async static Task<List<User>> GetUser()
        {
            List<User> users = new List<User>();
            try
            {
                var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(endpoint);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSession.Token);
                client.Timeout = new TimeSpan(0, 0, 30);

                HttpResponseMessage response = await client.GetAsync("User");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(content);
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


        public async Task<List<UserType>> GetUserTypes()
        {
            List<UserType> userTypes = new List<UserType>();

            try
            {
                var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(endpoint);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSession.Token);

                HttpResponseMessage response = await client.GetAsync("User/GetUserTypes");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    userTypes = JsonConvert.DeserializeObject<List<UserType>>(json);
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao buscar tipos de usuário: {response.StatusCode} - {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter tipos de usuário: {ex.Message}");
            }

            return userTypes;
        }


        //Filter
        public async static Task<List<User>> GetFilterUser(string description)
        {
            List<User> users = new List<User>();
            try
            {
                var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(endpoint);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSession.Token);
                    client.Timeout = new TimeSpan(0, 0, 30);

                    // Chama o endpoint usando o parâmetro "description"
                    HttpResponseMessage response = await client.GetAsync($"User/FilterByTypeUser?description={description}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<List<User>>(content);
                    }
                    else
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(content);
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro!! {ex.Message}");
            }
        }


        //Create User
        public async static Task<bool> PostUser(User user, string imagePath = null)
        {
            bool result = false;
            try
            {
                var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(endpoint),
                    Timeout = new TimeSpan(0, 0, 30)
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSession.Token);

                using (var form = new MultipartFormDataContent())
                {
                    form.Add(new StringContent(user.Name), "Name");
                    form.Add(new StringContent(user.NickName), "NickName");
                    form.Add(new StringContent(user.Email), "Email");
                    form.Add(new StringContent(user.Password), "Password");
                    form.Add(new StringContent(user.BirthDate.ToString("yyyy-MM-dd")), "BirthDate");
                    form.Add(new StringContent(user.UserTp.ToString()), "UserTp");

                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        var imageBytes = File.ReadAllBytes(imagePath);
                        var imageContent = new ByteArrayContent(imageBytes);
                        imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                        form.Add(imageContent, "imageFile", Path.GetFileName(imagePath));
                    }

                    // Certifique-se de que a URL corresponde à rota [HttpPost("Create")] do controller
                    HttpResponseMessage response = await client.PostAsync("User/Create", form);
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        result = true;
                        MessageBox.Show(content);
                    }
                    else
                    {
                        MessageBox.Show(content);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro!! {ex.Message}");
            }
        }



        //Update User
        public async static Task<bool> PutUser(User user, string imagePath = null)
        {
            bool result = false;
            try
            {
                // Obtém o endpoint configurado (ex: "http://localhost:5000/api/")
                var endpoint = Program.Configuration.GetSection("IndieFusionFinalContext:Endpoint").Value;
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(endpoint),
                    Timeout = TimeSpan.FromSeconds(30)
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSession.Token);

                using (var form = new MultipartFormDataContent())
                {
                    // Envia o ID para que a API identifique o usuário a ser editado
                    form.Add(new StringContent(user.IdUser.ToString()), "IdUser");
                    form.Add(new StringContent(user.Name), "Name");
                    form.Add(new StringContent(user.NickName), "NickName");
                    form.Add(new StringContent(user.Email), "Email");
                    form.Add(new StringContent(user.Password), "Password");
                    form.Add(new StringContent(user.BirthDate.ToString("yyyy-MM-dd")), "BirthDate");
                    form.Add(new StringContent(user.UserTp.ToString()), "UserTp");

                    // Se existir uma nova imagem e o arquivo existir, anexa ao formulário
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        var imageBytes = File.ReadAllBytes(imagePath);
                        var imageContent = new ByteArrayContent(imageBytes);
                        imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); // ou "image/png", conforme o caso
                                                                                                   // O nome "imageFile" deve ser igual ao parâmetro da API
                        form.Add(imageContent, "imageFile", Path.GetFileName(imagePath));
                    }

                    // Chama o endpoint de edição (conforme o atributo [HttpPut("Edit")])
                    HttpResponseMessage response = await client.PutAsync("User/Edit", form);
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        result = true;
                        MessageBox.Show(content);
                    }
                    else
                    {
                        MessageBox.Show(content);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar usuário: {ex.Message}");
            }
        }



        //Delete User
        public async static Task<bool> DeleteUser(int IdUser)
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

                HttpResponseMessage response = await client.DeleteAsync($"User/{IdUser}");
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
