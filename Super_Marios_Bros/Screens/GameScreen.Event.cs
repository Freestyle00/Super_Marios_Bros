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
                Console.WriteLine("was pushed down true");
                bool hasDestroyedBlock = false;
                // First see if the player (first) BlockCollision has collided with any 
                // of the blocks
                for (int i = 0; i < Lucky_blockList.Count; i++)
                {
                    //Console.WriteLine("New Brick");
                    if (Lucky_blockList[i].AxisAlignedRectangleInstance.CollideAgainst(first.CollisionThing) && Lucky_blockList[i].Used3 == false)
                    {
                        // New code:
                        Console.WriteLine("Collided");
                        Lucky_blockList[i].HandleHit();
                        hasDestroyedBlock = true;
                        if (Lucky_blockList[i].HasPilzInIt == true)
                        {
                            var mushroom = Factories.MushroomFactory.CreateNew();
                            mushroom.X = Lucky_blockList[i].X;
                            mushroom.Y = Lucky_blockList[i].Y + 17;
                        }
                        break;
                    }
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
                // First see if the player (first) BlockCollision has collided with any 
                // of the blocks
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
                // the BlockCollision doesn't collide with any of the blocks, so just destroy whichever block
                // we collided with
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
                        CombinedShapeCollection.RemoveRectangle(A_BrickList[i].AxisAlignedRectangleInstance);
                        GumbaList[i].Deadgumba();
                        hasDestroyedBlock = true;
                        break;
                    }
                }
                if (!hasDestroyedBlock)
                {
                    // New code:
                    Console.WriteLine("The other way");

                    CombinedShapeCollection.RemoveRectangle(second.AxisAlignedRectangleInstance);
                    CombinedShapeCollection.RemoveRectangle(second.LeftMarioDead);
                    CombinedShapeCollection.RemoveRectangle(second.RightMarioDead);
                    second.Deadgumba();
                }
            }
            else if (MarioInstance.AxisAlignedRectangleInstance.CollideAgainst(second.RightMarioDead) || MarioInstance.AxisAlignedRectangleInstance.CollideAgainst(second.LeftMarioDead) && second.gumbadead == false)
            {
                second.Destroy();
                if (PassonClass.mariobig == true)
                {
                    PassonClass.mariobig = false;
                }
                else if (PassonClass.mariobig == false)
                {
                    RestartScreen(true, true);
                }
            }
        }       
        void OnGumbaListAxisAlignedRectangleInstanceVsSolidCollisionCollisionOccurred (Entities.Gumba first, FlatRedBall.TileCollisions.TileShapeCollection second) 
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
        void OnMarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstanceCollisionOccurred (Super_Marios_Bros.Entities.Mario first, Entities.Mushroom second) 
        {
            second.Destroy();
            PassonClass.mariobig = true;
        }        
        void OnMushroomListVsSolidCollisionCollisionOccurred (Entities.Mushroom first, FlatRedBall.TileCollisions.TileShapeCollection second) 
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
        void OnTurtleListVsSolidCollisionCollisionOccurred (Entities.Turtle first, FlatRedBall.TileCollisions.TileShapeCollection second) 
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

    }
}
