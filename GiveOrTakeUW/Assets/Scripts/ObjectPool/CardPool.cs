using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace GameDrinker.Tools.ObjectPooler
{
    /// <summary>
    /// Mulitple Object Pooling Class
    ///     1. Creates a Pool of many Objects
    ///     2. Returns objects to the pool if they are inactive
    /// </summary>
    public class CardPool : ObjectPool
    {
        // Array of Objects to instantiate
        public GameObject[] CardsToPool = new GameObject[52];
       
         // Number of objects that can be added to the pool
        public int poolSize = 52;

        // If true, the Pool will automatically add another object to itself
        public bool poolCanExpand = true;

        // Object to group pooled object
        protected GameObject waitingPool;

        // THE POOL!
        protected List<GameObject> pooledObjects;

        /// <summary>
        /// Fills pool with gameObject type
        /// </summary>
        protected override void FillObjectPool()
        {

            pooledObjects = new List<GameObject>();
            waitingPool = new GameObject("<<CardPooler>>" + this.name);
            foreach(GameObject obj in CardsToPool)
            { AddOneObjectToPool(obj); }
        }

        /// <summary>
        /// Fills pool with gameObject type
        /// </summary>
        public void FillPool()
        {
            FillObjectPool();
        }
        /// <summary>
        /// Adds on object of any type to the pool
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        protected virtual GameObject AddOneObjectToPool(GameObject go)
        {
            if (go == null)
            {
                Debug.LogWarning("NO " + go.name + " within the Component, no pool will be created!");
                return null;
            }
            GameObject newObj = (GameObject)Instantiate(go);
            newObj.gameObject.SetActive(false);
            newObj.transform.parent = waitingPool.transform;
            newObj.name = newObj.name + "-" + pooledObjects.Count;
            pooledObjects.Add(newObj);
            return newObj;
        }

        protected virtual List<GameObject> AddMultiObjectsToPool()
        {
            List<GameObject> newObjs = new List<GameObject>();

            return newObjs;
        }
        /// <summary>
        /// Returns a game object depending on the type of object requested
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override GameObject GetPooledGameObj(string type)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (pooledObjects[i].name.Contains(type) && !pooledObjects[i].gameObject.activeInHierarchy)
                    return pooledObjects[i];
            }
            if (poolCanExpand)
            {
                foreach (GameObject x in CardsToPool)
                {
                    if (x.name.Contains(type))
                        return AddOneObjectToPool(x);
                }

            }
            return null;
        }

        /// <summary>
        /// Returns a random type game object within the pool
        /// if the all game objects of that type are active, and
        /// the pool can expand, it adds one more object of that type to the pool
        /// and returns that object
        /// </summary>
        /// <returns></returns>
        public override GameObject GetPooledGameObj()
        {
            int type = GDMath.Dice(CardsToPool.Length);
            for (int i = 0; i < poolSize; i++)
            {
                if (!pooledObjects[(i + type * 10)].gameObject.activeInHierarchy)
                    return pooledObjects[(i + (type * 1)) - 1];
            }
            if (poolCanExpand)
                return AddOneObjectToPool(CardsToPool[type]);

            return null;
        }
    }
}
