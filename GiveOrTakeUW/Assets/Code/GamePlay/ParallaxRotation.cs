using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxRotation : MonoBehaviour {

    public bool PositiveRotation;
    public float SpeedRotation;
    private Transform PRTrans;
    private Vector3 rotation;

	// Use this for initialization
	void Start () 
    {
        PRTrans = GetComponent<Transform>();
        if (!PositiveRotation)
            rotation = Vector3.back;
        else
            rotation = Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () 
    {

        PRTrans.Rotate((rotation * SpeedRotation) * Time.deltaTime);
	}
}
