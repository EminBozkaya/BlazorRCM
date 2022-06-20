using Blazored.LocalStorage;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.DTOs.TupleDTOs;

namespace BlazorRCM.Shared.Extensions
{
    public static class LocalStorageExtension
    {

        //private static ILocalStorageService? _storageService;

        //public static void Configure(ILocalStorageService localStorageService)
        //{
        //    _storageService = localStorageService;
        //}


        //public static String EMail {
        //    get
        //    {
        //        return _storageService!.GetItemAsStringAsync("email").ToString()!;
        //    }
        //    set
        //    {
        //        _storageService!.SetItemAsync("email",value);
        //    }
        //}

        public async static Task<int> GetUserId(this ILocalStorageService LocalStorage)
        {
            return int.Parse(await LocalStorage.GetItemAsStringAsync("activeUserId"));

        }
        //public static Guid GetUserIdSync(this ISyncLocalStorageService LocalStorage)
        //{
        //    String userGuid = LocalStorage.GetItemAsString("UserId");

        //    return Guid.TryParse(userGuid, out Guid UserId) ? UserId : Guid.Empty;
        //}

        public async static Task<List<BranchProductPriceDTO>> BranchProductPriceList(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<List<BranchProductPriceDTO>>("activeBranchProductPriceList");
        }

        public async static Task<List<ProductSaleNoteDTO>> ProductSaleNoteList(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<List<ProductSaleNoteDTO>>("ProductSaleNoteList");
        }


        public async static Task<String> GetUserEMail(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsStringAsync("email");
        }

        public async static Task<String> GetUserFullName(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsStringAsync("fullname");
        }
        public async static Task<string> ApiToken(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsStringAsync("token");

        }

        public async static Task<List<BranchDTO>> GetUserBranches(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<List<BranchDTO>>("userBranches");
        }

        public async static Task<PassBillDataToChangeBillPageDTO> GetBillDataForChange(this ILocalStorageService LocalStorage)
        {
            return await LocalStorage.GetItemAsync<PassBillDataToChangeBillPageDTO>("billDataForChange");
        }
    }
}
