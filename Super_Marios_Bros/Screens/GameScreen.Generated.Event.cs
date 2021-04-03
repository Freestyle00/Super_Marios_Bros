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
    }
}
