using Blazored.LocalStorage;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.DTOs.TupleDTOs;

namespace BlazorRCM.Shared.Extensions
{
    public static class LocalStorageExtension
    {

        //public async static Task<int> GetUserId(this ILocalStorageService LocalStorage)
        //{
        //    return int.Parse(await LocalStorage.GetItemAsStringAsync("activeUserId"));

        //}
        public async static Task<int> GetActiveUserID(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<int>("activeUserId");
        }
        public async static Task<String> GetUserFullName(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsStringAsync("fullname");
        }
        public async static Task<String> GetUserEMail(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsStringAsync("email");
        }
        public async static Task<string> ApiToken(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsStringAsync("token");
        }
        public async static Task<List<BranchDTO>> GetUserBranches(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<List<BranchDTO>>("userBranches");
        }
        public async static Task<List<short>> GetUserAuthorityTypeIDs(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<List<short>>("userAuthorityTypeIds");
        }
        public async static Task<List<short>> GetUserBranchIDs(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<List<short>>("userBranchIds");
        }
        public async static Task<List<string>> GetUserBranchNames(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<List<string>>("userBranchNames");
        }
        public async static Task<short> GetActiveBranchID(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<short>("activeBranchId");
        }
        public async static Task<string> GetActiveBranchName(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<string>("activeBranchName");
        }
        public async static Task<short> GetActiveAuthorityTypeID(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<short>("activeAuthorityTypeId");
        }


        public async static Task<List<BranchProductPriceDTO>> BranchProductPriceList(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<List<BranchProductPriceDTO>>("activeBranchProductPriceList");
        }
        public async static Task<List<ProductSaleNoteDTO>> ProductSaleNoteList(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<List<ProductSaleNoteDTO>>("ProductSaleNoteList");
        }

        

        public async static Task<PassBillDataToChangeBillPageDTO> GetBillDataForChange(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<PassBillDataToChangeBillPageDTO>("billDataForChange");
        }
    }
}
