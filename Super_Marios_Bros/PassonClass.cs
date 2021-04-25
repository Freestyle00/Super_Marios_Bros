using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Marios_Bros
{
    public static class PassonClass
    {
        public static float marioX;
        public static float marioY;
        public static bool mariobig = false;
        public static float GUMBATEST;
        public static bool[] KonamiCode = new bool[10] { false, false, false, false, false, false, false, false, false, false };
        public static void Wrong()
        {
            for (int i = 0; i < 10; i++)
            {
                KonamiCode[i] = false;
            }
        }
        //private static int mariopowerlevel = 1;
        //static void mariogothit()
        //{

        //}
    }
}

