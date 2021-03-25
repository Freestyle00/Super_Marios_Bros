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
    public partial class Mario
    {
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        ///   AnimationController animationController;

        public IPressableInput RunInput { get; set; }

        AnimationController animationController;
        private void CustomInitialize()
        {
            animations();
            RunInput = InputManager.Keyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.LeftShift);

        }

        private void CustomActivity()
        {
            animationController.Activity();
            RUN();
            PassonClass.marioX = this.X;
            PassonClass.marioY = this.Y;
        }

        private void CustomDestroy()
        {

        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
        void RUN()
        {
            animationController.Activity();
            if (RunInput.IsDown)
            {
                this.GroundMovement = PlatformerValuesStatic["Running"];
                this.AirMovement = PlatformerValuesStatic["RunningAir"];
            }
            else
            {
                this.GroundMovement = PlatformerValuesStatic["Ground"];
                this.AirMovement = PlatformerValuesStatic["Air"];
            }
            
        }
        void animations()
        {
            animationController = new AnimationController(SpriteInstance);

            var idleLayer = new AnimationLayer();
            idleLayer.EveryFrameAction = () =>
            {
                return "Idle_small" + DirectionFacing;
            };
            animationController.Layers.Add(idleLayer);

            //var lookUpLayer = new AnimationLayer();
            //lookUpLayer.EveryFrameAction = () =>
            //{
            //    if (this.VerticalInput.Value > 0)
            //    {
            //        return "LookUp" + DirectionFacing;
            //    }
            //    return null;
            //};
            //animationController.Layers.Add(lookUpLayer);

            var walkLayer = new AnimationLayer();
            walkLayer.EveryFrameAction = () =>
            {
                if (this.Velocity.X != 0)
                {
                    return "Walking_small" + DirectionFacing;
                }
                return null;
            };
            animationController.Layers.Add(walkLayer);

            var skidLayer = new AnimationLayer();
            skidLayer.EveryFrameAction = () =>
            {
                if (this.XVelocity != 0 && this.HorizontalInput.Value != 0 &&
                    Math.Sign(XVelocity) != Math.Sign(this.HorizontalInput.Value))
                {
                    return "Drifting_small" + DirectionFacing;
                }
                return null;
            };
            animationController.Layers.Add(skidLayer);

            var runLayer = new AnimationLayer();
            runLayer.EveryFrameAction = () =>
            {
                if (this.XVelocity != 0 && RunInput.IsDown)
                {
                    return "Running_small" + DirectionFacing;
                }
                return null;
            };
            animationController.Layers.Add(runLayer);



            //var duckLayer = new AnimationLayer();
            //duckLayer.EveryFrameAction = () =>
            //{
            //    if (this.VerticalInput.Value < 0) { return "Duck" + DirectionFacing; }
            //    return null;
            //}; animationController.Layers.Add(duckLayer); var fallLayer = new AnimationLayer(); fallLayer.EveryFrameAction = () =>
            //{
            //    if (this.IsOnGround == false)
            //    {
            //        return "Fall" + DirectionFacing;
            //    }
            //    return null;
            //};
            //animationController.Layers.Add(fallLayer);

            var jumpLayer = new AnimationLayer();
            jumpLayer.EveryFrameAction = () =>
            {
                if (this.IsOnGround == false) //&& YVelocity > 0
                {
                    return "Jumping_small" + DirectionFacing;
                }
                return null;
            };
            animationController.Layers.Add(jumpLayer);

            //var runJump = new AnimationLayer();
            //runJump.EveryFrameAction = () =>
            //{
            //    if (this.IsOnGround == false && RunInput.IsDown)
            //    {
            //        return "RunJump" + DirectionFacing;
            //    }
            //    return null;
            //};
            //animationController.Layers.Add(runJump);

        }


    }
}
