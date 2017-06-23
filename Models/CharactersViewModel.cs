using System.Collections.Generic;

namespace GameWeb.Models
{

    public class CharactersViewModel
    {
        public AlienModel alien {get;set;}
        public WeaponModel weapon {get;set;}

        public HeroModel hero {get;set;}

        public string selectedWeapon {get;set;}

        public AlienDrawModel drawing {get;set;}



        public string gameStatus {get;set;}

    }

}