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
//using Side = FlatRedBall.Math.Collision.CollisionEnumerations.Side;


namespace Super_Marios_Bros.Entities
{
    public partial class Gumba
    {
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        /// 
        float try_it = 0.5f;
        AnimationController animationController;
        private void CustomInitialize()
        {
            this.Velocity.X = -100;

        }

        private void CustomActivity()
        {
            PassonClass.GUMBATEST = this.Velocity.X;
            Animations();
            Bouncybouncy();
        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
        void Bouncybouncy()
        {
            /*Side side = Side.None;

            if t.CollideAgainstMove(rectangle2, 0, 1))
            {
                if (rectangle1.LastMoveCollisionReposition.X > 0)
                    side = Side.Right;
                else if (rectangle1.LastMoveCollisionReposition.X < 0)
                    side = Side.Left;
                else if (rectangle1.LastMoveCollisionReposition.Y > 0)
                    side = Side.Top;
                else if (rectangle1.LastMoveCollisionReposition.Y < 0)
                    side = Side.Bottom;
            }*/
            if (Velocity.X == 0)
            {
                this.Velocity.X = 100;
                Console.WriteLine("Right");
                try_it -= TimeManager.SecondDifference;
            }
            if (Velocity.X <= 0 && try_it <= 0)
            {
                this.Velocity.X = -100;
                Console.WriteLine("Left");
                try_it = 0.5f;
            }
        }
        void Animations()
        {
            animationController = new AnimationController(SpriteInstance);
            var idleLayer = new AnimationLayer();
            idleLayer.EveryFrameAction = () =>
            { 
                return "Gumba_walking";
            };
            animationController.Layers.Add(idleLayer);
            //var DIELayer = new AnimationLayer();
            //DIELayer.EveryFrameAction = () =>
            //{
            //    if (this.Velocity.X != 0)
            //    {
            //        return "Gumba_died";
            //    }
            //    return null;
            //};
            //animationController.Layers.Add(DIELayer);
        }
    }
}
