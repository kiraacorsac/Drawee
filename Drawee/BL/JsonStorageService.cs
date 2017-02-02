using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Drawee.BL
{
    public class JsonStorageService
    {
        private static readonly Lazy<JsonStorageService> instance = new Lazy<JsonStorageService>(() => new JsonStorageService());
        public static JsonStorageService Instance => instance.Value;

        private static readonly string drawersUrl = "";
        private static readonly string pairsUrl = "";

        private JsonStorageService()
        { }

        public async Task<string> CreateAsync(string initData)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent("{\"hi\": \"there\"}");
                content.Headers.Clear();
                content.Headers.Add("ContentType", "application/json");

                var result = await client.PostAsync("https://api.myjson.com/bins", content);
                if (result.StatusCode != HttpStatusCode.Created)
                {
                    throw new UIException($"Could not create requested storage. Code: {result.StatusCode}");
                }
                var responseBody = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CreateResponse>(responseBody).Uri;
            }
        }

        public async Task SavePairsAsync(IList<DrawingPair> pairs)
        {
            var generation = JsonConvert.SerializeObject(pairs);

            using (var client = new HttpClient())
            {
                var result = await client.PutAsync(pairsUrl, new StringContent(generation));
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    throw new UIException($"Could not save drawing pairs to storage storage. Code: {result.StatusCode}");
                }
            }
        }

        public async Task<IList<DrawingPair>> GetPairsAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(pairsUrl);
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    throw new UIException($"Could not load drawing pairs from storage. Code: {result.StatusCode}");
                }
                var responseBody = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<DrawingPair>>(responseBody);
            }
        }

        public async Task<IList<Drawer>> GetDrawersAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(drawersUrl);
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    throw new UIException($"Could not load drawers from storage. Code: {result.StatusCode}");
                }
                var responseBody = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Drawer>>(responseBody);
            }
        }


        public async Task<string> InitStorageAsync()
        {
            IList <DrawingPair> pairList = new List<DrawingPair>();
            var pairId = await CreateAsync(JsonConvert.SerializeObject(pairList));

            var drawers =
                new List<Drawer>{
                new Drawer ("Azhsara",
                            "https://i.imgur.com/7yl8Kt0.png")
                {
                    Refsheet ="https://i.imgur.com/vTJccto.png",
                    InterestingLinks = new[] { "https://www.furaffinity.net/gallery/azsharakletete/" }
                },
                new Drawer ("Werella",
                            "https://i.imgur.com/LnPQh5E.png")
                {
                    Refsheet ="https://i.imgur.com/ye34joK.jpg",
                    InterestingLinks = new[] { "https://www.furaffinity.net/gallery/werella/" }
                },

                new Drawer ("Kiraa",
                            "https://i.imgur.com/JyhKLFJ.jpg")
                {
                    Refsheet = "https://i.imgur.com/lSQcQVd.png",
                    InterestingLinks = new[] { "https://1drv.ms/f/s!An0EFXyDrkpomwviknZOkPgDvZWC" }
                },


                new Drawer ("Mlpard",
                            "https://i.imgur.com/jRrC6ew.png")
                {
                    InterestingLinks = new [] { "https://www.furaffinity.net/gallery/mlpard/" }
                },

                new Drawer ("Rodney",
                            "https://i.imgur.com/CruUd8v.png")
                {
                    InterestingLinks = new[] { "https://www.furaffinity.net/gallery/rodneyfive/" }
                },
                new Drawer ("Blue",
                            "https://i.imgur.com/74oJN6f.jpg")
                {
                    Refsheet = "https://i.imgur.com/yYlwNF9.jpg",
                    InterestingLinks = new [] { "https://www.furaffinity.net/user/bluehoresewolf" }
                },
                new Drawer ("Greyfur",
                            "https://www.furry.cz/users/greyfur/char.jpg")
                {
                    Refsheet = "https://i.imgur.com/lgMYLXo.jpg"
                },
                new Drawer ("Zelus",
                            "https://i.imgur.com/XtZzYul.png"),
                new Drawer ("Mari",
                            "https://i.imgur.com/2Eb1DVD.png") {
                    Refsheet = "https://i.imgur.com/T7fjW7p.png"
                },
            };

            var drawersId = await CreateAsync(JsonConvert.SerializeObject(drawers));

            return $"pairUrl: {pairId}, drawersUrl: {drawersId}";
        }



        private class CreateResponse
        {
            public string Uri { get; set; }
        }
    }
}