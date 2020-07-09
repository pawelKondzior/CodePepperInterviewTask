using CodePepperInterview.Contracts.DTO;
using CodePepperInterview.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodePepperInterview.IntegrationTests
{
    public class CharacterControllerTests
    {
        private HttpClient HttpClient { get; set; }

        public CharacterControllerTests()
        {
            var factory = new WebApplicationFactory<Startup>();
            HttpClient = factory.CreateClient();
        }

        [Fact]
        public async void CheckGetList()
        {
            var list = await GetList();

            Assert.NotEmpty(list);
        }

        [Fact]
        public async void CheckAddItemToList()
        {
            var httpResponse = await AddItemToList();

            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async void CheckAddAndGetItemFromList()
        {
            var listBeforeAdd = await GetList();

            var httpResponse = await AddItemToList();

            var listAfterAdd = await GetList();

            Assert.True(listBeforeAdd.Count < listAfterAdd.Count);
        }

        [Fact]
        public async void CheckDeleteItemFromList()
        {
            var addHttpResponse = await AddItemToList();

            var listBeforeAdd = await GetList();

            var lastItem = listBeforeAdd.LastOrDefault();

            var httpResponse = await HttpClient.DeleteAsync("/api/character/" + lastItem.Id.ToString());

            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async void CheckGetSingleItem()
        {
            var addHttpResponse = await AddItemToList();

            var listBeforeAdd = await GetList();

            var lastItem = listBeforeAdd.LastOrDefault();

            var resultItem = await GetItem(lastItem.Id);

            Assert.NotNull(resultItem);
        }

        private async Task<CharacterBaseDto> GetItem(int id)
        {
            var httpResult = await HttpClient.GetAsync("/api/character/" + id.ToString());
            var result = await GetData<CharacterBaseDto>(httpResult);
            return result;
        }

        private async Task<List<CharacterBaseDto>> GetList()
        {
            var result = await HttpClient.GetAsync("/api/character");

            var list = await GetData<List<CharacterBaseDto>>(result);
            return list;
        }

        private async Task<HttpResponseMessage> AddItemToList()
        {
            var itemToPost = new CharacterBaseDto()
            {
                name = "Pawel Kondzior",
                planet = "ziemia"
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(itemToPost), Encoding.UTF8, "application/json");

            var httpResponse = await HttpClient.PostAsync("/api/character", httpContent);
            return httpResponse;
        }

        private static async Task<T> GetData<T>(HttpResponseMessage httpResponse)
        {
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponse.StatusCode);
            var content = httpResponse.Content;
            var jsonStr = await content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonStr);
            return result;
        }
    }
}