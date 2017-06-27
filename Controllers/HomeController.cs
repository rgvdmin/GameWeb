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

            CharactersViewModel model = new CharactersViewModel();
            model.hero = new HeroModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult BeginGame(CharactersViewModel cmodel)
        {

            return RedirectToAction("Characters", new { enemy = 1, heroName = cmodel.hero.heroName });
        }

        public IActionResult Characters(int enemy, string heroName)
        {
            ChangeEnemy(enemy, heroName);
            return View(model);
        }

        private CharactersViewModel ChangeEnemy(int enemy, string heroName)
        {


            

            if (enemy <= 0)
                enemy = 1;


            model.alien = new AlienModel();
            model.weapon = new WeaponModel();
            model.drawing = new AlienDrawModel();
            model.hero = new HeroModel();

            model.hero.heroName = heroName;
            model.hero.heroLives = 3;



            switch (enemy)
            {
                case 1:
                    model.alien.alienName = "Patrick";
                    model.alien.strenght = new string[1] { "Freeze (make harder)" };
                    model.alien.weakness = new string[2] { "Torch (it)", "Candle (burn with prayers)" };
                    model.alien.healthPoints = 1000;
                    model.alien.message = "you killed patrick...";
                    model.weapon.weapons = new string[3, 2] { { "Torch (it)", "1000" }, { "Freeze (make harder)", "100" }, { "Candle (burn with prayers)", "500" } };
                    model.drawing.alienDraw = "http://emblemsbattlefield.com/uploads/posts/2014/9/evil-patrick-star-spongebob-emblem-tutorial_1.jpg";
                    model.alien.warning = "The rowdy Patrick appeares, what weapons will you use?";
                    break;
                case 2:

                    model.alien.alienName = "Whoopie";
                    model.alien.strenght = new string[1] { "Whip Cream (on it)" };
                    model.alien.weakness = new string[2] { "Spoon (her)", "Fork (it)" };
                    model.alien.healthPoints = 1000;
                    model.alien.message = "You made her love you so good that she died from broke heart";

                    model.weapon.weapons = new string[3, 2] { { "Spoon (her)", "1000" }, { "Whip Cream (on it)", "100" }, { "Fork (it)", "500" } };
            model.drawing.alienDraw = "http://www.nowyourecook.in/wp-content/uploads/2013/12/DSCN5161_editedTSthumb.jpg";
                    model.alien.warning = "Sum banana whoopie type split things appeared what you gonna do now?";
                break;
                case 3:

                    model.alien.alienName = "GAGA";
                    model.alien.strenght = new string[1] { "Vodka (martini)" };
                    model.alien.weakness = new string[2] { "Toothpick (poker face)", "Mouth (smash)" };
                    model.alien.healthPoints = 1000;
                    model.alien.message = "You rowdy hurt her and now shes 86'd";
                    model.weapon.weapons = new string[3, 2] { { "Toothpick (poker face)", "1000" }, { "Vodka (martini)", "100" }, { "Mouth (smash)", "500" } };
                    model.drawing.alienDraw = "http://img.photobucket.com/albums/v518/jfissel/evil_olive.png";
                    model.alien.warning = "An olive that named GAGA appeared now what you gonna do?";
                    break;


                default: break;
            }
            return model;



        }


        [HttpPost]
        public IActionResult FightEnemy(CharactersViewModel model)
        {

            /*
               Now I can capture the weapon value and the enemy.
               based on the name of the enemy, I can reduce it's health
               based on the points.
            */

            while (model.alien.healthPoints > 0 && model.hero.heroLives > 0)
            {

                int points = 0;
                switch (model.selectedWeapon)
                {
                    case "a":
                        points = Convert.ToInt32(model.weapon.weapons[0, 1]);
                        model.alien.healthPoints = model.alien.healthPoints - points;
                        Console.WriteLine("Great job! You have hit the enemy with {0} points!", points);
                        Console.WriteLine("Remaining Enemy healthPoints {0}", model.alien.healthPoints);
                        //Inline Condition
                        model.hero.heroLives = model.alien.healthPoints > 0 ? model.hero.heroLives - 1 : model.hero.heroLives + 1;
                        Console.WriteLine("Hero Remaining lives: {0}", model.hero.heroLives);
                        break;
                    case "b":
                        points = Convert.ToInt32(model.weapon.weapons[1, 1]);
                        model.alien.healthPoints = model.alien.healthPoints + points;
                        Console.WriteLine("Great job! You have hit the enemy with {0} points!", points);
                        Console.WriteLine("Remaining Enemy healthPoints {0}", model.alien.healthPoints);
                        //Inline Condition
                        model.hero.heroLives = model.alien.healthPoints > 0 ? model.hero.heroLives - 1 : model.hero.heroLives;
                        Console.WriteLine("Hero Remaining lives: {0}", model.hero.heroLives);
                        break;
                    case "c":
                        points = Convert.ToInt32(model.weapon.weapons[1, 1]);
                        model.alien.healthPoints = model.alien.healthPoints - points;
                        Console.WriteLine("Great job! You have hit the enemy with {0} points!", points);
                        Console.WriteLine("Remaining Enemy healthPoints {0}", model.alien.healthPoints);
                        //Inline Condition
                        model.hero.heroLives = model.alien.healthPoints > 0 ? model.hero.heroLives - 1 : model.hero.heroLives + 1;
                        Console.WriteLine("Hero Remaining lives: {0}", model.hero.heroLives);
                        break;
                }
            }

            if (model.alien.healthPoints <= 0)
            {
                Console.WriteLine("-++----===+===----==+==----===+===----++-");
                
                Console.WriteLine("You managed to defeat -[ {0} ]- with {1} lives remaining.", model.alien.alienName , model.hero.heroLives);
                Console.WriteLine("{0}",model.alien.message);
                return View(model);
            }
            else if (model.hero.heroLives <= 0)
            {
                Console.WriteLine("You have expended your stay on this earth... goodbye.");
                return View(model);
            }
            return View(model);
        }








            // if (Convert.ToInt32(model.selectedWeapon) > 100)
            // {
            //     int enemy = 1;
            //     model.gameStatus = "You are a hero!";
            //     switch (model.alien.alienName)
            //     {
            //         case "Patrick":
            //             enemy = 2;
            //             break;
            //         case "Whoopie":
            //             enemy = 3;
            //             break;
            //         case "GAGA":
            //             enemy = 1;
            //             break;
            //         default:
            //             break;
            //     }
            //     //You have to move on to the next enemy
            //     return RedirectToAction("Characters", new { enemy = enemy });
            // }
            // else
            // {
            //     model.gameStatus = "You have died!";
            // }

            //return View(model);
        }
    }



}

