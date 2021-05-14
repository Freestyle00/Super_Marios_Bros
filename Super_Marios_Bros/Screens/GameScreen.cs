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
    public partial class GameScreen //GIT HUB CLI TEST
    {
        void CustomInitialize()
        {
            CombinedShapeCollection.InsertCollidables(A_BrickList);
            CombinedShapeCollection.InsertCollidables(Lucky_blockList);
            Camera.Main.Y = -120;
            Camera.Main.X = 140;
        }

        void CustomActivity(bool firstTimeCalled)
        {
            if (MarioInstance.X > 140 && MarioInstance.X < 3232)
            {
                Camera.Main.X = MarioInstance.X;
            }
            if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.R))
            {
                this.RestartScreen(true, true);
            }
            CheatCodes();
        }
        void CustomDestroy()
        {

			
        }
        static void CustomLoadStaticContent(string contentManagerName)
        {


        }
        void CheatCodes() //yes i have played games that old
        {
            //KONAMI CODE UP UP DOWN DOWN LEFT RIGHT LEFT RIGHT A B
            if (true) //up
            {

            }
            if (true) //up
            {

            }
            if (true) //down
            {

            }
            if (true) //down
            {

            }
            if (true) //left
            {

            }
            if (true) //right
            {

            }
            if (true) //left
            {

            }
            if (true) //right
            {

            }
            if (true) //a
            {

            }
            if (true) //b
            {

            }
        }
    }
}
