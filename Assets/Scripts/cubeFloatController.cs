/*
File Illustration:
Creation Time : 2017/5/13
Creator : SabreHawk - Zhiquan Wang

| TimeStep   |    Author     |  Comment
| 2017 /5 /9 | Zhiquan Wang  |  Create The File &
                                Add Function : Control The Float Effects Of SeaGround Perfabs

Script Illustration:
Function:
    [1] The Controller Of SeaGround Perfabs : Floating Effect Function
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeFloatController : MonoBehaviour {

    public bool isTargetUp = false;
    public float floatSpeed = 0f;    //The Floating Speed Of The Cube
    public float offsetHeight = 0f;  //The Offset Of Height Of The Cube While Floating
    public float Timer = 0f;         //The Timer Which Compute The Flaot Time
    public float floatTime = 0f;     //The Floating Time
    public float floatSpeedRandomOffset = 0f;
    public Transform cubeTransform;
    public Vector3 targetPosition = new Vector3(0,0,0); //Display The Realtime Target Position
    public Vector3 tempPosition = new Vector3(0, 0, 0);
    // Use this for initialization
    void Start () {
        cubeTransform = this.GetComponent<Transform>();
        tempPosition = cubeTransform.position;
        tempPosition.y = this.GetComponent<cubeRiseController>().startTargetHeight;
        targetPosition = tempPosition;

    }
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<cubeRiseController>().isStartRise) {
            return;
        }
        if (this.GetComponent<cubeRiseController>().isDestory) {
            return;
        }
            Timer += Time.deltaTime;
        //Control The Target Height Of The Cube With Timer
        if (Timer > floatTime) {
            floatSpeed = Random.Range(floatSpeed - floatSpeedRandomOffset, floatSpeed + floatSpeedRandomOffset);
            targetPosition.y = Random.Range(tempPosition.y - offsetHeight, tempPosition.y + offsetHeight);
            Timer = 0f;
        }
        //Control The Change Of The Target Height

        //Change The Height Of The Cube
                                                               
            this.cubeTransform.position = Vector3.Lerp(this.cubeTransform.position, targetPosition, floatSpeed * Time.deltaTime);
        
	}
}
