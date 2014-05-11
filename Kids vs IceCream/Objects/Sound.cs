using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;

namespace Kids_vs_IceCream
{
    public class Sounds
    {
        private SoundPlayer IntroMusic;

        public Sounds()
        {
            IntroMusic = new SoundPlayer(Properties.Resources.Intro1);
        }

        public void playMusic()
        {
            IntroMusic.PlayLooping();
        }
    }
}
