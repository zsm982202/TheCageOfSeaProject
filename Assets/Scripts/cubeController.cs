using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour {

    private Transform cubetransform;
    public cubeRiseController cubeRiseControl;
    public GameObject seacube;

    public int x;//方块的横坐标
    public int y;//方块的纵坐标
    private int x1;//横坐标左端点
    private int x2;//横坐标右端点
    private int y1;//纵坐标左端点
    private int y2;//纵坐标右端点
    public bool isConfirmPosition = false;
    // Use this for initialization
    void Start() {
        cubeRiseControl = this.GetComponent<cubeRiseController>();
        cubetransform = this.GetComponent<Transform>();
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if ((cubetransform.position.x == 0.5 + i) &&
                    (cubetransform.position.z == 0.5 + j)) {
                    x = i;
                    y = j;
                }
            }
        }
        GameManager.instanceManager.cubeRiseControl[x, y] = this.cubeRiseControl;

    }

    // Update is called once per frame
    void Update() {
        if (GameManager.instanceManager.isFlying == false && GameManager.instanceManager.isGetPosition == true && isConfirmPosition == true) {
            for (int i = x1; i <= x2; i++) {
                for (int j = y1; j <= y2; j++) {
                    //销毁海 生成地
                    if (GameManager.instanceManager.landArray[i, j] != -1) {
                        GameManager.instanceManager.DestroyAndExist(i, j);
                        print(GameManager.instanceManager.landArray[i, j]);
                    }
                }
            }
            GameManager.instanceManager.isGetPosition = false;
            isConfirmPosition = false;
        }
    }

    private void OnMouseDown() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform == this.transform) {
                if (GameManager.instanceManager.isBirdChosen) {
                    GameManager.instanceManager.fishPosition = this.transform.position;
                    if (GameManager.instanceManager.landArray[x, y] != -1) {
                        if (x > 0 && x < 4) {
                            x1 = x - 1;
                            x2 = x + 1;
                        } else if (x == 0) {
                            x1 = 0;
                            x2 = 1;
                        } else if (x == 4) {
                            x1 = 3;
                            x2 = 4;
                        }

                        if (y > 0 && y < 4) {
                            y1 = y - 1;
                            y2 = y + 1;
                        } else if (y == 0) {
                            y1 = 0;
                            y2 = 1;
                        } else if (y == 4) {
                            y1 = 3;
                            y2 = 4;
                        }

                        Score(GameManager.instanceManager.birdKind - 1, x, y);
                        isConfirmPosition = true;
                        //将点击的位置传入Game Manager
                        GameManager.instanceManager.isFishChosen = true;
                        GameManager.instanceManager.fishPosition = new Vector3(cubetransform.position.x, cubetransform.position.y, cubetransform.position.z);
                        //记分(4种)
                    }
                }
            }
        }
    }

    //记分(4种)
    void Score(int birdkind, int x, int y) {
        CagePlatformController.instanceCagePlatform.birdCounter--;
        switch (birdkind) {
            case 0:
                for (int i = x - 1; i <= x + 1; ++i) {
                    if (i >= 0 && i <= 4) {
                        GameManager.instanceManager.AddScore(i, y);
                    }
                }
                break;
            case 1:
                for (int i = y - 1; i <= y + 1; ++i) {
                    if (i >= 0 && i <= 4) {
                        GameManager.instanceManager.AddScore(x, i);
                    }
                }
                break;
            case 2:
                for (int i = x - 1, j = y - 1; i <= x + 1; ++i, ++j) {
                    if (i >= 0 && i <= 4 && j >= 0 && j <= 4) {
                        GameManager.instanceManager.AddScore(i, j);
                    }
                }
                break;
            case 3:
                for (int i = x - 1, j = y + 1; i <= x + 1; ++i, --j) {
                    if (i >= 0 && i <= 4 && j >= 0 && j <= 4) {
                        GameManager.instanceManager.AddScore(i, j);
                    }
                }
                break;
        }
    }
}


