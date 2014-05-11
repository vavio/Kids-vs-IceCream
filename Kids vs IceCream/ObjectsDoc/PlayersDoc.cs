using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kids_vs_IceCream
{
    public class PlayersDoc
    {
        public List<Player> Players { get; set; }

        public PlayersDoc()
        {
            Players = new List<Player>();
            readFromFile();
        }

        private void readFromFile()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("score.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] info = line.Split(' ');
                    Players.Add(new Player(info[0], Convert.ToInt32(info[1])));
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
            }
        }

        public void AddPlayer(Player p)
        {
            Players.Add(p);

            writeToFile();
        }

        private void writeToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter("score.txt", false);
                foreach (Player iter in Players)
                {
                    sw.WriteLine(iter);
                }
                sw.Close();
            }
            catch (Exception e)
            {
            }
        }
    }
}
