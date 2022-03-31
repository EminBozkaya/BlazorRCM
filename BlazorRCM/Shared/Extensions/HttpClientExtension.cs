using BlazorRCM.Shared.CustomExceptions;
using BlazorRCM.Shared.ResponseModels;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorRCM.Shared.Extensions
{
    public static class HttpClientExtension
    {
        //public async static Task<TResult> PostGetServiceResponseAsync<TResult>(this HttpClient Client, String Url, FiltersAndIncludesModel<typeof(TResult)> Value, bool ThrowSuccessException = false)
        //{
        //    var httpRes = await Client.PostAsJsonAsync(Url, Value);

        //    //if (httpRes.IsSuccessStatusCode)
        //    //{
        //    var res = await httpRes.Content.ReadFromJsonAsync<ServiceResponse<TResult>>();

        //    return !res!.Success && ThrowSuccessException ? throw new ApiException(res.Message!) : res.Value!;
        //    //}

        //    throw new HttpException(httpRes.StatusCode.ToString());
        //}

        public async static Task<TResult> PostGetServiceResponseAsync<TResult, TValue>(this HttpClient Client, String Url, TValue Value, bool ThrowSuccessException = false)
        {
            HttpResponseMessage httpRes = new();
            
                httpRes = await Client.PostAsJsonAsync(Url, Value);

            //if (httpRes.IsSuccessStatusCode)
            //{
            var res = await httpRes.Content.ReadFromJsonAsync<ServiceResponse<TResult>>();

            return !res!.Success && ThrowSuccessException ? throw new ApiException(res.Message!) : res.Value!;
            //}

            throw new HttpException(httpRes.StatusCode.ToString());
        }

        public async static Task<BaseResponse> PostGetBaseResponseAsync<TValue>(this HttpClient Client, String Url, TValue Value, bool ThrowSuccessException = false)
        {
            var httpRes = await Client.PostAsJsonAsync(Url, Value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<BaseResponse>();

                return !res!.Success && ThrowSuccessException ? throw new ApiException(res.Message!) : res;
            }

            throw new HttpException(httpRes.StatusCode.ToString());
        }

        public async static Task<T> GetServiceResponseAsync<T>(this HttpClient Client, String Url, bool ThrowSuccessException = false)
        {
            
            var httpRes = await Client.GetFromJsonAsync<ServiceResponse<T>>(Url);

            return !httpRes!.Success && ThrowSuccessException ? throw new ApiException(httpRes.Message!) : httpRes.Value!;
        }
        
    }
}