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
    public partial class A_Brick
    {
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
        {
            //this.Velocity.Y = 100;

        }

        private void CustomActivity()
        {


        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        public void Imdead()
        {
            var deadbrick = Factories.A_Brick_being_destroyedFactory.CreateNew();
            deadbrick.X = this.X;
            deadbrick.Y = this.Y;

            this.Destroy();
        }
    }
}