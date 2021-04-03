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
        void OnGumbaListVsSolidCollisionCollisionOccurredTunnel (Entities.Gumba first, FlatRedBall.TileCollisions.TileShapeCollection second) 
        {
            if (this.GumbaListVsSolidCollisionCollisionOccurred != null)
            {
                GumbaListVsSolidCollisionCollisionOccurred(first, second);
            }
        }
    }
}
