using Data.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Data.ClientConection
{
    public class UserClient
    {
        private string Base_Url = "http://localhost:52455/api/";

        public List<UserDetailsDTO> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("users").Result;
                if (response.IsSuccessStatusCode)

                    return response.Content.ReadAsAsync<List<UserDetailsDTO>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public UserDetailsDTO find(int? id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("users/" + id).Result;
                if (response.IsSuccessStatusCode)

                    return response.Content.ReadAsAsync<UserDetailsDTO>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public bool Create(UserDetailsDTO user)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("users", user).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        public bool Edit(UserDetailsDTO user)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("users/" + user.Id, user).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(int? id)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("users/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        public UserAccountDto Login(UserAccountDto user)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("postUserAccount", user).Result;
                if (response.IsSuccessStatusCode)

                    return response.Content.ReadAsAsync<UserAccountDto>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Register(UserAccount account)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("account", account).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }




        }

        public bool CheckLogin(UserAccountDto userAccountDto)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("postCheck", userAccountDto).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public File FindFileDetailsDto(int? id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("file/" + id).Result;
                if (response.IsSuccessStatusCode)

                    return response.Content.ReadAsAsync<File>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }

        public bool DeleteFiles(int? id)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("file/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<UsersRole> FindAllUsersRoles()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_Url);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("usersrole").Result;
                if (response.IsSuccessStatusCode)

                    return response.Content.ReadAsAsync<IEnumerable<UsersRole>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        //public bool CreatePath(FilePath photo)
        //{

        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(Base_Url);
        //        client.DefaultRequestHeaders.Accept.Add(
        //            new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage response = client.PostAsJsonAsync("filePath", photo).Result;
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}

        //public FilePath findPath(int? id)
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(Base_Url);
        //        client.DefaultRequestHeaders.Accept.Add(
        //            new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage response = client.GetAsync("users/" + id).Result;
        //        if (response.IsSuccessStatusCode)

        //            return response.Content.ReadAsAsync<FilePath>().Result;
        //        return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}



    }
}