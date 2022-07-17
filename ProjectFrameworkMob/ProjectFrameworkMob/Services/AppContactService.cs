using Newtonsoft.Json;
using ProjectFrameworkCommonLib;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFrameworkMob.Services
{
    public partial class AppApiService
    {
        public async Task<AppContact> GetContactInfo()
        {
            AppContact Contact = new AppContact();
            
            try
            {
                var requestTask = await AppServiceClient.GetAsync("api/Contact/GetContactInfo");
                var response = Task.Run(() => requestTask);
                Task<string> ResponseData;
                if (response.Result.IsSuccessStatusCode)
                {
                    ResponseData = response.Result.Content.ReadAsStringAsync();

                    Contact = JsonConvert.DeserializeObject<AppContact>(ResponseData.Result);

                }
                else
                {
                    ResponseData = response.Result.Content.ReadAsStringAsync();
                    throw new Exception(ResponseData.Result);
                }
                return Contact;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        public async Task<bool> UpdateContactInfo(AppContact Contact)
        {
            bool bResult = false;
            try
            {
                var serializedItem = JsonConvert.SerializeObject(Contact);
                string Paramters = "api/Contact/UpdateContactInfo";
                var requestTask = await AppServiceClient.PostAsync(Paramters, new StringContent(serializedItem, Encoding.UTF8, "application/json"));
                var response = Task.Run(() => requestTask);
                Task<string> ResponseData;
                if (response.Result.IsSuccessStatusCode)
                {
                    bResult = true;

                }
                else
                {
                    ResponseData = response.Result.Content.ReadAsStringAsync();
                    throw new Exception(ResponseData.Result);
                }
                return bResult;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
