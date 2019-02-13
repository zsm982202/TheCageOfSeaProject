using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdRotateController : MonoBehaviour {

    public float rotateSpeed = 0;
	// Use this for initialization
	void Start () {
        rotateSpeed = Random.Range(50, 150);
    }
	
	// Update is called once per frame
	void Update () {

        this.transform.Rotate(Vector3.up,rotateSpeed * Time.deltaTime);
	}
}
