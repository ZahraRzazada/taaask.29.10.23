using Classwork._26._10._23.Models;
using Microsoft.AspNetCore.Mvc;
namespace Classwork._26._10._23.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Marka> _marka;
        private readonly List<CarModel> _carmodel;
        public List<CarModel> carModels { get; }
        private readonly List<Car> _car;
        private readonly List<Detail> _detail;
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
                new CarModel{Name="A1",MarkaId=1 ,Id=1},
                new CarModel{Name="F800",MarkaId=2 ,Id=2},
                new CarModel { Name = "Neon" ,MarkaId=3 ,Id=3},
                new CarModel { Name = "Sentra" ,MarkaId=4 ,Id=4},
                new CarModel { Name = "S500" ,MarkaId=5 ,Id=5},
                new CarModel { Name = "XC40" ,MarkaId=6 ,Id=6},

            };
            _car = new List<Car>
            {
                new Car{Name="Audi A1",CarModelId=1 ,Id=1},
                new Car{Name="BMW F800",CarModelId=2 ,Id=2},
                new Car { Name = "Chryseler Neon" ,CarModelId=3 ,Id=3},
                new Car { Name = "Nissan Sentra" ,CarModelId=4 ,Id=4},
                new Car { Name = "Mercedes S500" ,CarModelId=5 ,Id=5},
                new Car { Name = "Volvo XC40" ,CarModelId=6 ,Id=6},
            };
            _detail = new List<Detail>
            {
                new Detail{Price=48000,Color="Red",Year=2000,CarId=1,Id=1},
                new Detail{Price=50000,Color="Black",Year=2006,CarId=2,Id=2},
                new Detail{Price=48000,Color="Green",Year=2005 ,CarId=3,Id=3},
                new Detail{Price=48000,Color="Yellow",Year=2003,CarId=4,Id=4},
                new Detail{Price=48000,Color="Brawn",Year=2002,CarId=5,Id=5},
                new Detail{Price=48000,Color="Blue",Year=2001 ,CarId=6,Id=6},
            };

        }
        public IActionResult Index()
        {
            return View(_marka);
        }
        

        public IActionResult CarModel(int? id)
        {
            if (id == null) return BadRequest();
            Marka? marka = _marka.Find(m => m.Id == id);
            if (marka == null) return NotFound();
            List<CarModel>carModels = _carmodel.FindAll(c => c.MarkaId == marka.Id);
            return View(carModels);
        }
        public IActionResult Car(int? id)
        {
            if (id == null) return BadRequest();
            CarModel? carModel = _carmodel.Find(c => c.Id == id);
            if (carModel == null) return NotFound();
            List<Car> car = _car.FindAll(c => c.CarModelId == carModel.Id);
            return View(car);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return BadRequest();
            Car? car = _car.Find(c=> c.Id == id);
            if (car == null) return NotFound();
            Detail? details = _detail.Find(d =>d.CarId== car.Id);
            return View(details);
        }
            
    }
}

