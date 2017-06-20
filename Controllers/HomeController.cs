using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameWeb.Models;

namespace GameWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {


            AlienModel alien1 = new AlienModel();
            alien1.alienName = "Patrick";
            //weakness
            //strength

            alien1.healthPoints = 1000;
            alien1.message = "you killed patrick...";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Characters()
        {

            CharactersViewModel model = new CharactersViewModel();

            
            model.alien.alienName = "Patrick";
            model.alien.strenght = new string[1] { "Freeze (make harder)" };
            model.alien.weakness = new string[2] { "Torch (it)", "Candle (burn with prayers)" };
            model.alien.healthPoints = 1000;
            model.alien.message = "you killed patrick...";


            model.weapon.weapons = new string[3,2] { { "Torch (it)", "1000" }, { "Freeze (make harder)", "100" }, { "Candle (burn with prayers)", "500" } };;
          
           


        

            return View(model);
        }


        public IActionResult Error()
        {
            return View();
        }

        // public IActionResult SubmitForm(CharacterModels model)
        // {

        //     if (model.option > 0)
        //     {

        //         switch (model.option)
        //         {
        //             case 1:
        //                 model.name = "Character 1";
        //                 break;
        //             case 2:
        //                 model.name = "Character 2";
        //                 break;
        //             default:
        //             break;
        //     }
        //     }
        //         return RedirectToAction("Index", model);
        // }
    }
}
