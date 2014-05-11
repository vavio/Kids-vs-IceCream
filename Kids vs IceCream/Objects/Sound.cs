using System.Media;

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