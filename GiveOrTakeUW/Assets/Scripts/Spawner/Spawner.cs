using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDrinker.Managers;
using GameDrinker.Tools.ObjectPooler;

namespace GameDrinker.Tools.Spawner
{
    [RequireComponent(typeof(ObjectPool))]
    public class Spawner : MonoBehaviour
    {
       [Header("Size")]
        public Vector3 minSize = new Vector3(1, 1, 1);
        public Vector3 maxSize = new Vector3(1, 1, 1);

        public bool perserveRatio = false;

        [Space(5)]
        [Header("Rotations")]
        public Vector3 minRotation;
        public Vector3 maxRotation;

        [Space(5)]
        [Header("Spawn")]
        public bool spawning = true;
        public bool onlywhenGameInProgress = true;
        public float initDelay = 0f;

        protected ObjectPool objPool;
        protected float startTime;

        protected virtual void Awake()
        {
            objPool = GetComponent<ObjectPool>();
            startTime = Time.time;
        }

        public virtual GameObject Spawn(Vector3 pos, bool triggerActivation = true)
        {
            if (onlywhenGameInProgress)
            { if (GDManager.Instance.Status != GAMESTATUS.INPROGRESS) { return null; } }

            if ((Time.time - startTime < initDelay) || !spawning)
            { return null; }

            GameObject nextObj = objPool.GetPooledGameObj();

            if(nextObj == null)
            { return null; }

            Vector3 newScale;

            if (!perserveRatio)
            {
                newScale = new Vector3(UnityEngine.Random.Range(minSize.x, maxSize.x),
                                        UnityEngine.Random.Range(minSize.y, maxSize.y),
                                        UnityEngine.Random.Range(minSize.z, maxSize.z));
            }
            else
            { newScale = Vector3.one * UnityEngine.Random.Range(minSize.x, maxSize.x); }

            nextObj.transform.position = pos;

            nextObj.transform.eulerAngles = new Vector3(UnityEngine.Random.Range(minRotation.x, maxRotation.x),
                                        UnityEngine.Random.Range(minRotation.y, maxRotation.y),
                                        UnityEngine.Random.Range(minRotation.z, maxRotation.z));

            nextObj.gameObject.SetActive(true);

            if(triggerActivation)
            {
                if(nextObj.GetComponent<PoolableObj>() != null)
                { nextObj.GetComponent<PoolableObj>().TriggerOnSpawnComplete(); }
            }

            return (nextObj);
        }
    }
}