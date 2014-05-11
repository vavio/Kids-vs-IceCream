using System;
using System.Collections.Generic;

namespace Kids_vs_IceCream
{
    //TODO Harder Killing
    public class LevelsDoc
    {
        private List<List<Kid>> Levels;

        public int CurrentLevel { get; set; }

        private Random Rand;

        public LevelsDoc()
        {
            Levels = new List<List<Kid>>();
            CurrentLevel = 0;
            Levels.Add(generateLevel1());
            Levels.Add(generateLevel2());
            Levels.Add(generateLevel3());
            Levels.Add(generateLevel4());
            Levels.Add(generateLevel5());
            Levels.Add(generateLevel6());
            Levels.Add(generateLevel7());
            Levels.Add(generateLevel8());
            Rand = new Random((int)DateTime.Now.Ticks);
        }

        private List<Kid> generateLevel8()
        {
            List<Kid> ret = new List<Kid>();
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid3());
            return ret;
        }

        private List<Kid> generateLevel7()
        {
            List<Kid> ret = new List<Kid>();
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid3());
            ret.Add(Kid.getKid3());
            return ret;
        }

        private List<Kid> generateLevel6()
        {
            List<Kid> ret = new List<Kid>();
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid2());
            return ret;
        }

        private List<Kid> generateLevel5()
        {
            List<Kid> ret = new List<Kid>();
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            return ret;
        }

        private List<Kid> generateLevel4()
        {
            List<Kid> ret = new List<Kid>();
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            return ret;
        }

        private List<Kid> generateLevel3()
        {
            List<Kid> ret = new List<Kid>();
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            ret.Add(Kid.getKid2());
            return ret;
        }

        private List<Kid> generateLevel2()
        {
            List<Kid> ret = new List<Kid>();
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            ret.Add(Kid.getKid1());
            return ret;
        }

        private List<Kid> generateLevel1()
        {
            List<Kid> ret = new List<Kid>();
            ret.Add(Kid.getKid1());
            //ret.Add(Kid.getKid1());
            //ret.Add(Kid.getKid1());
            //ret.Add(Kid.getKid1());
            return ret;
        }

        public List<Kid> getCurrentLevel()
        {
            if (CurrentLevel < Levels.Count)
                return Levels[CurrentLevel];
            else
                return generateRandomLevel();
        }

        public List<Kid> getNextLevel()
        {
            if (CurrentLevel < Levels.Count)
                return Levels[CurrentLevel++];
            else
                return generateRandomLevel();
        }

        private List<Kid> generateRandomLevel()
        {
            List<Kid> ret = new List<Kid>();
            for (int i = 0; i < Rand.Next(CurrentLevel * 2, CurrentLevel * 3); ++i)
            {
                int ran = Rand.Next(3);
                if (ran== 0)
                    ret.Add(new Kid(-30, 330, Rand.Next(3, 5), Properties.Resources.enemy_1_1, Properties.Resources.enemy_1_2, Rand.Next(1, 5)));
                else if (ran == 1)
                    ret.Add(new Kid(-30, 330, Rand.Next(5, 7), Properties.Resources.enemy_2_1, Properties.Resources.enemy_2_2, Rand.Next(3, 8)));
                else
                    ret.Add(new Kid(-30, 330, Rand.Next(7, 10), Properties.Resources.enemy_3_1, Properties.Resources.enemy_3_2, Rand.Next(7, 10)));
            }
            CurrentLevel++;
            return ret;
        }
    }
}