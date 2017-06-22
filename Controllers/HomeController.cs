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

        CharactersViewModel model = new CharactersViewModel();
        public IActionResult Index()
        {

            return View();
        }

        // public IActionResult About()
        // {
        //     ViewData["Message"] = "Your application description page.";

        //     return View();
        // }

        // public IActionResult Contact()
        // {
        //     ViewData["Message"] = "Your contact page.";

        //     return View();
        // }


        public IActionResult Characters(int enemy)
        {
            ChangeEnemy(enemy);

            return View(model);
        }

        private CharactersViewModel ChangeEnemy(int enemy)
        {

            if (enemy <= 0)
                enemy = 1;


            model.alien = new AlienModel();
            model.weapon = new WeaponModel();
            model.drawing = new AlienDrawModel();



            switch (enemy)
            {
                case 1:
                    model.alien.alienName = "Patrick";
                    model.alien.strenght = new string[1] { "Freeze (make harder)" };
                    model.alien.weakness = new string[2] { "Torch (it)", "Candle (burn with prayers)" };
                    model.alien.healthPoints = 1000;
                    model.alien.message = "you killed patrick...";
                    model.weapon.weapons = new string[3, 2] { { "Torch (it)", "1000" }, { "Freeze (make harder)", "100" }, { "Candle (burn with prayers)", "500" } };
                    model.drawing.alienDraw = @"
                       _...___     
                     .'_ (.) _'.
                    /  (.) (.)  \
                    |  ,_____.  |      __
                    \     '-'   /_-_-_/ /
                     '_+PATRIK+.'-_-_-\_\
                     __//   \\__
                    (___)   (___)";
                    break;
                case 2:

                    model.alien.alienName = "GAGA";
                    model.alien.strenght = new string[1] { "Whip Cream (on it)" };
                    model.alien.weakness = new string[2] { "Spoon (her)", "Fork (it)" };
                    model.alien.healthPoints = 1000;
                    model.alien.message = "You made her love you so good that she died from broke heart";

                    model.weapon.weapons = new string[3, 2] { { "Spoon (her)", "1000" }, { "Whip Cream (on it)", "100" }, { "Fork (it)", "500" } };
            model.drawing.alienDraw = @"
    /\.-.../`\     /#\
   /_\ /_   \ \--.  \ \
 / /.\ /.\   \ \--. / /
/  \_/ \_/    \ \ \/ /
:(_)_______(_): | \ X
 \  \/ \/  ; ./ |  \--\
  ##__GAGA____##|...\--\     
  (,,,)(,,,)   (,,,)(,,,)";
                break;
                case 3:

                    model.alien.alienName = "Olivia";
                    model.alien.strenght = new string[1] { "Vodka (martini)" };
                    model.alien.weakness = new string[2] { "Toothpick (poker face)", "Mouth (smash)" };
                    model.alien.healthPoints = 1000;
                    model.alien.message = "You rowdy hurt her and now shes 86'd";
                    model.weapon.weapons = new string[3, 2] { { "Toothpick (poker face)", "1000" }, { "Vodka (martini)", "100" }, { "Mouth (smash)", "500" } };
                    model.drawing.alienDraw = @"      
      __.           __.
  __ {_/        __ {_/ 
  \_}\\ ___     \_}\\ ___.
  / \    / \    /  \   / |
 /  o____o  \   /  O____O \
/ #       #  \ / #       # \
| -_-_-_-_-_ | -_-_-_-_-_ |=^|^\
\    -===-==ANNA==-====- .'=.|./
 '.         .''.           .'
   '-.....-'   '-........-'";
                    break;


                default: break;
            }
            return model;



        }


        [HttpPost]
        public IActionResult FightEnemy(CharactersViewModel model)
        {


            int enemy = 1;

            if (Convert.ToInt32(model.selectedWeapon) > 100)
            {

                model.gameStatus = "You are a hero!";
                switch (model.alien.alienName)
                {
                    case "Patrick the dry ice cube":
                        enemy = 2;
                        break;
                    case "patrick the dho":
                        enemy = 3;
                        break;
                    case "patrick the ":
                        enemy = 1;
                        break;
                    default:
                        break;
                }
                return RedirectToAction("Characters", new { enemy = enemy });
            }
            else
            {

                model.gameStatus = "You have died;";
            }

            return View(model);
        }
    }



}

