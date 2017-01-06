using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDrinker.Managers;
using GameDrinker.Tools.ObjectPooler;
using GameDrinker.GentleUI;
using GameDrinker.Decks;

namespace GameDrinker.Tools.Spawn
{
    public class UICardSpawner : Spawner
    {

        [Space(10)]
        [Header("PositionID")]
        public int Position;

        public virtual void CheckForCard(GDCard card)
        {
            GameObject spawnObj = Spawn(Rect.zero);

            if (spawnObj == null)
            { return; }
            if (spawnObj.GetComponent<PoolableObj>() == null)
            { throw new Exception(gameObject.name + " is trying to spawn object that don't have PoolableObj Component!"); }
            if (spawnObj.GetComponent<CardUIBehaviour>() == null)
            { throw new Exception(gameObject.name + " is trying to spawn object that don't have PoolableObj Component!"); }

            spawnObj.GetComponent<CardUIBehaviour>().ChangeSprite(card.FrontSprite);
        }

        protected virtual GameObject Spawn(Rect pos, bool triggerActivation = true)
        {
            if (onlywhenGameInProgress)
            { if (GDManager.Instance.Status != GAMESTATUS.INPROGRESS) { return null; } }

            if ((Time.time - startTime < initDelay) || !spawning)
            { return null; }

            GameObject nextObj = objPool.GetPooledGameObj();

            if (nextObj == null)
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

            nextObj.transform.localScale = newScale;

            if (nextObj.GetComponent<PoolableObj>() == null)
            {
                throw new Exception(gameObject.name + " is trying to spawn objects that do not have poolableObj component.");
            }

            nextObj.GetComponent<RectTransform>().localPosition = new Vector3(pos.position.x, pos.position.y, 0);

            nextObj.transform.eulerAngles = new Vector3(UnityEngine.Random.Range(minRotation.x, maxRotation.x),
                            UnityEngine.Random.Range(minRotation.y, maxRotation.y),
                            UnityEngine.Random.Range(minRotation.z, maxRotation.z));

            nextObj.gameObject.SetActive(true);

            if (triggerActivation)
            {
                if (nextObj.GetComponent<PoolableObj>() != null)
                { nextObj.GetComponent<PoolableObj>().TriggerOnSpawnComplete(); }
            }

            Debug.Log("Spawn");
            return (nextObj);
        }
    }
}