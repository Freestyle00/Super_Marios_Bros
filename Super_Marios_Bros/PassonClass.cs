using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Marios_Bros
{
	public static class PassonClass
	{
		public static bool mariobig = false;
		public static bool[] KonamiCode = new bool[10] { false, false, false, false, false, false, false, false, false, false };
		public static int Score = 0;
		public static int Coins = 0;
		public static float TimeTillTheEnd = 400;
		public static bool TimeToGo = false;
		public static int lifes = 3;
		public static void Restart()
		{
			mariobig = false; 
			Wrong();
			Coins = 0;
			TimeTillTheEnd = 400;
			lifes -= 1;
		}
		public static void FullRestart()
		{
			Score = 0;
			mariobig = false;
			Wrong();
			Coins = 0;
			TimeTillTheEnd = 400;
			lifes = 3;
		}
		public static void Wrong()
		{
			for (int i = 0; i < 10; i++)
			{
				KonamiCode[i] = false;
			}
		}
	}
}