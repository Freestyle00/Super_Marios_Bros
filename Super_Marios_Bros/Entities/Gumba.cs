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
		public float horin = -1;
		float deadgumbawalking = 0.1f;
		AnimationController animationController;
		public bool gumbadead = false;
		Super_Marios_Bros.Input.KeyboordInput input = new Super_Marios_Bros.Input.KeyboordInput();
		private void CustomInitialize()
		{
			Animations();
			InitializePlatformerInput(input);
		}

		private void CustomActivity()
		{
			animationController.Activity();
			PassonClass.GUMBATEST = this.Velocity.X;
			Walking();
		}

		private void CustomDestroy()
		{


		}

		private static void CustomLoadStaticContent(string contentManagerName)
		{


		}
		public void Deadgumba()
		{
			gumbadead = true;
			Console.WriteLine("Gumba dead true");
		}
		void Walking()
		{
			input.HorinzontalInputa(horin);
			InitializePlatformerInput(input);
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

			var DieLayer = new AnimationLayer();
			DieLayer.EveryFrameAction = () =>
			{
				//Console.WriteLine("This should come if you did it right if not well GOOD LUCK");
				if (gumbadead == true) //why isnt this crap working
				{
					this.Velocity.X = 0;
					Console.WriteLine("he cant walk");
					HeightOftheRectangle = -8;
					SpriteInstance.Y = -8;
					deadgumbawalking -= TimeManager.SecondDifference;
					this.Y -= 8;
					if (deadgumbawalking <= 0)
					{
						deadgumbawalking = 0.1f;
						Console.WriteLine("SNAP");
						this.Destroy();

					}
					Console.WriteLine("the anim should play now");
					return "Gumba_died";
				}
				return null;
			};
			animationController.Layers.Add(DieLayer);
			//var walkLayer = new AnimationLayer();
			//walkLayer.EveryFrameAction = () 













			//{
			//    if (this.Velocity.X != 0)
			//    {
			//        if (PassonClass.mariobig == true)
			//        {
			//            return "Walking_Big" + DirectionFacing;
			//        }
			//        return "Walking_small" + DirectionFacing;
			//    }
			//    return null;
			//};
			//animationController.Layers.Add(walkLayer);

		}
	}
}
