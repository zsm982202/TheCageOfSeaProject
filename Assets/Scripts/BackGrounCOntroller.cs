using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounCOntroller : MonoBehaviour {

    public GameObject iconSample;
    public Material[] materialsArray;
	// Use this for initialization
	void Start () {
        for (int i = -20; i <= 20; ++i) {
            for (int j = -20; j <= 20; ++j) {
                GameObject backIcon = GameObject.Instantiate(iconSample, new Vector3(i, -10, j), Quaternion.identity) as GameObject;
                iconSample.GetComponent<MeshRenderer>().material = materialsArray[Random.Range(0, materialsArray.Length)];
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
