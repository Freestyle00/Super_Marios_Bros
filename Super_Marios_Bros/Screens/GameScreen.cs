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
    public partial class GameScreen
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
            FlatRedBall.Debugging.Debugger.Write("X" + MarioInstance.X + "\nY" + MarioInstance.Y + "\nGumba X Velocity " + PassonClass.GUMBATEST); 
            if (MarioInstance.Y <= -230) { RestartScreen(true, true); }
            if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.R))
            {
                this.RestartScreen(true, true);
            }
            //foreach (Super_Marios_Bros.Entities.A_Brick Brick in A_BrickList)
            //{
            //    MarioInstance.CollideAgainstMove(Brick.AxisAlignedRectangleInstance, 0, 1);
            //}
            foreach (Entities.A_Brick brick in A_BrickList)
            {
                if (MarioInstance.CollideAgainst(brick.Hitbox_from_down) && PassonClass.mariobig == true)
                {
                    brick.Imdead();
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
