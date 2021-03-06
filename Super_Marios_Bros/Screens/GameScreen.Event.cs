using System;
namespace Super_Marios_Bros.Screens
{
	public partial class GameScreen
	{
		void OnMarioInstanceVsLucky_blockListCollisionOccurred(Super_Marios_Bros.Entities.Mario first, Entities.Lucky_block second)
		{
			Console.WriteLine("Collsion occured");
			bool wasPushedDown = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition.Y < 0;
			if (wasPushedDown)
			{
				bool hasDestroyedBlock = false;
				Console.WriteLine("was pushed down true");
				for (int i = 0; i < Lucky_blockList.Count; i++)
				{	
				if (Lucky_blockList[i].AxisAlignedRectangleInstance.CollideAgainst(first.CollisionThing) && Lucky_blockList[i].Used3 == false)
					{
						
						Console.WriteLine("Collided");
						if (Lucky_blockList[i].HasPilzInIt && Lucky_blockList[i].Used3 == false)
						{
							var mushroom = Factories.MushroomFactory.CreateNew();
							mushroom.X = Lucky_blockList[i].X;
							mushroom.Y = Lucky_blockList[i].Y + 17;
							hasDestroyedBlock = true;
						}
						if (Lucky_blockList[i].HasPilzInIt == false && !Lucky_blockList[i].Used3)
						{
							PassonClass.Coins += 1;
						}
						Lucky_blockList[i].HandleHit();
						break;
					}
				}
				if (!hasDestroyedBlock)
				{
					// New code:
					Console.WriteLine("The other way");
					if (second.HasPilzInIt == true && second.Used3 == false)
					{
						var mushroom = Factories.MushroomFactory.CreateNew();
						mushroom.X = second.X;
						mushroom.Y = second.Y + 17;
					}
					if (!second.HasPilzInIt && !second.Used3)
					{
						PassonClass.Coins += 1;
					}
					second.HandleHit();
				}
			}
		}
		void OnMarioInstanceVsA_BrickListCollisionOccurred(Super_Marios_Bros.Entities.Mario first, Entities.A_Brick second)
		{
			Console.WriteLine("Collsion occured");
			bool wasPushedDown = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition.Y < 0;
			if (wasPushedDown && PassonClass.mariobig)
			{
				Console.WriteLine("was pushed down true");
				bool hasDestroyedBlock = false;
				for (int i = 0; i < A_BrickList.Count; i++)
				{
					//Console.WriteLine("New Brick");
					if (A_BrickList[i].AxisAlignedRectangleInstance.CollideAgainst(first.CollisionThing))
					{
						// New code:
						Console.WriteLine("Collided");
						CombinedShapeCollection.RemoveRectangle(A_BrickList[i].AxisAlignedRectangleInstance);
						A_BrickList[i].Imdead();
						hasDestroyedBlock = true;
						break;
					}
				}
				if (!hasDestroyedBlock)
				{
					// New code:
					Console.WriteLine("The other way");

					CombinedShapeCollection.RemoveRectangle(second.AxisAlignedRectangleInstance);

					second.Imdead();
				}
			}
		}
		void OnMarioInstanceVsGumbaListAxisAlignedRectangleInstanceCollisionOccurred(Super_Marios_Bros.Entities.Mario first, Entities.Gumba second)
		{
			Console.WriteLine("Collsion occured");
			bool wasPushedDown = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition.Y > 0;
			bool hasDestroyedBlock = false;
			if (wasPushedDown)
			{
				for (int i = 0; i < GumbaList.Count; i++)
				{
					if (GumbaList[i].AxisAlignedRectangleInstance.CollideAgainst(first.DieThing))
					{
						Console.WriteLine("Collided");
						MarioInstance.Velocity.Y = 160;
						CombinedShapeCollection.RemoveRectangle(A_BrickList[i].AxisAlignedRectangleInstance);
						GumbaList[i].Deadgumba();
						PassonClass.Score += 100;
						hasDestroyedBlock = true;
						break;
					}
				}
				if (!hasDestroyedBlock)
				{
					// New code:
					Console.WriteLine("The other way");
					MarioInstance.Velocity.Y = 160;
					second.Deadgumba();
					PassonClass.Score += 100;
				}
			}
			else if (MarioInstance.AxisAlignedRectangleInstance.CollideAgainst(second.RightMarioDead) || MarioInstance.AxisAlignedRectangleInstance.CollideAgainst(second.LeftMarioDead))
			{
				second.Destroy();
				if (PassonClass.mariobig == true)
				{
					PassonClass.mariobig = false;
				}
				else if (PassonClass.mariobig == false)
				{
					HandleMarioDead();
				}
			}
		}
		void OnGumbaListAxisAlignedRectangleInstanceVsSolidCollisionCollisionOccurred(Entities.Gumba first, FlatRedBall.TileCollisions.TileShapeCollection second)
		{
			var collisionReposition = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition;
			var hasCollidedWithWall = collisionReposition.X != 0;
			if (hasCollidedWithWall)
			{
				var isWallToTheRight = collisionReposition.X < 0;

				if (isWallToTheRight && first.horin == 1)
				{
					first.horin = -1; //LEFT
				}
				else if (!isWallToTheRight && first.horin == -1)
				{
					first.horin = 1; //RIGHT
				}
			}
		}
		void OnMarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstanceCollisionOccurred(Super_Marios_Bros.Entities.Mario first, Entities.Mushroom second)
		{
			second.Destroy();
			PassonClass.Score += 100;
			PassonClass.mariobig = true;
		}
		void OnMushroomListVsSolidCollisionCollisionOccurred(Entities.Mushroom first, FlatRedBall.TileCollisions.TileShapeCollection second)
		{
			var collisionReposition = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition;
			var hasCollidedWithWall = collisionReposition.X != 0;
			if (hasCollidedWithWall)
			{
				var isWallToTheRight = collisionReposition.X < 0;

				if (isWallToTheRight && first.horin == 1)
				{
					first.horin = -1; //LEFT
				}
				else if (!isWallToTheRight && first.horin == -1)
				{
					first.horin = 1; //RIGHT
				}
			}
		}
		void OnTurtleListVsSolidCollisionCollisionOccurred(Entities.Turtle first, FlatRedBall.TileCollisions.TileShapeCollection second)
		{
			var collisionReposition = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition;
			var hasCollidedWithWall = collisionReposition.X != 0;
			if (hasCollidedWithWall)
			{
				var isWallToTheRight = collisionReposition.X < 0;

				if (isWallToTheRight && first.horin == 1)
				{
					first.horin = -1; //LEFT
				}
				else if (!isWallToTheRight && first.horin == -1)
				{
					first.horin = 1; //RIGHT
				}
			}
		}
		void OnMarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstanceCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.Turtle second) 
		{
			Console.WriteLine("Collsion occured");
			bool wasPushedDown = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition.Y > 0;
			if (wasPushedDown)
			{
				Console.WriteLine("was pushed down true");
				bool hasDestroyedBlock = false;
				for (int i = 0; i < TurtleList.Count; i++)
				{
					if (TurtleList[i].AxisAlignedRectangleInstance.CollideAgainst(first.CollisionThing))
					{
						Console.WriteLine("Collided");
						MarioInstance.Velocity.Y = 160;
						TurtleList[i].GotHit = true;
						hasDestroyedBlock = true;
						break;
					}
				}
				if (!hasDestroyedBlock)
				{
					MarioInstance.Velocity.Y = 160;
					second.GotHit = true;
				}
			}
			else if (MarioInstance.AxisAlignedRectangleInstance.CollideAgainst(second.RightMarioDead) || MarioInstance.AxisAlignedRectangleInstance.CollideAgainst(second.LeftMarioDead))
			{
				second.Destroy();
				if (PassonClass.mariobig == true)
				{
					PassonClass.mariobig = false;
				}
				else if (PassonClass.mariobig == false)
				{
					HandleMarioDead();
				}
			}
		}        
		void OnMarioInstanceVsCoinListCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.Coin second) 
        {
			second.Destroy();
			PassonClass.Coins += 1;
        }
	}
}
