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
    public partial class World1level1 : GameScreen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static FlatRedBall.TileGraphics.LayeredTileMap tiled;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D tiles;
        
        private Super_Marios_Bros.Entities.Mario MarioInstance;
        private FlatRedBall.Math.Collision.DelegateCollisionRelationship<Super_Marios_Bros.Entities.Mario, FlatRedBall.TileCollisions.TileShapeCollection> MarioInstanceVsSolidCollision;
        public World1level1 () 
        	: base ()
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            Map = tiled;
            SolidCollision = new FlatRedBall.TileCollisions.TileShapeCollection();
            CloudCollision = new FlatRedBall.TileCollisions.TileShapeCollection();
            MarioInstance = new Super_Marios_Bros.Entities.Mario(ContentManagerName, false);
            MarioInstance.Name = "MarioInstance";
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

            
            
            base.Initialize(addToManagers);
        }
        public override void AddToManagers () 
        {
            tiled.AddToManagers(mLayer);
            MarioInstance.AddToManagers(mLayer);
            base.AddToManagers();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                tiled?.AnimateSelf();;
                MarioInstance.Activity();
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
            tiled.Destroy();
            tiled = null;
            tiles = null;
            
            if (Map != null)
            {
                Map.Destroy();
            }
            if (SolidCollision != null)
            {
                SolidCollision.Visible = false;
            }
            if (CloudCollision != null)
            {
                CloudCollision.Visible = false;
            }
            if (MarioInstance != null)
            {
                MarioInstance.Destroy();
                MarioInstance.Detach();
            }
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public override void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            base.PostInitialize();
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
        public override void AddToManagersBottomUp () 
        {
            base.AddToManagersBottomUp();
        }
        public override void RemoveFromManagers () 
        {
            base.RemoveFromManagers();
            tiled.Destroy();
            if (Map != null)
            {
                Map.Destroy();
            }
            if (SolidCollision != null)
            {
                SolidCollision.Visible = false;
            }
            if (CloudCollision != null)
            {
                CloudCollision.Visible = false;
            }
            MarioInstance.RemoveFromManagers();
        }
        public override void AssignCustomVariables (bool callOnContainedElements) 
        {
            base.AssignCustomVariables(callOnContainedElements);
            if (callOnContainedElements)
            {
                MarioInstance.AssignCustomVariables(true);
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
        public override void ConvertToManuallyUpdated () 
        {
            base.ConvertToManuallyUpdated();
            MarioInstance.ConvertToManuallyUpdated();
        }
        public static new void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            Super_Marios_Bros.Screens.GameScreen.LoadStaticContent(contentManagerName);
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
            tiled = FlatRedBall.TileGraphics.LayeredTileMap.FromTiledMapSave("content/screens/world1level1/tiled.tmx", contentManagerName);
            tiles = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/world1level1/tiles.png", contentManagerName);
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
        public static new object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "tiled":
                    return tiled;
                case  "tiles":
                    return tiles;
            }
            return null;
        }
        public static new object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "tiled":
                    return tiled;
                case  "tiles":
                    return tiles;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "tiled":
                    return tiled;
                case  "tiles":
                    return tiles;
            }
            return null;
        }
    }
}
