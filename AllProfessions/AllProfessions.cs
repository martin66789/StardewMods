﻿using System;
using System.Collections.Generic;
using System.Linq;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace AllProfessions
{
    public class AllProfessions : Mod
    {


        public override void Entry(IModHelper helper)
        {
            runConfig();
            Console.WriteLine("AllProfessions Has Loaded");
            LocationEvents.CurrentLocationChanged += Events_LocationChanged;


        }

        public List<int> FarmerLvlFive = new List<int> { 0, 1 };
        public List<int> FarmerLvlTen = new List<int> { 2, 3, 4, 5 };

        public List<int> FishingLvlFive = new List<int> { 6, 7 };
        public List<int> FishingLvlTen = new List<int> { 8, 9, 10, 11 };

        public List<int> ForagingLvlFive = new List<int> { 12, 13 };
        public List<int> ForagingLvlTen = new List<int> { 14, 15, 16, 17 };

        public List<int> MiningLvlFive = new List<int> { 18, 19 };
        public List<int> MiningLvlTen = new List<int> { 20, 21, 22, 23 };

        public List<int> CombatLvlFive = new List<int> { 24, 25 };
        public List<int> CombatLvlTen = new List<int> { 26, 27, 28, 29 };



        void runConfig()
        {
        }


        public void Events_LocationChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Leveled up!");
            AddMissingProfessions();
        }

        public void AddMissingProfessions()
        {
            //Console.WriteLine("Adding new professions");
            var professions = Game1.player.professions;
            List<List<int>> ProfessionsList = new List<List<int>> { FarmerLvlFive, FarmerLvlTen, FishingLvlFive, FishingLvlTen,
                ForagingLvlFive, ForagingLvlTen, MiningLvlFive, MiningLvlTen, CombatLvlFive, CombatLvlTen };

            foreach (List<int> list in ProfessionsList)
            {
                //Console.WriteLine("iterating over lists");
                if (professions.Intersect(list).Any())
                {
                    //Console.WriteLine("profession intersection found" + list.ToString());
                    foreach (int element in list)
                    {
                        //Console.WriteLine("checking element: " + element.ToString("g"));
                        if (!professions.Contains(element))
                        {
                            professions.Add(element);
                            //Console.WriteLine("Adding profession number: " + element.ToString("g"));

                            //adding in health bonuses that are a special case of LevelUpMenu.getImmediateProfessionPerk
                            if (element == 24)
                            {
                                Game1.player.maxHealth += 15;
                            }
                            if (element == 27)
                            {
                                Game1.player.maxHealth += 25;
                            }
                        }
                    }
                }
            }
        }
    }
}
