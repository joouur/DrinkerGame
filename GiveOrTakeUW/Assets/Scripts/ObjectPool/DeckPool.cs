using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GameDrinker.Tools;

namespace GameDrinker.Tools.ObjectPooler
{
    /// <summary>
    /// Object pooling Class.
    ///     1. Creates A Pool from Decks within ResourcesFolder
    ///     2. Returns objects to the pool if they are inactive
    /// </summary>
    public class DeckPool : ObjectPool
    {

        // Object to Instantiate
        public GameObject[] DecksToPool = new GameObject[4];

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
            waitingPool = new GameObject("<<DeckObjectPool>>" + this.name);

            pooledObjects = new List<GameObject>();
            for (int i = 0; i < 4; ++i)
            { AddDeckToPool(i); }
        }

        /// <summary>
        /// Adds one object of the type to the pool (Needs to be specified by the inspector)
        /// </summary>
        /// <returns>The object added to pool</returns>
        protected virtual GameObject AddDeckToPool(int i)
        {
            if (DecksToPool[i] == null)
            {
                // Return if no specifications
                Debug.LogWarning("NO " + gameObject.name + " within the Component, no pool will be created!");
                return null;
            }

            // Instantiate Object
            GameObject newObj = (GameObject)Instantiate(DecksToPool[i]);
            // Deactivate the object
            newObj.gameObject.SetActive(false);
            // Parent Object
            newObj.transform.parent = waitingPool.transform;
            // Set Name Count
            newObj.name = "GDDeck_" + (GDModes)Enum.ToObject(typeof(GDModes), i + 1);

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
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].gameObject.activeInHierarchy)
                { return pooledObjects[i]; }
            }

            return null;
        }
    }
}
