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
        void OnMarioInstanceVsLucky_blockListCollisionOccurred(Super_Marios_Bros.Entities.Mario first, Entities.Lucky_block second)
        {
            Console.WriteLine("HIT");
            if (first.Y < second.Y - 6.5f)
            {
                second.HandleHit();
            }
        }       
        void OnMarioInstanceVsGumbaListget_dunkedCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.Gumba second) 
        {
            second.deadgumba();
        }
        void OnMarioInstanceVsGumbaListLeftMarioDeadCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.Gumba second) 
        {
            second.Destroy();
            if (PassonClass.mariobig == true)
            {
                PassonClass.mariobig = false;
            }
            else if (PassonClass.mariobig == false)
            {
                this.RestartScreen(true, true);
            }
        }
        void OnMarioInstanceVsGumbaListRightMarioDeadCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.Gumba second) 
        {
            second.Destroy();
            if (PassonClass.mariobig == true)
            {
                PassonClass.mariobig = false;
            }
            else if (PassonClass.mariobig == false)
            {
                this.RestartScreen(true, true);
            }
        }        
        void OnMarioInstanceVsA_BrickListCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.A_Brick second) 
        {
            Console.WriteLine("Collsion occured");
            bool wasPushedDown = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition.Y < 0;
            if (wasPushedDown && PassonClass.mariobig)
            {
                Console.WriteLine("was pushed down true");
                bool hasDestroyedBlock = false;
                // First see if the player (first) BlockCollision has collided with any 
                // of the blocks
                for (int i = 0; i < A_BrickList.Count; i++)
                {
                    //Console.WriteLine("New Brick");
                    if (A_BrickList[i].AxisAlignedRectangleInstance.CollideAgainst(first.CollisionThing))  
                    {
                        // New code:
                        Console.WriteLine("Collided");
                        CombinedShapeCollection.RemoveRectangle(A_BrickList[i].AxisAlignedRectangleInstance);
                        A_BrickList[i].Imdead();
                        hasDestroyedBlock = true;
                        break;
                    }
                }
                // the BlockCollision doesn't collide with any of the blocks, so just destroy whichever block
                // we collided with
                if (!hasDestroyedBlock)
                {
                    // New code:
                    Console.WriteLine("The other way");

                    CombinedShapeCollection.RemoveRectangle(second.AxisAlignedRectangleInstance);

                    second.Imdead();
                }
            }
        }
    }
}
