using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CagePlatformController : MonoBehaviour {

    public static CagePlatformController instanceCagePlatform;
    public GameObject[] birdArray;
    public Transform[] birdTransArray = new Transform[4];
    public int[] birdTypeArray = new int[4];
    public int birdCounter = 0;
    // Use this for initialization
    void Start() {
        birdCounter = birdArray.Length;
        instanceCagePlatform = this;
        switch (LevelController.instanceLevelController.level) {
            case 1:                               
                birdTypeArray[0] = 0;
                break;
            case 2:
                birdTypeArray[0] = 0;   
                birdTypeArray[1] = 1;    
                break;
            case 3:                         
                birdTypeArray[0] = 1;
                birdTypeArray[1] = 1;
                birdTypeArray[2] = 2;
                birdTypeArray[3] = 3;
                break;
            case 4:
                birdTypeArray[0] = 0;
                birdTypeArray[1] = 3;
                birdTypeArray[2] = 1;
                birdTypeArray[3] = 2;
                break;  

        }

        for (int i = 0; i < birdTransArray.Length; ++i) {
            GameObject obj = Instantiate(birdArray[birdTypeArray[i]], birdTransArray[i].position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
