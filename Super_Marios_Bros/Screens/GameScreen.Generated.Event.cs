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
        void OnMarioInstanceVsLucky_blockListCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.Lucky_block second) 
        {
            if (this.MarioInstanceVsLucky_blockListCollisionOccurred != null)
            {
                MarioInstanceVsLucky_blockListCollisionOccurred(first, second);
            }
        }
        void OnMarioInstanceVsA_BrickListCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.A_Brick second) 
        {
            if (this.MarioInstanceVsA_BrickListCollisionOccurred != null)
            {
                MarioInstanceVsA_BrickListCollisionOccurred(first, second);
            }
        }
        void OnMarioInstanceVsGumbaListAxisAlignedRectangleInstanceCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.Gumba second) 
        {
            if (this.MarioInstanceVsGumbaListAxisAlignedRectangleInstanceCollisionOccurred != null)
            {
                MarioInstanceVsGumbaListAxisAlignedRectangleInstanceCollisionOccurred(first, second);
            }
        }
        void OnGumbaListAxisAlignedRectangleInstanceVsSolidCollisionCollisionOccurredTunnel (Entities.Gumba first, FlatRedBall.TileCollisions.TileShapeCollection second) 
        {
            if (this.GumbaListAxisAlignedRectangleInstanceVsSolidCollisionCollisionOccurred != null)
            {
                GumbaListAxisAlignedRectangleInstanceVsSolidCollisionCollisionOccurred(first, second);
            }
        }
        void OnMarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstanceCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.Mushroom second) 
        {
            if (this.MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstanceCollisionOccurred != null)
            {
                MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstanceCollisionOccurred(first, second);
            }
        }
        void OnMushroomListVsSolidCollisionCollisionOccurredTunnel (Entities.Mushroom first, FlatRedBall.TileCollisions.TileShapeCollection second) 
        {
            if (this.MushroomListVsSolidCollisionCollisionOccurred != null)
            {
                MushroomListVsSolidCollisionCollisionOccurred(first, second);
            }
        }
        void OnTurtleListVsSolidCollisionCollisionOccurredTunnel (Entities.Turtle first, FlatRedBall.TileCollisions.TileShapeCollection second) 
        {
            if (this.TurtleListVsSolidCollisionCollisionOccurred != null)
            {
                TurtleListVsSolidCollisionCollisionOccurred(first, second);
            }
        }
        void OnMarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstanceCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.Turtle second) 
        {
            if (this.MarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstanceCollisionOccurred != null)
            {
                MarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstanceCollisionOccurred(first, second);
            }
        }
        void OnMarioInstanceVsCoinListCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.Coin second) 
        {
            if (this.MarioInstanceVsCoinListCollisionOccurred != null)
            {
                MarioInstanceVsCoinListCollisionOccurred(first, second);
            }
        }
    }
}
