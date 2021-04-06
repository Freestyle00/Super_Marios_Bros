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
            if (first.Y < second.Y - 6.5f)
            {
                second.HandleHit();
                
            }
        }       
        void OnMarioInstanceVsA_BrickListCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.A_Brick second) 
        {

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
        void OnMarioInstanceVsA_BrickListHitbox_from_downCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.A_Brick second) // i have to fix this after i am done with learing some music notes this doesnt trigger at all
        {
            Console.WriteLine("test");
            if (PassonClass.mariobig == true)
            {
                second.Imdead();
                Console.WriteLine("TRIGGERED");
            }
        }
    }
}
