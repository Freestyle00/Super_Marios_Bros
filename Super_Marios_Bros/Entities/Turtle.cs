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
    public partial class Turtle
    {
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        public bool GotHit = false;
        public bool GotHit2nd = false;
        public float horin = 1;
        Super_Marios_Bros.Input.KeyboordInput input = new Super_Marios_Bros.Input.KeyboordInput();
        AnimationController animationController;
        private void CustomInitialize()
        {
            Animations();
            InitializePlatformerInput(input);

        }
        private void CustomActivity()
        {
            animationController.Activity();
            TurtleHiddenDoingThings();
            input.HorinzontalInputa(horin);
            InitializePlatformerInput(input);
        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
        void TurtleHiddenDoingThings()
        {
            if (GotHit2nd)
            {
               //Ita juat here that that thing down it doesnt happen
            }
            else if (GotHit)
            {
                horin = 0;
            }
        }
        public void TurtleKickStart(string Dir)
        {
            if (Dir == "R")
            {
                this.Velocity.X = 80;
            }
            else if (Dir == "L")
            {
                this.Velocity.X = -80;
            }
        }
        void Animations()
        {
            animationController = new AnimationController(SpriteInstance);
            var walkLayer = new AnimationLayer();
            walkLayer.EveryFrameAction = () =>
            {
                if (this.Velocity.X != 0)
                { 
                   return "Turtle_Walking" + DirectionFacing;
                }
                return null;
            };
            animationController.Layers.Add(walkLayer);

            var HiddenLayer = new AnimationLayer();
            HiddenLayer.EveryFrameAction = () =>
            {
                if (GotHit)
                {
                    return "Turtle_Hidden";
                }
                return null;
            };
            animationController.Layers.Add(HiddenLayer);
        }
    }
}
