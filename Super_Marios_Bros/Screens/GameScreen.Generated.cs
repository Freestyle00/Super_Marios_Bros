#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math.Geometry;

namespace Super_Marios_Bros.Screens
{
    public partial class GameScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        
        protected FlatRedBall.TileGraphics.LayeredTileMap Map;
        protected FlatRedBall.TileCollisions.TileShapeCollection SolidCollision;
        protected FlatRedBall.TileCollisions.TileShapeCollection CloudCollision;
        private FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.A_Brick> A_BrickList;
        private Super_Marios_Bros.Entities.Mario MarioInstance;
        private FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Lucky_block> Lucky_blockList;
        private FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Gumba> GumbaList;
        private FlatRedBall.Math.Collision.PositionedObjectVsListRelationship<Super_Marios_Bros.Entities.Mario, Entities.Gumba> MarioInstanceVsGumbaListAxisAlignedRectangleInstance;
        private FlatRedBall.Math.Collision.DelegateCollisionRelationship<Super_Marios_Bros.Entities.Mario, FlatRedBall.TileCollisions.TileShapeCollection> MarioInstanceVsSolidCollision;
        private FlatRedBall.Math.Collision.DelegateSingleVsListRelationship<Super_Marios_Bros.Entities.Mario, Entities.Lucky_block> MarioInstanceVsLucky_blockList;
        private FlatRedBall.Math.Collision.CollidableListVsTileShapeCollectionRelationship<Entities.Gumba> GumbaListAxisAlignedRectangleInstanceVsSolidCollision;
        private FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.A_Brick_being_destroyed> A_Brick_being_destroyedList;
        private FlatRedBall.TileCollisions.TileShapeCollection CombinedShapeCollection;
        private FlatRedBall.Math.Collision.DelegateSingleVsListRelationship<Super_Marios_Bros.Entities.Mario, Entities.A_Brick> MarioInstanceVsA_BrickList;
        private FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Mushroom> MushroomList;
        private FlatRedBall.Math.Collision.PositionedObjectVsListRelationship<Super_Marios_Bros.Entities.Mario, Entities.Mushroom> MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstance;
        private FlatRedBall.Math.Collision.DelegateListVsSingleRelationship<Entities.Mushroom, FlatRedBall.TileCollisions.TileShapeCollection> MushroomListAxisAlignedRectangleInstanceVsSolidCollision;
        private FlatRedBall.Math.Collision.DelegateListVsListRelationship<Entities.Mushroom, Entities.A_Brick> MushroomListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance;
        private FlatRedBall.Math.Collision.DelegateListVsListRelationship<Entities.Mushroom, Entities.Lucky_block> MushroomListAxisAlignedRectangleInstanceVsLucky_blockListAxisAlignedRectangleInstance;
        private FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Turtle> TurtleList;
        private FlatRedBall.Math.Collision.DelegateListVsSingleRelationship<Entities.Turtle, FlatRedBall.TileCollisions.TileShapeCollection> TurtleListAxisAlignedRectangleInstanceVsSolidCollision;
        private FlatRedBall.Math.Collision.DelegateListVsListRelationship<Entities.Turtle, Entities.A_Brick> TurtleListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance;
        private FlatRedBall.Math.Collision.DelegateSingleVsListRelationship<Super_Marios_Bros.Entities.Mario, Entities.Turtle> MarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance;
        private FlatRedBall.Math.Collision.ListVsListRelationship<Entities.Lucky_block, Entities.Turtle> Lucky_blockListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance;
        private FlatRedBall.Math.Collision.DelegateListVsListRelationship<Entities.Gumba, Entities.Turtle> GumbaListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance;
        public event System.Action<Super_Marios_Bros.Entities.Mario, Entities.Lucky_block> MarioInstanceVsLucky_blockListCollisionOccurred;
        public event System.Action<Super_Marios_Bros.Entities.Mario, Entities.A_Brick> MarioInstanceVsA_BrickListCollisionOccurred;
        public event System.Action<Super_Marios_Bros.Entities.Mario, Entities.Gumba> MarioInstanceVsGumbaListAxisAlignedRectangleInstanceCollisionOccurred;
        public event System.Action<Entities.Gumba, FlatRedBall.TileCollisions.TileShapeCollection> GumbaListAxisAlignedRectangleInstanceVsSolidCollisionCollisionOccurred;
        public event System.Action<Super_Marios_Bros.Entities.Mario, Entities.Mushroom> MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstanceCollisionOccurred;
        public event System.Action<Entities.Mushroom, FlatRedBall.TileCollisions.TileShapeCollection> MushroomListVsSolidCollisionCollisionOccurred;
        public event System.Action<Entities.Turtle, FlatRedBall.TileCollisions.TileShapeCollection> TurtleListVsSolidCollisionCollisionOccurred;
        public event System.Action<Super_Marios_Bros.Entities.Mario, Entities.Turtle> MarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstanceCollisionOccurred;
        public GameScreen () 
        	: base ("GameScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            // Not instantiating for FlatRedBall.TileGraphics.LayeredTileMap Map in Screens\GameScreen (Screen) because properties on the object prevent it
            // Not instantiating for FlatRedBall.TileCollisions.TileShapeCollection SolidCollision in Screens\GameScreen (Screen) because properties on the object prevent it
            // Not instantiating for FlatRedBall.TileCollisions.TileShapeCollection CloudCollision in Screens\GameScreen (Screen) because properties on the object prevent it
            A_BrickList = new FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.A_Brick>();
            A_BrickList.Name = "A_BrickList";
            MarioInstance = new Super_Marios_Bros.Entities.Mario(ContentManagerName, false);
            MarioInstance.Name = "MarioInstance";
            Lucky_blockList = new FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Lucky_block>();
            Lucky_blockList.Name = "Lucky_blockList";
            GumbaList = new FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Gumba>();
            GumbaList.Name = "GumbaList";
            A_Brick_being_destroyedList = new FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.A_Brick_being_destroyed>();
            A_Brick_being_destroyedList.Name = "A_Brick_being_destroyedList";
            CombinedShapeCollection = new FlatRedBall.TileCollisions.TileShapeCollection();
            MushroomList = new FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Mushroom>();
            MushroomList.Name = "MushroomList";
            TurtleList = new FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Turtle>();
            TurtleList.Name = "TurtleList";
                MarioInstanceVsGumbaListAxisAlignedRectangleInstance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(MarioInstance, GumbaList);
    MarioInstanceVsGumbaListAxisAlignedRectangleInstance.SetSecondSubCollision(item => item.AxisAlignedRectangleInstance);
    MarioInstanceVsGumbaListAxisAlignedRectangleInstance.Name = "MarioInstanceVsGumbaListAxisAlignedRectangleInstance";
    MarioInstanceVsGumbaListAxisAlignedRectangleInstance.SetMoveCollision(1f, 1f);

                {
        var temp = new FlatRedBall.Math.Collision.DelegateCollisionRelationship<Super_Marios_Bros.Entities.Mario, FlatRedBall.TileCollisions.TileShapeCollection>(MarioInstance, SolidCollision);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        MarioInstanceVsSolidCollision = temp;
    }
    MarioInstanceVsSolidCollision.Name = "MarioInstanceVsSolidCollision";

                {
        var temp = new FlatRedBall.Math.Collision.DelegateSingleVsListRelationship<Super_Marios_Bros.Entities.Mario, Entities.Lucky_block>(MarioInstance, Lucky_blockList);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        MarioInstanceVsLucky_blockList = temp;
    }
    MarioInstanceVsLucky_blockList.Name = "MarioInstanceVsLucky_blockList";

                GumbaListAxisAlignedRectangleInstanceVsSolidCollision = FlatRedBall.Math.Collision.CollisionManagerTileShapeCollectionExtensions.CreateTileRelationship(FlatRedBall.Math.Collision.CollisionManager.Self, GumbaList, SolidCollision);
    GumbaListAxisAlignedRectangleInstanceVsSolidCollision.SetFirstSubCollision(item => item.AxisAlignedRectangleInstance);
    GumbaListAxisAlignedRectangleInstanceVsSolidCollision.Name = "GumbaListAxisAlignedRectangleInstanceVsSolidCollision";
    GumbaListAxisAlignedRectangleInstanceVsSolidCollision.SetBounceCollision(0f, 1f, 1f);

                {
        var temp = new FlatRedBall.Math.Collision.DelegateSingleVsListRelationship<Super_Marios_Bros.Entities.Mario, Entities.A_Brick>(MarioInstance, A_BrickList);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        MarioInstanceVsA_BrickList = temp;
    }
    MarioInstanceVsA_BrickList.Name = "MarioInstanceVsA_BrickList";

                MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(MarioInstance, MushroomList);
    MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstance.SetFirstSubCollision(item => item.AxisAlignedRectangleInstance);
    MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstance.SetSecondSubCollision(item => item.AxisAlignedRectangleInstance);
    MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstance.Name = "MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstance";
    MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstance.SetMoveCollision(1f, 1f);

                {
        var temp = new FlatRedBall.Math.Collision.DelegateListVsSingleRelationship<Entities.Mushroom, FlatRedBall.TileCollisions.TileShapeCollection>(MushroomList, SolidCollision);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, first.AxisAlignedRectangleInstance, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        MushroomListAxisAlignedRectangleInstanceVsSolidCollision = temp;
    }
    MushroomListAxisAlignedRectangleInstanceVsSolidCollision.Name = "MushroomListAxisAlignedRectangleInstanceVsSolidCollision";

                {
        var temp = new FlatRedBall.Math.Collision.DelegateListVsListRelationship<Entities.Mushroom, Entities.A_Brick>(MushroomList, A_BrickList);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, first.AxisAlignedRectangleInstance, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        MushroomListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance = temp;
    }
    MushroomListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance.CollisionLimit = FlatRedBall.Math.Collision.CollisionLimit.All;
    MushroomListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance.Name = "MushroomListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance";

                {
        var temp = new FlatRedBall.Math.Collision.DelegateListVsListRelationship<Entities.Mushroom, Entities.Lucky_block>(MushroomList, Lucky_blockList);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, first.AxisAlignedRectangleInstance, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        MushroomListAxisAlignedRectangleInstanceVsLucky_blockListAxisAlignedRectangleInstance = temp;
    }
    MushroomListAxisAlignedRectangleInstanceVsLucky_blockListAxisAlignedRectangleInstance.CollisionLimit = FlatRedBall.Math.Collision.CollisionLimit.All;
    MushroomListAxisAlignedRectangleInstanceVsLucky_blockListAxisAlignedRectangleInstance.Name = "MushroomListAxisAlignedRectangleInstanceVsLucky_blockListAxisAlignedRectangleInstance";

                {
        var temp = new FlatRedBall.Math.Collision.DelegateListVsSingleRelationship<Entities.Turtle, FlatRedBall.TileCollisions.TileShapeCollection>(TurtleList, SolidCollision);
        var isCloud = true;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, first.AxisAlignedRectangleInstance, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        TurtleListAxisAlignedRectangleInstanceVsSolidCollision = temp;
    }
    TurtleListAxisAlignedRectangleInstanceVsSolidCollision.Name = "TurtleListAxisAlignedRectangleInstanceVsSolidCollision";

                {
        var temp = new FlatRedBall.Math.Collision.DelegateListVsListRelationship<Entities.Turtle, Entities.A_Brick>(TurtleList, A_BrickList);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, first.AxisAlignedRectangleInstance, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        TurtleListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance = temp;
    }
    TurtleListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance.CollisionLimit = FlatRedBall.Math.Collision.CollisionLimit.All;
    TurtleListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance.Name = "TurtleListAxisAlignedRectangleInstanceVsA_BrickListAxisAlignedRectangleInstance";

                {
        var temp = new FlatRedBall.Math.Collision.DelegateSingleVsListRelationship<Super_Marios_Bros.Entities.Mario, Entities.Turtle>(MarioInstance, TurtleList);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        MarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance = temp;
    }
    MarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.Name = "MarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance";

                Lucky_blockListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(Lucky_blockList, TurtleList);
    Lucky_blockListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.SetFirstSubCollision(item => item.AxisAlignedRectangleInstance);
    Lucky_blockListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.SetSecondSubCollision(item => item.AxisAlignedRectangleInstance);
    Lucky_blockListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.CollisionLimit = FlatRedBall.Math.Collision.CollisionLimit.All;
    Lucky_blockListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.ListVsListLoopingMode = FlatRedBall.Math.Collision.ListVsListLoopingMode.PreventDoubleChecksPerFrame;
    Lucky_blockListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.Name = "Lucky_blockListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance";
    Lucky_blockListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.SetMoveCollision(1f, 1f);

                {
        var temp = new FlatRedBall.Math.Collision.DelegateListVsListRelationship<Entities.Gumba, Entities.Turtle>(GumbaList, TurtleList);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, first.AxisAlignedRectangleInstance, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        GumbaListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance = temp;
    }
    GumbaListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.CollisionLimit = FlatRedBall.Math.Collision.CollisionLimit.All;
    GumbaListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.Name = "GumbaListAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance";

            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            if (SolidCollision != null)
            {
                SolidCollision.Visible = false;
            }
            FlatRedBall.TileCollisions.TileShapeCollectionLayeredTileMapExtensions.AddCollisionFromTilesWithType(SolidCollision, Map, "SolidCollision", false);
            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            if (CloudCollision != null)
            {
                CloudCollision.Visible = false;
            }
            FlatRedBall.TileCollisions.TileShapeCollectionLayeredTileMapExtensions.AddCollisionFromTilesWithType(CloudCollision, Map, "CloudCollision", false);
            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            if (CombinedShapeCollection != null)
            {
                CombinedShapeCollection.Visible = false;
            }
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            Factories.A_BrickFactory.Initialize(ContentManagerName);
            Factories.Lucky_blockFactory.Initialize(ContentManagerName);
            Factories.GumbaFactory.Initialize(ContentManagerName);
            Factories.A_Brick_being_destroyedFactory.Initialize(ContentManagerName);
            Factories.MushroomFactory.Initialize(ContentManagerName);
            Factories.TurtleFactory.Initialize(ContentManagerName);
            Factories.A_BrickFactory.AddList(A_BrickList);
            Factories.Lucky_blockFactory.AddList(Lucky_blockList);
            Factories.GumbaFactory.AddList(GumbaList);
            Factories.A_Brick_being_destroyedFactory.AddList(A_Brick_being_destroyedList);
            Factories.MushroomFactory.AddList(MushroomList);
            Factories.TurtleFactory.AddList(TurtleList);
            MarioInstance.AddToManagers(mLayer);
            FlatRedBall.TileEntities.TileEntityInstantiator.CreateEntitiesFrom(Map);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                for (int i = A_BrickList.Count - 1; i > -1; i--)
                {
                    if (i < A_BrickList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        A_BrickList[i].Activity();
                    }
                }
                MarioInstance.Activity();
                for (int i = Lucky_blockList.Count - 1; i > -1; i--)
                {
                    if (i < Lucky_blockList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        Lucky_blockList[i].Activity();
                    }
                }
                for (int i = GumbaList.Count - 1; i > -1; i--)
                {
                    if (i < GumbaList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        GumbaList[i].Activity();
                    }
                }
                for (int i = A_Brick_being_destroyedList.Count - 1; i > -1; i--)
                {
                    if (i < A_Brick_being_destroyedList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        A_Brick_being_destroyedList[i].Activity();
                    }
                }
                for (int i = MushroomList.Count - 1; i > -1; i--)
                {
                    if (i < MushroomList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        MushroomList[i].Activity();
                    }
                }
                for (int i = TurtleList.Count - 1; i > -1; i--)
                {
                    if (i < TurtleList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        TurtleList[i].Activity();
                    }
                }
            }
            else
            {
            }
            base.Activity(firstTimeCalled);
            if (!IsActivityFinished)
            {
                CustomActivity(firstTimeCalled);
            }
        }
        public override void Destroy () 
        {
            base.Destroy();
            Factories.A_BrickFactory.Destroy();
            Factories.Lucky_blockFactory.Destroy();
            Factories.GumbaFactory.Destroy();
            Factories.A_Brick_being_destroyedFactory.Destroy();
            Factories.MushroomFactory.Destroy();
            Factories.TurtleFactory.Destroy();
            
            A_BrickList.MakeOneWay();
            Lucky_blockList.MakeOneWay();
            GumbaList.MakeOneWay();
            A_Brick_being_destroyedList.MakeOneWay();
            MushroomList.MakeOneWay();
            TurtleList.MakeOneWay();
            for (int i = A_BrickList.Count - 1; i > -1; i--)
            {
                A_BrickList[i].Destroy();
            }
            if (MarioInstance != null)
            {
                MarioInstance.Destroy();
                MarioInstance.Detach();
            }
            for (int i = Lucky_blockList.Count - 1; i > -1; i--)
            {
                Lucky_blockList[i].Destroy();
            }
            for (int i = GumbaList.Count - 1; i > -1; i--)
            {
                GumbaList[i].Destroy();
            }
            for (int i = A_Brick_being_destroyedList.Count - 1; i > -1; i--)
            {
                A_Brick_being_destroyedList[i].Destroy();
            }
            if (CombinedShapeCollection != null)
            {
                CombinedShapeCollection.Visible = false;
            }
            for (int i = MushroomList.Count - 1; i > -1; i--)
            {
                MushroomList[i].Destroy();
            }
            for (int i = TurtleList.Count - 1; i > -1; i--)
            {
                TurtleList[i].Destroy();
            }
            A_BrickList.MakeTwoWay();
            Lucky_blockList.MakeTwoWay();
            GumbaList.MakeTwoWay();
            A_Brick_being_destroyedList.MakeTwoWay();
            MushroomList.MakeTwoWay();
            TurtleList.MakeTwoWay();
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            MarioInstanceVsLucky_blockList.CollisionOccurred += OnMarioInstanceVsLucky_blockListCollisionOccurred;
            MarioInstanceVsLucky_blockList.CollisionOccurred += OnMarioInstanceVsLucky_blockListCollisionOccurredTunnel;
            MarioInstanceVsA_BrickList.CollisionOccurred += OnMarioInstanceVsA_BrickListCollisionOccurred;
            MarioInstanceVsA_BrickList.CollisionOccurred += OnMarioInstanceVsA_BrickListCollisionOccurredTunnel;
            MarioInstanceVsGumbaListAxisAlignedRectangleInstance.CollisionOccurred += OnMarioInstanceVsGumbaListAxisAlignedRectangleInstanceCollisionOccurred;
            MarioInstanceVsGumbaListAxisAlignedRectangleInstance.CollisionOccurred += OnMarioInstanceVsGumbaListAxisAlignedRectangleInstanceCollisionOccurredTunnel;
            GumbaListAxisAlignedRectangleInstanceVsSolidCollision.CollisionOccurred += OnGumbaListAxisAlignedRectangleInstanceVsSolidCollisionCollisionOccurred;
            GumbaListAxisAlignedRectangleInstanceVsSolidCollision.CollisionOccurred += OnGumbaListAxisAlignedRectangleInstanceVsSolidCollisionCollisionOccurredTunnel;
            MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstance.CollisionOccurred += OnMarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstanceCollisionOccurred;
            MarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstance.CollisionOccurred += OnMarioInstanceAxisAlignedRectangleInstanceVsMushroomListAxisAlignedRectangleInstanceCollisionOccurredTunnel;
            MushroomListAxisAlignedRectangleInstanceVsSolidCollision.CollisionOccurred += OnMushroomListVsSolidCollisionCollisionOccurred;
            MushroomListAxisAlignedRectangleInstanceVsSolidCollision.CollisionOccurred += OnMushroomListVsSolidCollisionCollisionOccurredTunnel;
            TurtleListAxisAlignedRectangleInstanceVsSolidCollision.CollisionOccurred += OnTurtleListVsSolidCollisionCollisionOccurred;
            TurtleListAxisAlignedRectangleInstanceVsSolidCollision.CollisionOccurred += OnTurtleListVsSolidCollisionCollisionOccurredTunnel;
            MarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.CollisionOccurred += OnMarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstanceCollisionOccurred;
            MarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstance.CollisionOccurred += OnMarioInstanceAxisAlignedRectangleInstanceVsTurtleListAxisAlignedRectangleInstanceCollisionOccurredTunnel;
            if (Map!= null)
            {
            }
            if (SolidCollision!= null)
            {
            }
            if (CloudCollision!= null)
            {
            }
            if (MarioInstance.Parent == null)
            {
                MarioInstance.X = 100f;
            }
            else
            {
                MarioInstance.RelativeX = 100f;
            }
            if (MarioInstance.Parent == null)
            {
                MarioInstance.Y = -200f;
            }
            else
            {
                MarioInstance.RelativeY = -200f;
            }
            if (MarioInstance.Parent == null)
            {
                MarioInstance.Z = 1f;
            }
            else
            {
                MarioInstance.RelativeZ = 1f;
            }
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            for (int i = A_BrickList.Count - 1; i > -1; i--)
            {
                A_BrickList[i].Destroy();
            }
            MarioInstance.RemoveFromManagers();
            for (int i = Lucky_blockList.Count - 1; i > -1; i--)
            {
                Lucky_blockList[i].Destroy();
            }
            for (int i = GumbaList.Count - 1; i > -1; i--)
            {
                GumbaList[i].Destroy();
            }
            for (int i = A_Brick_being_destroyedList.Count - 1; i > -1; i--)
            {
                A_Brick_being_destroyedList[i].Destroy();
            }
            if (CombinedShapeCollection != null)
            {
                CombinedShapeCollection.Visible = false;
            }
            for (int i = MushroomList.Count - 1; i > -1; i--)
            {
                MushroomList[i].Destroy();
            }
            for (int i = TurtleList.Count - 1; i > -1; i--)
            {
                TurtleList[i].Destroy();
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                MarioInstance.AssignCustomVariables(true);
            }
            if (Map != null)
            {
            }
            if (SolidCollision != null)
            {
            }
            if (CloudCollision != null)
            {
            }
            if (MarioInstance.Parent == null)
            {
                MarioInstance.X = 100f;
            }
            else
            {
                MarioInstance.RelativeX = 100f;
            }
            if (MarioInstance.Parent == null)
            {
                MarioInstance.Y = -200f;
            }
            else
            {
                MarioInstance.RelativeY = -200f;
            }
            if (MarioInstance.Parent == null)
            {
                MarioInstance.Z = 1f;
            }
            else
            {
                MarioInstance.RelativeZ = 1f;
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            if (Map != null)
            {
            }
            if (SolidCollision != null)
            {
            }
            if (CloudCollision != null)
            {
            }
            for (int i = 0; i < A_BrickList.Count; i++)
            {
                A_BrickList[i].ConvertToManuallyUpdated();
            }
            MarioInstance.ConvertToManuallyUpdated();
            for (int i = 0; i < Lucky_blockList.Count; i++)
            {
                Lucky_blockList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < GumbaList.Count; i++)
            {
                GumbaList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < A_Brick_being_destroyedList.Count; i++)
            {
                A_Brick_being_destroyedList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < MushroomList.Count; i++)
            {
                MushroomList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < TurtleList.Count; i++)
            {
                TurtleList[i].ConvertToManuallyUpdated();
            }
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            #if DEBUG
            if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                HasBeenLoadedWithGlobalContentManager = true;
            }
            else if (HasBeenLoadedWithGlobalContentManager)
            {
                throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
            }
            #endif
            Super_Marios_Bros.Entities.Mario.LoadStaticContent(contentManagerName);
            CustomLoadStaticContent(contentManagerName);
        }
        public override void PauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Pause();
            base.PauseThisScreen();
        }
        public override void UnpauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Unpause();
            base.UnpauseThisScreen();
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            return null;
        }
        public static object GetFile (string memberName) 
        {
            return null;
        }
        object GetMember (string memberName) 
        {
            return null;
        }
    }
}
