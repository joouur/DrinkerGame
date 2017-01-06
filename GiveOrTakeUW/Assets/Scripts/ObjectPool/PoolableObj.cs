using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDrinker.Tools.ObjectPooler
{
    public class PoolableObj : ObjectBounds
    {

        public delegate void Events();
        public event Events OnSpawnComplete;

        public float lifeTime = 0.0f;

        public virtual void Destroy()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// To Override
        /// </summary>
        protected virtual void Update()
        { }

        /// <summary>
        /// Start killing Obj as soon as it Spawns
        /// </summary>
        protected virtual void OnEnable()
        {
            Size = GetBounds().extents * 2;
            if (lifeTime > 0)
            { Invoke("Destroy", lifeTime); }
        }

        /// <summary>
        /// Cancel Invoke if Object gets Disable
        /// </summary>
        protected virtual void OnDisable()
        { CancelInvoke(); }

        /// <summary>
        /// Check for Object completed Spawn delegate and evet;
        /// </summary>
        public void TriggerOnSpawnComplete()
        {
            if (OnSpawnComplete != null)
            { OnSpawnComplete(); }
        }
    }
}