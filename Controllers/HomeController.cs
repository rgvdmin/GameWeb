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

            using (var context = new EFCoreGameWebContext())
                    {
                        model.scoreBoard = context.ScoreBoards.ToList();

                    }

            model.hero = new HeroModel();

            

            return View(model);
        }

        [HttpPost]
        public IActionResult BeginGame(CharactersViewModel model)
        {

            //get names of the players thatwon thet game

            

            model.alien = new AlienModel();
        

            //Default Values
            model.alien.alienName = "Patrick";
            model.alien.healthPoints = 1;
            model.hero.heroLives = 3;



            return View("Characters", ChangeEnemy(model));

        }

        private CharactersViewModel ChangeEnemy(CharactersViewModel model)
        {
            ModelState.Clear(); //Clear the ModelState

            model.weapon = new WeaponModel();
            model.drawing = new AlienDrawModel();

            if (model.alien.healthPoints <= 0)
            {
                switch (model.alien.alienName)
                {
                    case "Patrick":
                        model.alien.alienName = "Whoopie";
                        break;
                    case "Whoopie":
                        model.alien.alienName = "GAGA";
                        break;
                    default:
                        model.alien.alienName = "End";
                        break;
                }
            }

            switch (model.alien.alienName)
            {
                case "Patrick":
                    model.alien.alienName = "Patrick";
                    model.alien.strenght = new string[1] { "Freeze (make harder)" };
                    model.alien.weakness = new string[2] { "Torch (it)", "Candle (burn with prayers)" };
                    model.alien.healthPoints = model.alien.healthPoints > 0 ? model.alien.healthPoints : 1000;
                    model.alien.message = "you killed patrick...";
                    model.weapon.weapons = new string[3, 2] { { "Torch (it)", "1000" }, { "Freeze (make harder)", "100" }, { "Candle (burn with prayers)", "500" } };
                    model.drawing.alienDraw = "http://emblemsbattlefield.com/uploads/posts/2014/9/evil-patrick-star-spongebob-emblem-tutorial_1.jpg";
                    model.alien.warning = "The rowdy Patrick appeares, what weapons will you use?";
                    break;
                case "Whoopie":

                    model.alien.alienName = "Whoopie";
                    model.alien.strenght = new string[1] { "Whip Cream (on it)" };
                    model.alien.weakness = new string[2] { "Spoon (her)", "Fork (it)" };
                    model.alien.healthPoints = model.alien.healthPoints > 0 ? model.alien.healthPoints : 1000;
                    model.alien.message = "You made her love you so good that she died from broke heart";

                    model.weapon.weapons = new string[3, 2] { { "Spoon (her)", "1000" }, { "Whip Cream (on it)", "100" }, { "Fork (it)", "500" } };
                    model.drawing.alienDraw = "http://www.nowyourecook.in/wp-content/uploads/2013/12/DSCN5161_editedTSthumb.jpg";
                    model.alien.warning = "Sum banana whoopie type split things appeared what you gonna do now?";
                    break;

                case "GAGA":
                    model.alien.alienName = "GAGA";
                    model.alien.strenght = new string[1] { "Vodka (martini)" };
                    model.alien.weakness = new string[2] { "Toothpick (poker face)", "Mouth (smash)" };
                    model.alien.healthPoints = model.alien.healthPoints > 0 ? model.alien.healthPoints : 1000;
                    model.alien.message = "You rowdy hurt her and now shes 86'd";
                    model.weapon.weapons = new string[3, 2] { { "Toothpick (poker face)", "1000" }, { "Vodka (martini)", "100" }, { "Mouth (smash)", "500" } };
                    model.drawing.alienDraw = "http://img.photobucket.com/albums/v518/jfissel/evil_olive.png";
                    model.alien.warning = "An olive that named GAGA appeared now what you gonna do?";
                    break;

                default:
                    break;
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


            int points = Convert.ToInt32(model.selectedWeapon);

            switch (model.selectedWeapon)
            {
                case "1000":
                    points = Convert.ToInt32(model.selectedWeapon);
                    model.alien.healthPoints = model.alien.healthPoints - points;

                    model.hero.heroLives = model.alien.healthPoints > 0 ? model.hero.heroLives - 1 : model.hero.heroLives + 1;
                    break;
                case "500":
                    points = Convert.ToInt32(model.selectedWeapon);
                    model.alien.healthPoints = model.alien.healthPoints + points;

                    model.hero.heroLives = model.alien.healthPoints > 0 ? model.hero.heroLives - 1 : model.hero.heroLives + 1;
                    break;
                case "100":
                    points = Convert.ToInt32(model.selectedWeapon);

                    model.alien.healthPoints = model.alien.healthPoints - points;
                    model.hero.heroLives = model.alien.healthPoints > 0 ? model.hero.heroLives - 1 : model.hero.heroLives + 1;
                    break;
            }

            if (model.hero.heroLives <= 0)
            {
                model.gameStatus = string.Format("Dude! You just died!");



                return View(model);
            }
            else
            {
                model = ChangeEnemy(model);
                if (model.alien.alienName != "End")
                {
                    return View("Characters", ChangeEnemy(model));
                }
                else
                {

                    // save the name of the player that just won
                    ScoreBoard scoreBoardModel = new ScoreBoard();
                    scoreBoardModel.name = model.hero.heroName;

                    using (var context = new EFCoreGameWebContext())
                    {
                        context.Add(scoreBoardModel);
                        context.SaveChanges();

                    }

                    model.gameStatus = string.Format("Dude! You just won!");



                    return View(model);
                }
            }


        }

        [HttpPost]
        public IActionResult GetAge(CharactersViewModel model)
        {

         
        ScoreBoard scoreBoardModel = new ScoreBoard();
           scoreBoardModel.age = model.hero.age;
        using (var context = new EFCoreGameWebContext())
                    {
                        context.Add(scoreBoardModel);
                        context.SaveChanges();

                    }



            return View("FightEnemy", GetAge(model));

        }

    }
}