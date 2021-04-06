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
        void OnMarioInstanceVsGumbaListget_dunkedCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.Gumba second) 
        {
            if (this.MarioInstanceVsGumbaListget_dunkedCollisionOccurred != null)
            {
                MarioInstanceVsGumbaListget_dunkedCollisionOccurred(first, second);
            }
        }
        void OnMarioInstanceVsGumbaListLeftMarioDeadCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.Gumba second) 
        {
            if (this.MarioInstanceVsGumbaListLeftMarioDeadCollisionOccurred != null)
            {
                MarioInstanceVsGumbaListLeftMarioDeadCollisionOccurred(first, second);
            }
        }
        void OnMarioInstanceVsGumbaListRightMarioDeadCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.Gumba second) 
        {
            if (this.MarioInstanceVsGumbaListRightMarioDeadCollisionOccurred != null)
            {
                MarioInstanceVsGumbaListRightMarioDeadCollisionOccurred(first, second);
            }
        }
        void OnMarioInstanceVsA_BrickListHitbox_from_downCollisionOccurredTunnel (Super_Marios_Bros.Entities.Mario first, Entities.A_Brick second) 
        {
            if (this.MarioInstanceVsA_BrickListHitbox_from_downCollisionOccurred != null)
            {
                MarioInstanceVsA_BrickListHitbox_from_downCollisionOccurred(first, second);
            }
        }
    }
}
