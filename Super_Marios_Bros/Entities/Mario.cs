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
using Microsoft.Xna.Framework.Input;

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
        Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];
        AnimationController animationController;
        private void CustomInitialize()
        {
            //var input = new Super_Marios_Bros.Input.KeyboordInput(); //TODO fix this shit cuased by you using a controller more also add the konami code and DO YOUR HOMEWORK AND IF YOU SEE THIS FUTURE ME DO ONE TASK FROM YOU MATHBOOK PLEASE 
            //InitializePlatformerInput(input);
            Animations();
            
            RunInput = InputManager.Keyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.LeftShift);
            
        }
        private void CustomActivity()
        {
            animationController.Activity();
            RUN();
            Marioisbignowheneedssomebiggershoes(); 
            Debugthings();
            Jumping();
            PassonClass.marioX = this.X;
            PassonClass.marioY = this.Y;
        }
        private void CustomDestroy()
        {

        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
        void Marioisbignowheneedssomebiggershoes()
        {
            if (PassonClass.mariobig == true)
            {
                AxisAlignedRectangleInstanceY = 8;
                AxisAlignedRectangleInstanceHeight = 32;
                CollisionThing.RelativeY = 24;
            }
            else if (PassonClass.mariobig == false)
            {
                AxisAlignedRectangleInstanceY = 0;
                AxisAlignedRectangleInstanceHeight = 16;
                CollisionThing.RelativeY = 8;
            }
        }
        void Jumping()
        {
            //Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];
            if (this.IsOnGround == true && InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space) || gamePad.ButtonPushed(Xbox360GamePad.Button.A))
            {
                //Mariojumpsound.Play(); //that gets annyoing after some time so i should not forget to decomment it
            }
        }
        void Debugthings()
        {
            if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.G))
            {
                PassonClass.mariobig = true;
            }
            if  (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.H))
            {
                PassonClass.mariobig = false;
            }
        }
        void RUN() //den den den den den den den den den den den den den den
        {
            animationController.Activity();
            if (RunInput.IsDown || gamePad.ButtonDown(Xbox360GamePad.Button.X))
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
        void Animations()
        {
            animationController = new AnimationController(SpriteInstance);
            var idleLayer = new AnimationLayer();
            idleLayer.EveryFrameAction = () =>
            {
                if (PassonClass.mariobig == true)
                {
                    return "Idle_Big" + DirectionFacing;
                }
                return "Idle_small" + DirectionFacing;
            };
            animationController.Layers.Add(idleLayer);

            var walkLayer = new AnimationLayer();
            walkLayer.EveryFrameAction = () =>
            {
                if (this.Velocity.X != 0)
                {
                    if (PassonClass.mariobig == true)
                    {
                        return "Walking_Big" + DirectionFacing;
                    }
                    return "Walking_small" + DirectionFacing;
                }
                return null;
            };
            animationController.Layers.Add(walkLayer);

            var runLayer = new AnimationLayer();
            runLayer.EveryFrameAction = () =>
            {
                if (this.XVelocity != 0 && this.GroundMovement == PlatformerValuesStatic["Running"])
                {
                    if (PassonClass.mariobig == true)
                    {
                        return "Running_Big" + DirectionFacing;
                    }
                    return "Running_small" + DirectionFacing;
                }
                return null;
            };
            animationController.Layers.Add(runLayer);
            var skidLayer = new AnimationLayer();
            skidLayer.EveryFrameAction = () =>
            {
                if (this.XVelocity != 0 && this.HorizontalInput.Value != 0 &&
                    Math.Sign(XVelocity) != Math.Sign(this.HorizontalInput.Value))
                {
                    if (PassonClass.mariobig == true)
                    {
                        return "Drifting_Big" + DirectionFacing;
                    }
                    return "Drifting_small" + DirectionFacing;
                }
                return null;
            };
            animationController.Layers.Add(skidLayer);
            var jumpLayer = new AnimationLayer();
            jumpLayer.EveryFrameAction = () =>
            {
                if (this.IsOnGround == false) //&& YVelocity > 0
                {
                    if (PassonClass.mariobig == true)
                    {
                        return "Jumping_Big" + DirectionFacing;
                    }
                    return "Jumping_small" + DirectionFacing;
                }
                return null;
            };
            animationController.Layers.Add(jumpLayer);
        }
    }
}