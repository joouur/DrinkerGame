using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameDrinker.Tools.ObjectPooler
{
    /// <summary>
    /// Object pooling Class.
    ///     1. Creates A Pool from specified objects
    ///     2. Returns objects to the pool if they are inactive
    /// NEVER!: Create a pool bigger than 30.
    /// </summary>
    public class SinglePooling : ObjectPool
    {

        // Object to Instantiate
        public GameObject ObjToPool;

        // Number of objects that can be added to pool
        public int poolSize = 10;
        // If true, the pool will automatically add another object to itself;
        public bool poolCanExpand = true;

        // Object to group pooled object
        protected GameObject waitingPool;
        // The POOL!
        protected List<GameObject> pooledObjects;

        /// <summary>
        /// Fills the pool with the gameObject type.
        /// </summary>
        protected override void FillObjectPool()
        {
            waitingPool = new GameObject("<<SingleObjectPooler>>" + this.name);

            pooledObjects = new List<GameObject>();

            for(int i = 0; i < poolSize; i++)
            { AddOneObjectToPool(); }
        }

        /// <summary>
        /// Adds one object of the type to the pool (Needs to be specified by the inspector)
        /// </summary>
        /// <returns>The object added to pool</returns>
        protected virtual GameObject AddOneObjectToPool()
        {
            if(ObjToPool == null)
            {
                // Return if no specifications
                Debug.LogWarning("NO " + gameObject.name + " within the Component, no pool will be created!");
                return null;
            }

            // Instantiate Object
            GameObject newObj = (GameObject)Instantiate(ObjToPool);
            // Deactivate the object
            newObj.gameObject.SetActive(false);
            // Parent Object
            newObj.transform.parent = waitingPool.transform;
            // Set Name Count
            newObj.name = ObjToPool.name + "-" + pooledObjects.Count;

            // Add obj to the pool
            pooledObjects.Add(newObj);
            return newObj;
        }

        /// <summary>
        /// Return the inactive object from the pool
        /// </summary>
        /// <returns> Pooled Obj</returns>
        public override GameObject GetPooledGameObj()
        {
            // Look for inactives and return them
            for(int i =0; i < pooledObjects.Count; i++)
            {
                if(!pooledObjects[i].gameObject.activeInHierarchy)
                { return pooledObjects[i]; }
            }
            // If there was no expand return null if there is add one more
            if(poolCanExpand)
            { return AddOneObjectToPool(); }

            return null;
        }
    }
}
