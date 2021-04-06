using Super_Marios_Bros.Entities;
using System;
using FlatRedBall.Math;
using FlatRedBall.Graphics;
using Super_Marios_Bros.Performance;

namespace Super_Marios_Bros.Factories
{
    public class A_Brick_being_destroyedFactory : IEntityFactory
    {
        public static FlatRedBall.Math.Axis? SortAxis { get; set;}
        public static A_Brick_being_destroyed CreateNew (float x = 0, float y = 0) 
        {
            return CreateNew(null, x, y);
        }
        public static A_Brick_being_destroyed CreateNew (Layer layer, float x = 0, float y = 0) 
        {
            A_Brick_being_destroyed instance = null;
            instance = new A_Brick_being_destroyed(mContentManagerName ?? FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, false);
            instance.AddToManagers(layer);
            instance.X = x;
            instance.Y = y;
            foreach (var list in ListsToAddTo)
            {
                if (SortAxis == FlatRedBall.Math.Axis.X && list is PositionedObjectList<A_Brick_being_destroyed>)
                {
                    var index = (list as PositionedObjectList<A_Brick_being_destroyed>).GetFirstAfter(x, Axis.X, 0, list.Count);
                    list.Insert(index, instance);
                }
                else if (SortAxis == FlatRedBall.Math.Axis.Y && list is PositionedObjectList<A_Brick_being_destroyed>)
                {
                    var index = (list as PositionedObjectList<A_Brick_being_destroyed>).GetFirstAfter(y, Axis.Y, 0, list.Count);
                    list.Insert(index, instance);
                }
                else
                {
                    // Sort Z not supported
                    list.Add(instance);
                }
            }
            if (EntitySpawned != null)
            {
                EntitySpawned(instance);
            }
            return instance;
        }
        
        public static void Initialize (string contentManager) 
        {
            mContentManagerName = contentManager;
        }
        
        public static void Destroy () 
        {
            mContentManagerName = null;
            ListsToAddTo.Clear();
            SortAxis = null;
            mPool.Clear();
            EntitySpawned = null;
        }
        
        private static void FactoryInitialize () 
        {
            const int numberToPreAllocate = 20;
            for (int i = 0; i < numberToPreAllocate; i++)
            {
                A_Brick_being_destroyed instance = new A_Brick_being_destroyed(mContentManagerName, false);
                mPool.AddToPool(instance);
            }
        }
        
        /// <summary>
        /// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
        /// by generated code.  Use Destroy instead when writing custom code so that your code will behave
        /// the same whether your Entity is pooled or not.
        /// </summary>
        public static void MakeUnused (A_Brick_being_destroyed objectToMakeUnused) 
        {
            MakeUnused(objectToMakeUnused, true);
        }
        
        /// <summary>
        /// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
        /// by generated code.  Use Destroy instead when writing custom code so that your code will behave
        /// the same whether your Entity is pooled or not.
        /// </summary>
        public static void MakeUnused (A_Brick_being_destroyed objectToMakeUnused, bool callDestroy) 
        {
            if (callDestroy)
            {
                objectToMakeUnused.Destroy();
            }
        }
        
        public static void AddList<T> (System.Collections.Generic.IList<T> newList) where T : A_Brick_being_destroyed
        {
            ListsToAddTo.Add(newList as System.Collections.IList);
        }
        public static void RemoveList<T> (System.Collections.Generic.IList<T> listToRemove) where T : A_Brick_being_destroyed
        {
            ListsToAddTo.Remove(listToRemove as System.Collections.IList);
        }
        public static void ClearListsToAddTo () 
        {
            ListsToAddTo.Clear();
        }
        
        
            static string mContentManagerName;
            static System.Collections.Generic.List<System.Collections.IList> ListsToAddTo = new System.Collections.Generic.List<System.Collections.IList>();
            static PoolList<A_Brick_being_destroyed> mPool = new PoolList<A_Brick_being_destroyed>();
            public static Action<A_Brick_being_destroyed> EntitySpawned;
            object IEntityFactory.CreateNew (float x = 0, float y = 0) 
            {
                return A_Brick_being_destroyedFactory.CreateNew(x, y);
            }
            object IEntityFactory.CreateNew (Layer layer) 
            {
                return A_Brick_being_destroyedFactory.CreateNew(layer);
            }
            void IEntityFactory.Initialize (string contentManagerName) 
            {
                A_Brick_being_destroyedFactory.Initialize(contentManagerName);
            }
            void IEntityFactory.ClearListsToAddTo () 
            {
                A_Brick_being_destroyedFactory.ClearListsToAddTo();
            }
            static A_Brick_being_destroyedFactory mSelf;
            public static A_Brick_being_destroyedFactory Self
            {
                get
                {
                    if (mSelf == null)
                    {
                        mSelf = new A_Brick_being_destroyedFactory();
                    }
                    return mSelf;
                }
            }
    }
}
