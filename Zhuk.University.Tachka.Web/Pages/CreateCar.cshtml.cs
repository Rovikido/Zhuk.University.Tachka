using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.JavaScript;
using Zhuk.University.Tachka.Core.Constants;
using Zhuk.University.Tachka.Database.Helpers;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class CreateCarModel : PageModel
    {
        [BindProperty]
        public CreateCarRequest Car { get; set; }

        public IEnumerable<string> Colors { get; set; }
        public List<int> Years { get; set; }
        private readonly IDbEntityService<Car> _carService;

        private LocationHelper LocHelper = new LocationHelper();

        private DateTime date = DateTime.Now;
        

        public CreateCarModel(IDbEntityService<Car> carService)
        {
            _carService = carService;
        }
        public void OnGet()
        {
            Colors = ColorsRep.GetAllColors().ToList();
            Years = YearHelper.GetYearsList().ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            string DateWithoutTime = date.ToShortDateString(); //ToString("dd / MM / yyyy");

            var result = await LocHelper.GetGeoInfo();
            var JObj = JObject.Parse(result);
            var city = (string)JObj["city"];

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}


            await _carService.Create(new Car()
            {
                Name = Car?.Name,
                Model = Car?.Model,
                Price = Car?.Price,
                Color = Car?.Color,
                Year = Car?.Year,
                Description = Car?.Description,
                PlacementTime = DateWithoutTime,
                PlacementCity = city,
                Rating = 0

            });  

            return new RedirectToPageResult("/Carlist");
        }
    }
}
