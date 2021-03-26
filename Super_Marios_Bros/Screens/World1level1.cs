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
    public partial class World1level1
    {
        void CustomInitialize()
        {
            Camera.Main.Y = -120;
            Camera.Main.X = 140;
        }
        void CustomActivity(bool firstTimeCalled)
        {
            if (MarioInstance.X > 140 && MarioInstance.X < 3232)
            {
                Camera.Main.X = MarioInstance.X;
            }
            FlatRedBall.Debugging.Debugger.Write("X" + MarioInstance.X + "\nY" + MarioInstance.Y); //(╯ ͠° ͟ʖ ͡°)╯┻━┻ 
            if (MarioInstance.Y <= -230) { RestartScreen(true, true); };
        }
        void CustomDestroy()
        {


        }
        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

    }
}
