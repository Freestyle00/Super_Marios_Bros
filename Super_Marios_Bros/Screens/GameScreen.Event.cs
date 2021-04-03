using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using Super_Marios_Bros.Entities;
using Super_Marios_Bros.Screens;
namespace Super_Marios_Bros.Screens
{
    public partial class GameScreen
    {
        //void OnMarioInstanceVsA_BrickListCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.A_Brick second) 
        //{
        //    if (PassonClass.mariobig == true && first.Y < second.Y)
        //    {
        //        second.Destroy();
        //    }
        //}
        //void OnMarioInstanceVsSolidCollisionCollisionOccurred (Super_Marios_Bros.Entities.Mario first, FlatRedBall.TileCollisions.TileShapeCollection second) 
        //{
               
        //}
        void OnGumbaListVsSolidCollisionCollisionOccurred (Entities.Gumba first, FlatRedBall.TileCollisions.TileShapeCollection second) 
        {
            if (first.Y > second.Y)
            {

            }
        }

    }
}
