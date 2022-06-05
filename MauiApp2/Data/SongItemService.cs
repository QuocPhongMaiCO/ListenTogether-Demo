using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace MauiApp2.Data
{
    public class SongItemService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Category[]> GetCategoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<Category[]>("https://music-ne.herokuapp.com/api/category/VN");
        }

        public async Task<SongList> GetListSongAsync(String songId)
        {
            return await _httpClient.GetFromJsonAsync<SongList>("https://music-ne.herokuapp.com/api/category/VN/25126518-bb71-447e-9018-1441550af8a8");
        }
    }

}
