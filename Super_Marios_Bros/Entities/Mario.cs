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
        Super_Marios_Bros.Input.KeyboordInput input = new Super_Marios_Bros.Input.KeyboordInput();
        //IPressableInput jumpinput = InputManager.Keyboard.GetKey(Keys.Space);
        //IPressableInput jumpinputgamepad = InputManager.Xbox360GamePads[0].GetButton(Xbox360GamePad.Button.A);
        private void CustomInitialize()
        {
             //TODO fix this shit cuased by you using a controller more also add the konami code
            //InitializePlatformerInput(input);
            Animations();
            this.RunInput = InputManager.Keyboard.GetKey(Keys.LeftShift);
            
            InitializePlatformerInput(input);
        }
        partial void CustomInitializePlatformerInput()
        {
            if (InputDevice is FlatRedBall.Input.Keyboard keyboard)
            {
                this.JumpInput = keyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.Space);
            }
            else if (InputDevice is Xbox360GamePad gamepad)
            {
                this.JumpInput = gamepad.GetButton(Xbox360GamePad.Button.A);
            }
        }
        private void CustomActivity()
        {
            animationController.Activity();
            RUN();
            Marioisbignowheneedssomebiggershoes(); 
            Debugthings();
            Jumping();
            MyOwnInput();
        }
        private void CustomDestroy()
        {

        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
        void MyOwnInput() //better than vics it support brace for impact having TWO INPUT DEVICES simultaneously BETTEREVEN TAHN fo4
        {

            if (InputManager.Keyboard.KeyDown(Keys.D) || InputManager.Keyboard.KeyDown(Keys.Left))
            {
                input.HorinzontalInputa(1);
            }
            else if (InputManager.Keyboard.KeyDown(Keys.A) || InputManager.Keyboard.KeyDown(Keys.Right))
            {
                input.HorinzontalInputa(-1);
            }
            else if (InputManager.Keyboard.KeyDown(Keys.W) || InputManager.Keyboard.KeyDown(Keys.Up))
            {
                input.VerticalInputb(1);
            }
            else if (InputManager.Keyboard.KeyDown(Keys.S) || InputManager.Keyboard.KeyDown(Keys.Down))
            {
                input.VerticalInputb(-1);
            }
            else
            {
                input.HorinzontalInputa(0);
                input.VerticalInputb(0);
            }
            InitializePlatformerInput(input);
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
            if (this.IsOnGround == true && JumpInput.WasJustReleased)
            {
                Mariojumpsound.Play(); //that gets annyoing after some time so i should not forget to decomment it
            }
        }
        void Debugthings()
        {
            if (JumpInput.WasJustPressed)
            {
                Console.WriteLine("JUMP SOUND");
            }
            if (InputManager.Keyboard.KeyPushed(Keys.G))
            {
                PassonClass.mariobig = true;
            }
            if  (InputManager.Keyboard.KeyPushed(Keys.H))
            {
                PassonClass.mariobig = false;
            }
            PassonClass.marioX = this.X;
            PassonClass.marioY = this.Y;
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