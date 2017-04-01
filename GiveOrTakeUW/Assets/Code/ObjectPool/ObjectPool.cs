using UnityEngine;
using System.Collections;
using System.Collections.Generic;



/// <summary>
/// BASE CLASS
/// DO not add to components, is dependant of more overrided functions
/// DO NOT add to prefabs.
/// </summary>
public class ObjectPool : MonoBehaviour
{

    public static ObjectPool Instance;

    /// <summary>
    /// Simple Singleton
    /// </summary>
    protected virtual void Awake()
    { Instance = this; }

    /// <summary>
    /// Start, Fill the pool with objects
    /// </summary>
    protected virtual void Start()
    { /*FillObjectPool();*/ }

    /// <summary>
    /// Implement on Multiple or Simple Pool
    /// </summary>
    protected virtual void FillObjectPool()
    { return; }

    /// <summary>
    /// Returns object of implementation in Single or Multiple
    /// </summary>
    /// <returns>The Obj in the Pool</returns>
    public virtual GameObject GetPooledGameObj()
    { return null; }
    public virtual GameObject GetPooledGameObj(string x)
    { return null; }
}