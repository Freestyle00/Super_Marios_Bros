#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace Super_Marios_Bros.Entities
{
    public partial class Gumba : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable, FlatRedBall.Performance.IPoolable, FlatRedBall.Math.Geometry.ICollidable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static FlatRedBall.Graphics.Animation.AnimationChainList Gumba_walking;
        
        private FlatRedBall.Sprite SpriteInstance;
        private FlatRedBall.Math.Geometry.AxisAlignedRectangle mAxisAlignedRectangleInstance;
        public FlatRedBall.Math.Geometry.AxisAlignedRectangle AxisAlignedRectangleInstance
        {
            get
            {
                return mAxisAlignedRectangleInstance;
            }
            private set
            {
                mAxisAlignedRectangleInstance = value;
            }
        }
        private FlatRedBall.Math.Geometry.AxisAlignedRectangle mget_dunked;
        public FlatRedBall.Math.Geometry.AxisAlignedRectangle get_dunked
        {
            get
            {
                return mget_dunked;
            }
            private set
            {
                mget_dunked = value;
            }
        }
        private FlatRedBall.Math.Geometry.AxisAlignedRectangle mLeftMarioDead;
        public FlatRedBall.Math.Geometry.AxisAlignedRectangle LeftMarioDead
        {
            get
            {
                return mLeftMarioDead;
            }
            private set
            {
                mLeftMarioDead = value;
            }
        }
        private FlatRedBall.Math.Geometry.AxisAlignedRectangle mRightMarioDead;
        public FlatRedBall.Math.Geometry.AxisAlignedRectangle RightMarioDead
        {
            get
            {
                return mRightMarioDead;
            }
            private set
            {
                mRightMarioDead = value;
            }
        }
        public float AxisAlignedRectangleInstanceHeight
        {
            get
            {
                return AxisAlignedRectangleInstance.Height;
            }
            set
            {
                AxisAlignedRectangleInstance.Height = value;
            }
        }
        public float HeightOftheRectangle
        {
            get
            {
                if (AxisAlignedRectangleInstance.Parent == null)
                {
                    return AxisAlignedRectangleInstance.Y;
                }
                else
                {
                    return AxisAlignedRectangleInstance.RelativeY;
                }
            }
            set
            {
                if (AxisAlignedRectangleInstance.Parent == null)
                {
                    AxisAlignedRectangleInstance.Y = value;
                }
                else
                {
                    AxisAlignedRectangleInstance.RelativeY = value;
                }
            }
        }
        public int Index { get; set; }
        public bool Used { get; set; }
        private FlatRedBall.Math.Geometry.ShapeCollection mGeneratedCollision;
        public FlatRedBall.Math.Geometry.ShapeCollection Collision
        {
            get
            {
                return mGeneratedCollision;
            }
        }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public Gumba () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Gumba (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Gumba (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpriteInstance = new FlatRedBall.Sprite();
            SpriteInstance.Name = "SpriteInstance";
            mAxisAlignedRectangleInstance = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
            mAxisAlignedRectangleInstance.Name = "mAxisAlignedRectangleInstance";
            mget_dunked = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
            mget_dunked.Name = "mget_dunked";
            mLeftMarioDead = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
            mLeftMarioDead.Name = "mLeftMarioDead";
            mRightMarioDead = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
            mRightMarioDead.Name = "mRightMarioDead";
            
            PostInitialize();
            if (addToManagers)
            {
                AddToManagers(null);
            }
        }
        public virtual void ReAddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mAxisAlignedRectangleInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mget_dunked, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mLeftMarioDead, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mRightMarioDead, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mAxisAlignedRectangleInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mget_dunked, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mLeftMarioDead, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mRightMarioDead, LayerProvidedByContainer);
            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            if (Used)
            {
                Factories.GumbaFactory.MakeUnused(this, false);
            }
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (AxisAlignedRectangleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(AxisAlignedRectangleInstance);
            }
            if (get_dunked != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(get_dunked);
            }
            if (LeftMarioDead != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(LeftMarioDead);
            }
            if (RightMarioDead != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(RightMarioDead);
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.CopyAbsoluteToRelative();
                SpriteInstance.AttachTo(this, false);
            }
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.AnimationChains = Gumba_walking;
            SpriteInstance.CurrentChainName = "";
            if (mAxisAlignedRectangleInstance.Parent == null)
            {
                mAxisAlignedRectangleInstance.CopyAbsoluteToRelative();
                mAxisAlignedRectangleInstance.AttachTo(this, false);
            }
            AxisAlignedRectangleInstance.Width = 16f;
            AxisAlignedRectangleInstance.Height = 16f;
            if (mget_dunked.Parent == null)
            {
                mget_dunked.CopyAbsoluteToRelative();
                mget_dunked.AttachTo(this, false);
            }
            if (get_dunked.Parent == null)
            {
                get_dunked.Y = 8.5f;
            }
            else
            {
                get_dunked.RelativeY = 8.5f;
            }
            get_dunked.Width = 14f;
            get_dunked.Height = 2f;
            get_dunked.Color = Microsoft.Xna.Framework.Color.Violet;
            get_dunked.RepositionDirections = FlatRedBall.Math.Geometry.RepositionDirections.Up;
            if (mLeftMarioDead.Parent == null)
            {
                mLeftMarioDead.CopyAbsoluteToRelative();
                mLeftMarioDead.AttachTo(this, false);
            }
            if (LeftMarioDead.Parent == null)
            {
                LeftMarioDead.X = -8.5f;
            }
            else
            {
                LeftMarioDead.RelativeX = -8.5f;
            }
            LeftMarioDead.Width = 2f;
            LeftMarioDead.Height = 16f;
            LeftMarioDead.Color = Microsoft.Xna.Framework.Color.Violet;
            if (mRightMarioDead.Parent == null)
            {
                mRightMarioDead.CopyAbsoluteToRelative();
                mRightMarioDead.AttachTo(this, false);
            }
            if (RightMarioDead.Parent == null)
            {
                RightMarioDead.X = 8.5f;
            }
            else
            {
                RightMarioDead.RelativeX = 8.5f;
            }
            RightMarioDead.Width = 2f;
            RightMarioDead.Height = 16f;
            RightMarioDead.Color = Microsoft.Xna.Framework.Color.Violet;
            mGeneratedCollision = new FlatRedBall.Math.Geometry.ShapeCollection();
            Collision.AxisAlignedRectangles.AddOneWay(mAxisAlignedRectangleInstance);
            Collision.AxisAlignedRectangles.AddOneWay(mget_dunked);
            Collision.AxisAlignedRectangles.AddOneWay(mLeftMarioDead);
            Collision.AxisAlignedRectangles.AddOneWay(mRightMarioDead);
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (AxisAlignedRectangleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(AxisAlignedRectangleInstance);
            }
            if (get_dunked != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(get_dunked);
            }
            if (LeftMarioDead != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(LeftMarioDead);
            }
            if (RightMarioDead != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(RightMarioDead);
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.AnimationChains = Gumba_walking;
            SpriteInstance.CurrentChainName = "";
            AxisAlignedRectangleInstance.Width = 16f;
            AxisAlignedRectangleInstance.Height = 16f;
            if (get_dunked.Parent == null)
            {
                get_dunked.Y = 8.5f;
            }
            else
            {
                get_dunked.RelativeY = 8.5f;
            }
            get_dunked.Width = 14f;
            get_dunked.Height = 2f;
            get_dunked.Color = Microsoft.Xna.Framework.Color.Violet;
            get_dunked.RepositionDirections = FlatRedBall.Math.Geometry.RepositionDirections.Up;
            if (LeftMarioDead.Parent == null)
            {
                LeftMarioDead.X = -8.5f;
            }
            else
            {
                LeftMarioDead.RelativeX = -8.5f;
            }
            LeftMarioDead.Width = 2f;
            LeftMarioDead.Height = 16f;
            LeftMarioDead.Color = Microsoft.Xna.Framework.Color.Violet;
            if (RightMarioDead.Parent == null)
            {
                RightMarioDead.X = 8.5f;
            }
            else
            {
                RightMarioDead.RelativeX = 8.5f;
            }
            RightMarioDead.Width = 2f;
            RightMarioDead.Height = 16f;
            RightMarioDead.Color = Microsoft.Xna.Framework.Color.Violet;
            AxisAlignedRectangleInstanceHeight = 16f;
            HeightOftheRectangle = 0f;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpriteInstance);
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            ContentManagerName = contentManagerName;
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
            bool registerUnload = false;
            if (LoadedContentManagers.Contains(contentManagerName) == false)
            {
                LoadedContentManagers.Add(contentManagerName);
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("GumbaStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/gumba/gumba_walking.achx", ContentManagerName))
                {
                    registerUnload = true;
                }
                Gumba_walking = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/gumba/gumba_walking.achx", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("GumbaStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
            }
            CustomLoadStaticContent(contentManagerName);
        }
        public static void UnloadStaticContent () 
        {
            if (LoadedContentManagers.Count != 0)
            {
                LoadedContentManagers.RemoveAt(0);
                mRegisteredUnloads.RemoveAt(0);
            }
            if (LoadedContentManagers.Count == 0)
            {
                if (Gumba_walking != null)
                {
                    Gumba_walking= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Gumba_walking":
                    return Gumba_walking;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "Gumba_walking":
                    return Gumba_walking;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Gumba_walking":
                    return Gumba_walking;
            }
            return null;
        }
        protected bool mIsPaused;
        public override void Pause (FlatRedBall.Instructions.InstructionList instructions) 
        {
            base.Pause(instructions);
            mIsPaused = true;
        }
        public virtual void SetToIgnorePausing () 
        {
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(this);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(SpriteInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(AxisAlignedRectangleInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(get_dunked);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(LeftMarioDead);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(RightMarioDead);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(SpriteInstance);
            }
            if (layerToMoveTo != null || !SpriteManager.AutomaticallyUpdatedSprites.Contains(SpriteInstance))
            {
                FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, layerToMoveTo);
            }
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(AxisAlignedRectangleInstance);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(AxisAlignedRectangleInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(get_dunked);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(get_dunked, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(LeftMarioDead);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(LeftMarioDead, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(RightMarioDead);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(RightMarioDead, layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
