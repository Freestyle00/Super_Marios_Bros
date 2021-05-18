using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;

namespace Super_Marios_Bros.Screens
{
	public partial class GameoverScreen
	{
		private float TimeToShow = 2;
		void CustomInitialize()
		{
			
			
		}
		void CustomActivity(bool firstTimeCalled)
		{
			TimeToShow -= TimeManager.LastSecondDifference;
			GameoverScreenGum.NoOfLifes = PassonClass.lifes.ToString("");
			if (PassonClass.lifes < 0)
			{
				GameoverScreenGum.TextInstance6.Visible = false;
				GameoverScreenGum.SpriteInstance1.Visible = false;
				GameoverScreenGum.TextInstance7.Visible = false;
				GameoverScreenGum.TextInstance8.Visible = false;
				GameoverScreenGum.TextInstance5.Text = "GAME OVER";
				PassonClass.FullRestart();
			}
			if (TimeToShow <= 0)
			{
				MoveToScreen("World1level1");
			}
		}
		void CustomDestroy()
		{
			
			
		}
		static void CustomLoadStaticContent(string contentManagerName)
		{
			
			
		}
	}
}
