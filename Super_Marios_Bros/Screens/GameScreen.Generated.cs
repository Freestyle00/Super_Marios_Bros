#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace Super_Marios_Bros.Screens
{
    public partial class GameScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static Microsoft.Xna.Framework.Graphics.Texture2D tiles;
        protected static FlatRedBall.TileGraphics.LayeredTileMap World_1_1Map;
        
        protected FlatRedBall.TileGraphics.LayeredTileMap Map;
        protected FlatRedBall.TileCollisions.TileShapeCollection SolidCollision;
        protected FlatRedBall.TileCollisions.TileShapeCollection CloudCollision;
        private FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Mario> MarioList;
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
            MarioList = new FlatRedBall.Math.PositionedObjectList<Super_Marios_Bros.Entities.Mario>();
            MarioList.Name = "MarioList";
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
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            World_1_1Map.AddToManagers(mLayer);
            Factories.MarioFactory.Initialize(ContentManagerName);
            Factories.MarioFactory.AddList(MarioList);
            FlatRedBall.TileEntities.TileEntityInstantiator.CreateEntitiesFrom(Map);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                World_1_1Map?.AnimateSelf();;
                for (int i = MarioList.Count - 1; i > -1; i--)
                {
                    if (i < MarioList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        MarioList[i].Activity();
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
            Factories.MarioFactory.Destroy();
            tiles = null;
            World_1_1Map.Destroy();
            World_1_1Map = null;
            
            MarioList.MakeOneWay();
            for (int i = MarioList.Count - 1; i > -1; i--)
            {
                MarioList[i].Destroy();
            }
            MarioList.MakeTwoWay();
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (Map!= null)
            {
            }
            if (SolidCollision!= null)
            {
            }
            if (CloudCollision!= null)
            {
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
            World_1_1Map.Destroy();
            for (int i = MarioList.Count - 1; i > -1; i--)
            {
                MarioList[i].Destroy();
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
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
            for (int i = 0; i < MarioList.Count; i++)
            {
                MarioList[i].ConvertToManuallyUpdated();
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
            tiles = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/world_1_1/tiles.png", contentManagerName);
            World_1_1Map = FlatRedBall.TileGraphics.LayeredTileMap.FromTiledMapSave("content/screens/world_1_1/world_1_1map.tmx", contentManagerName);
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
            switch(memberName)
            {
                case  "tiles":
                    return tiles;
                case  "World_1_1Map":
                    return World_1_1Map;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "tiles":
                    return tiles;
                case  "World_1_1Map":
                    return World_1_1Map;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "tiles":
                    return tiles;
                case  "World_1_1Map":
                    return World_1_1Map;
            }
            return null;
        }
    }
}
