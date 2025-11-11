using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
//
namespace fusionPriceList.Pages
{
    public class IndexModel : PageModel
    {
        public class Part
        {
            public string? CategoryType { get; set; }
            public string? Name { get; set; }
            public double? Price { get; set; }
        }

        public class PriceList
        {
            public string? Location { get; set; }
            public List<Part>? Parts { get; set; }
        }

        public List<Part> PriceLists { get; set; } = new();

        private HttpClient _client;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var respond = await _client.GetAsync("https://6f5c9791-a282-482e-bbe9-2c1d1d3f4c9f.mock.pstmn.io/interview/part-list");
            if (respond != null)
            {
                string result = await respond.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(result);
                //List<PriceList> items = JsonConvert.DeserializeObject<List<PriceList>>(result);
                //PriceList    PartItems = await JsonSerializer.Deserialize<PriceList>(result);
                //List<PriceList> items = JsonConvert.DeserializeObject<List<PriceList>>(result);

                PriceList pList = new PriceList();
                string[] part1 = result.Split('[');
                string[] part2 = part1[1].Split("}");
                string[] Location = part1[0].Split(":");
                pList.Location = Location[1];
                List<Part> parts = new List<Part>();
                for (int i = 0; i < part2.Count() - 2; i++)
                {
                    string[] itemList = part2[i].Split(':');
                    Part _part = new Part();
                    string[] type = itemList[1].Split(',');
                    _part.CategoryType = type[0].Replace('"', ' '); 
                    string[] name = itemList[2].Split(',');
                    _part.Name = name[0].Replace('"', ' ');
                    _part.Price = Convert.ToDouble(itemList[3]);
                    parts.Add(_part);
                    PriceLists.Add(_part); //Add model as separate model list
                }
                pList.Parts = parts;
            }
            var sortedPrice = PriceLists.OrderByDescending(p => p.Price).ToList();
            PriceLists.Clear();
            foreach (var price in sortedPrice)
            {
                PriceLists.Add(price);
            }

            return Page();

        }
    }
}