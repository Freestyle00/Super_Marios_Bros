using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;

namespace Super_Marios_Bros.Entities
{
    public partial class Mushroom
    {
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        public float horin = 1;
        Super_Marios_Bros.Input.KeyboordInput input = new Super_Marios_Bros.Input.KeyboordInput();
        private void CustomInitialize()
        {
            InitializePlatformerInput(input);
        }

        private void CustomActivity()
        {
            input.HorinzontalInputa(horin);
            InitializePlatformerInput(input);
        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }
}
