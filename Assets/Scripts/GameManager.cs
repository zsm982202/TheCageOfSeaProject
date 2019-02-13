using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instanceManager;
    public cubeRiseController[,] cubeRiseControl = new cubeRiseController[5, 5];
    public GameObject[] seacube = new GameObject[4];
    public GameObject[] fishObj = new GameObject[3];
    public GameObject birdObject;
    public GameObject groundcube;
    public Material greeMaterial;
    public Material violentMaterial;
    public Material redMaterial;
    public Vector3 fishPosition = new Vector3(0, 0, 0);
    public Transform fishHolderTransform;
    public AudioSource upAudio;

    public int[,] landArray = new int[5, 5];//-1陆地 ,0海,1,2,3
    public int birdKind = 0;
    public float birdFlySpeed = 0f;
    public int currentSocre = 0;
    public int groundNum = 0;
    public int seaNum = 0;
    public float ymax = 0;
    public bool isBirdChosen = false;
    public bool isFishChosen = false;
    public bool isFlying = false;
    public bool isGetPosition = false;
    public int counter = 0;

    // Use this for initialization
    void Start() {
        upAudio = this.GetComponent<AudioSource>();
        instanceManager = this;
        //初始化陆地
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                landArray[i, j] = LevelController.instanceLevelController.levelmap[i, j, LevelController.instanceLevelController.level];
                if (landArray[i, j] == -1) {
                    GameObject obj = Instantiate(groundcube, new Vector3(0.5f + i, -10, 0.5f + j), Quaternion.identity);
                }
            }
        }
        //初始化fishArray  
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (landArray[i, j] == -1)
                    continue;
                GameObject obj = Instantiate(seacube[landArray[i, j]], new Vector3(0.5f + i, -10, 0.5f + j), Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update() {
        //死亡特效
        if (LevelController.instanceLevelController.isPassed || LevelController.instanceLevelController.isOver) {
            print("isFish");
            for (int i = 0; i < 5; ++i) {
                for (int j = 0; j < 5; ++j) {
                    if (!cubeRiseControl[i, j].isFished && landArray[i, j] > 0) {
                        cubeRiseControl[i, j].cubeMaterial = redMaterial;
                    }
                }
            }
        }
        if (isBirdChosen && isFishChosen) {
            isFlying = true;
            isGetPosition = false;
            isBirdChosen = false;
            isFishChosen = false;
        }
        if (isFlying) {
            birdObject.transform.position = Vector3.Lerp(birdObject.transform.position,
               new Vector3(fishPosition.x, ymax, fishPosition.z), birdFlySpeed * Time.deltaTime);
            birdObject.transform.localScale = Vector3.Lerp(birdObject.transform.localScale,
                new Vector3(0.1f, 0.1f, 0.01f), birdFlySpeed * Time.deltaTime);
            if (Mathf.Abs(birdObject.transform.position.x - fishPosition.x) < 0.1 &&
                Mathf.Abs(birdObject.transform.position.z - fishPosition.z) < 0.1) {
                isFlying = false;
                isGetPosition = true;
            }
        }
    }

    public void DestroyAndExist(int a, int b) {
        upAudio.Play();
        cubeRiseControl[a, b].isDestory = true;
        GameObject obj = Instantiate(groundcube, new Vector3(0.5f + a, -10, 0.5f + b), Quaternion.identity);
        landArray[a, b] = -1;
    }

    public void AddScore(int a, int b) {
        if (landArray[a, b] != -1) {
            currentSocre = currentSocre + landArray[a, b] * 100;
            print("Score : ");
            print(currentSocre);
            if (landArray[a, b] == 0) {
                cubeRiseControl[a, b].cubeMaterial = violentMaterial;

            } else {
                cubeRiseControl[a, b].cubeMaterial = greeMaterial;
                Vector3 newFishPosition = fishHolderTransform.position;
                cubeRiseControl[a, b].isFished = true;
                newFishPosition.y += 20 + counter++ * 5;
                GameObject obj = Instantiate(fishObj[landArray[a, b] - 1], newFishPosition, Quaternion.identity);
            }
        }
    }
}
