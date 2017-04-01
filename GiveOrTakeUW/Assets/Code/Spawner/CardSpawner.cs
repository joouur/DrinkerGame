using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : Spawner
{
    #region Data
    [Header("Position Spawn")]
    public GameObject Position;

    [Space(10)]
    [Header("Velocity")]
    public float moveVelocity;
    public float rotationVelocity;

    [Space(10)]
    [Header("Destination")]
    public Vector3 finalDestination;
    public Vector3 finalRotation;

    [Space(10)]
    [Header("Spawn Angle")]
    public bool spawnToRotatedToDirection = true;
    protected Transform lastSpawnTransform;

    #endregion

    protected virtual GameObject Spawn(string card, bool triggerActivation = true)
    {
        if (onlywhenGameInProgress)
        { if (GDManager.Instance.Status != GAMESTATUS.INPROGRESS) { return null; } }

        if ((Time.time - startTime < initDelay) || !spawning)
        { return null; }

        GameObject nextObj = objPool.GetPooledGameObj(card);

        if (nextObj == null)
        { return null; }

        nextObj.gameObject.SetActive(true);
        if (triggerActivation)
        {
            if (nextObj.GetComponent<PoolableObj>() != null)
            { nextObj.GetComponent<PoolableObj>().TriggerOnSpawnComplete(); }
        }
        Debug.Log("Spawning " + nextObj.name);
        return (nextObj);

    }

    protected virtual void PlaceSpawn(string card)
    {
        GameObject spawnObj = Spawn(card, false);

        if (spawnObj == null)
        {
            lastSpawnTransform = null;
            return;
        }

        if (spawnObj.GetComponent<PoolableObj>() == null)
        {
            throw new Exception(gameObject.name + " is trying to spawn object that don't have PoolableObj Component!");
        }

        if (lastSpawnTransform != null)
        {
            spawnObj.transform.position = Position.transform.position;

            spawnObj.GetComponent<PoolableObj>().TriggerOnSpawnComplete();

            lastSpawnTransform = spawnObj.transform;
        }
        StartCoroutine(MoveToNextUser(spawnObj, finalDestination, moveVelocity));
    }

    public void CheckSpawn(string card)
    {
        if (onlywhenGameInProgress)
        {
            if (GDManager.Instance.Status != GAMESTATUS.INPROGRESS)
            {
                lastSpawnTransform = null;
                return;
            }
        }
        if ((lastSpawnTransform == null) || (!lastSpawnTransform.gameObject.activeInHierarchy))
        {
            PlaceSpawn(card);
            return;
        }
    }

    private IEnumerator MoveToNextUser(GameObject obj, Vector3 destination, float moveDuration)
    {
        float elapsedTime = 0.0f;
        Vector3 initPos = Position.transform.position;
        Vector3 initRot = obj.transform.localEulerAngles;
        float SqrRemDistanceMag = (Position.transform.position - Vector3.zero).sqrMagnitude;

        while (SqrRemDistanceMag > float.Epsilon)
        {
            elapsedTime += Time.deltaTime;

            obj.transform.position = Vector3.Lerp(initPos, Vector3.zero, elapsedTime / moveDuration);
            obj.transform.localEulerAngles = Vector3.Lerp(initRot, finalRotation, elapsedTime / rotationVelocity);
            SqrRemDistanceMag = (obj.transform.position - Vector3.zero).sqrMagnitude;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        StartCoroutine(MoveBack(obj, destination, moveDuration));
    }

    private IEnumerator MoveBack(GameObject obj, Vector3 destination, float moveDuration)
    {
        float elapsedTime = 0.0f;
        Vector3 initPos = Vector3.zero;
        Vector3 initRot = obj.transform.localEulerAngles;
        float SqrRemDistanceMag = (Vector3.zero - destination).sqrMagnitude;

        while (SqrRemDistanceMag > float.Epsilon)
        {
            elapsedTime += Time.deltaTime;

            obj.transform.position = Vector3.Lerp(initPos, destination, elapsedTime / moveDuration);
            obj.transform.localEulerAngles = Vector3.Lerp(initRot, Vector3.zero, elapsedTime / rotationVelocity);
            SqrRemDistanceMag = (obj.transform.position - destination).sqrMagnitude;
            yield return null;
        }

        obj.GetComponent<PoolableObj>().Destroy();
    }
}