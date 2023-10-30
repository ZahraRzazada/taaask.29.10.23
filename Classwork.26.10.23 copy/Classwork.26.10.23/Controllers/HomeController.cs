using Classwork._26._10._23.Models;
using Microsoft.AspNetCore.Mvc;
namespace Classwork._26._10._23.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Marka> _marka;
        private readonly List<CarModel> _carmodel;
        public List<CarModel>carModels { get; }
        //private readonly List<Car> _car;
        public HomeController()
        {

            _marka = new List<Marka>
            {
                new Marka{Name= "Audi" ,Id=1},
                new Marka{Name= "BMW" ,Id=2},
                new Marka{Name= "Chryseler" ,Id=3},
                new Marka{Name= "Nissan" ,Id=4},
                new Marka{Name= "Mercedes" ,Id=5},
                new Marka{Name= "Volvo" ,Id=6},

            };
            _carmodel = new List<CarModel>
            {
                new CarModel{Name="A1",MarkaId=1},
                new CarModel{Name="F800",MarkaId=2},
                new CarModel { Name = "Neon" ,MarkaId=3},
                new CarModel { Name = "Sentra" ,MarkaId=4},
                new CarModel { Name = "S500" ,MarkaId=5},
                new CarModel { Name = "XC40" ,MarkaId=6},

            };

        }
        public IActionResult Index()
        {
            return View(_marka);
        }
        //_car = new List<Car>
        //{
        //    new Car{Name="Audi A1"},
        //    new Car{Name="BMW F800"},
        //    new Car{Name="Chryseler Neon"},
        //    new Car{Name="Nissan Sentra"},
        //    new Car{Name="Mercedes S500"},
        //    new Car{Name="Volvo XC40"},
        //};

        public IActionResult CarModel(int? id)
        {
            if (id == null) return BadRequest();
            Marka? marka = _marka.Find(m => m.Id == id);
            if (marka == null) return NotFound();
            List<CarModel>carModels = _carmodel.FindAll(c => c.MarkaId == marka.Id);
            return View(_carmodel);
        }

    }
}

