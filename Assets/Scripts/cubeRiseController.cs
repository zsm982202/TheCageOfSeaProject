using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRiseController : MonoBehaviour {
    public static cubeRiseController instancecubeRiseController; 
    public bool isDestory = false;
    public bool isStartRise = false;
    public bool isFish = false;
    public bool isFished = false;
    public float riseSpeed = 0f;
    public float startTargetHeight = 0f;
    public float endTargetHeight = 0f;
    public Transform cubeTransform;
    public Vector3 targetPosition = new Vector3();
    public Material cubeMaterial;
    public int x;//方块的横坐标
    public int y;//方块的纵坐标
    // Use this for initialization
    void Start () {
        instancecubeRiseController = this;
        isStartRise = true;
        cubeTransform = this.GetComponent<Transform>();
        targetPosition = cubeTransform.position;
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if ((cubeTransform.position.x == 0.5 + i) &&
                    (cubeTransform.position.z == 0.5 + j)) {
                    x = i;
                    y = j;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<MeshRenderer>().material = cubeMaterial;
        cubeTransform.position = Vector3.Lerp(cubeTransform.position, targetPosition, riseSpeed * Time.deltaTime);
        if (isStartRise) {
            targetPosition.y = startTargetHeight;
            if (Mathf.Abs(cubeTransform.position.y - startTargetHeight) < 0.1f) {
                isStartRise = false;
                cubeTransform.position = targetPosition;
            }
        }
        if (isDestory) {
            targetPosition.y = endTargetHeight;
            if (this.transform.position.y >15) {
                Destroy(this.gameObject);
            }
        }
       
		
	}
}
