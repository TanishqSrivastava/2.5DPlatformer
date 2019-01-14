using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public Transform tran;
    public Vector3 coordsOfCam;
    public float tranPosY;
    public Vector3 newPosition;
    // Use this for initialization
	void Start () {
		
	}
    private void Update()
    {
        
    }
    // Update is called once per frame
    void LateUpdate () {
        newPosition.x = tran.position.x;
        newPosition.y = tran.position.y;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
	}
}
