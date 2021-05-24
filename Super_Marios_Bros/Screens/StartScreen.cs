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
    public partial class StartScreen //142 PLAYER ONE 156 PLAYER TWO
    {
        int index = 0;
        Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];
        void CustomInitialize()
        {


        }

        void CustomActivity(bool firstTimeCalled)
        {
			StartScreenGum.AnimateSelf();
			StartScreenGum.TextInstance.Text = PassonClass.HiScore.ToString(); ;
			if (index == 0)
			{
                StartScreenGum.themushroomY = 142;
			}
			else if (index == 1)
			{
                StartScreenGum.themushroomY = 156;
			}
			if ((InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.LeftControl) || gamePad.ButtonDown(Xbox360GamePad.Button.Back)))
			{
				if (index == 0)
				{
                    index = 1;
				}
				else if (index == 1)
				{
                    index = 0;
				}
			}
			if ((InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Enter) || gamePad.ButtonDown(Xbox360GamePad.Button.Start)))
			{
				if (index == 0)
				{
					MoveToScreen("World1level1");
				}
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
