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
	public partial class Lucky_block
	{
		/// <summary>
		/// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
		/// This method is called when the Entity is added to managers. Entities which are instantiated but not
		/// added to managers will not have this method called.
		/// </summary>
		public bool Used3 = false;
		public bool HasPilzInIt = false;
		private void CustomInitialize()
		{
			ThisBlockTouched = false;
		}

		private void CustomActivity()
		{
			if (this.X >= 375 && this.X <= 390)
			{
				HasPilzInIt = true;
			}
		}

		private void CustomDestroy()
		{
		}

		private static void CustomLoadStaticContent(string contentManagerName)
		{

		}
		public void HandleHit()
		{
			SpriteInstanceTexture = luckyblockhasbeentouched;
			Used3 = true;
		}
	}
}
