﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace SpotyClient
{
    class Api
    {
        static HttpClient client = new HttpClient();
        static string server = "http://localhost:36518/api/";
        static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };


        public static async Task<T> GetListAsync<T>(string controller)
        {
            var answer = await client.GetAsync(server + controller);
            string answerText = await answer.Content.ReadAsStringAsync();
            var result = (T)JsonSerializer.Deserialize(answerText, typeof(T), jsonOptions);
            return result;
        }

        public static async Task<T> GetAsync<T>(int id, string controller) where T : ModelsApi.ApiBaseType
        {
            var answer = await client.GetAsync(server + controller + $"/{id}");
            if (answer.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string answerText = await answer.Content.ReadAsStringAsync();
                var result = (T)JsonSerializer.Deserialize(answerText, typeof(T), jsonOptions);
                return result;
            }
            else
            {
                return null;
            }
        }

        public static async Task<int> PostAsync<T>(T value, string controller) where T : ModelsApi.ApiBaseType
        {
            var str = JsonSerializer.Serialize(value, typeof(T));
            var answer = await client.PostAsync(server + controller, new StringContent(str, Encoding.UTF8, "application/json"));
            if (answer.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                MessageBox.Show(str, answer.ToString());
                return -1;
            }
            string answerText = await answer.Content.ReadAsStringAsync();
            if (!int.TryParse(answerText, out int result))
                return -1;
            return result;
        }

        public static async Task<bool> PutAsync<T>(T value, string controller) where T : ModelsApi.ApiBaseType
        {
            var str = JsonSerializer.Serialize(value, typeof(T));
            var answer = await client.PutAsync(server + controller + $"/{value.Id}", new StringContent(str, Encoding.UTF8, "application/json"));
            return answer.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public static async Task<bool> DeleteAsync<T>(T value, string controller) where T : ModelsApi.ApiBaseType
        {
            var answer = await client.DeleteAsync(server + controller + $"/{value.Id}");
            return answer.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
