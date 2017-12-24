using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using XF.AplicativoFIAP.Model;

namespace XF.AplicativoFIAP.Repositorio
{
    public class ProfessorRepositorio
    {
        private const string URL_API_FIAP = "http://apiaplicativofiap.azurewebsites.net/";
        private static List<Professor> professoresSqlAzure;

        public static async Task<List<Professor>> GetProfessoresSqlAzureAsync()
        {
            if (professoresSqlAzure != null) return professoresSqlAzure;

            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync(string.Concat(URL_API_FIAP, "api/professors"));
            var professorSerializer = new DataContractJsonSerializer(typeof(List<Professor>));

            professoresSqlAzure = (List<Professor>)professorSerializer.ReadObject(stream);

            return professoresSqlAzure;
        }

        public static async Task<bool> PostProfessorSqlAzureAsync(Professor profAdd)
        {
            if (profAdd == null) return false;

            var httpRequest = new HttpClient();

            httpRequest.BaseAddress = new Uri(URL_API_FIAP);
            httpRequest.DefaultRequestHeaders.Accept.Clear();
            httpRequest.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string profJson = Newtonsoft.Json.JsonConvert.SerializeObject(profAdd);

            var response = await httpRequest
                .PostAsync("api/professors", new StringContent(profJson, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode) return true;

            return false;
        }

        public static async Task<bool> DeleteProfessorSqlAzureAsync(string profId)
        {
            if (string.IsNullOrWhiteSpace(profId)) return false;

            var httpRequest = new HttpClient();

            httpRequest.BaseAddress = new Uri(URL_API_FIAP);
            httpRequest.DefaultRequestHeaders.Accept.Clear();
            httpRequest.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpRequest.DeleteAsync(string.Format("api/professors/{0}", profId));

            if (response.IsSuccessStatusCode) return true;

            return false;
        }
    }
}
