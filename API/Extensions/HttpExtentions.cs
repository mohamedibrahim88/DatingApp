using System.Text.Json;
using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    public static class HttpExtentions
    {
        public static void AddPaginationHeader (this HttpResponse response , int currentpage, int itemsPerPage, 
        int totalItems,  int totalPages) {

            var paginationHeader = new PaginationHeader (currentpage, itemsPerPage 
            , totalItems,totalPages); 
            
            var options = new JsonSerializerOptions{
                PropertyNamingPolicy =JsonNamingPolicy.CamelCase

            };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader,options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination" );
        }
    }
}