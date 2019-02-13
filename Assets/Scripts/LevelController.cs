using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
                      
public class LevelController : MonoBehaviour {
    public static LevelController instanceLevelController;
    public Text text1;
    public Text text2;
    public int level = 1;
    public bool isPassed = false;
    public bool isOver = false;
    public int[] targetScore = new int[6];
    public int[,,] levelmap = new int[5, 5, 6];
    public int sum = 0;
    public int count1 = 0;
    public int count2 = 0;
    public int count3 = 0;

    private void Awake() {
        instanceLevelController = this;                  
        /*for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                levelcount[i, j] = 0;
            }
        }*/
        targetScore[1] = 200;
        levelmap[1, 1, 1] = 1;
        levelmap[3, 1, 1] = 1;

        targetScore[2] = 700;
        levelmap[1, 1, 2] = 3;
        levelmap[1, 2, 2] = 2;
        levelmap[3, 4, 2] = 1;
        levelmap[4, 4, 2] = 1;  

        targetScore[3] = 1900;
        levelmap[0, 1, 3] = 3;
        levelmap[1, 1, 3] = 1;
        levelmap[1, 2, 3] = 3;
        levelmap[1, 3, 3] = 1;
        levelmap[1, 4, 3] = 1;
        levelmap[2, 0, 3] = 3;
        levelmap[2, 1, 3] = 3;
        levelmap[2, 2, 3] = 2;
        levelmap[2, 3, 3] = 2;
        levelmap[3, 2, 3] = 1;
        levelmap[4, 2, 3] = 1;
        levelmap[4, 3, 3] = 1;

        sum = 0;
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                int a = Random.Range(0, 4);
                levelmap[i, j, 4] = a;   
                switch (a) {
                    case 1:
                        count1++;
                        break;
                    case 2:
                        count2++;
                        break;
                    case 3:
                        count3++;
                        break;
                }
            }
        }
        sum = count1 * 4 + count2 * 8 + count3 * 12;
        targetScore[4] = sum * 16 / 100 * 100;


        text2.text = "Goal:" + targetScore[level];
    }

    private void Update() {
        text1.text = "Score:" + GameManager.instanceManager.currentSocre; 
        if (GameManager.instanceManager.currentSocre >= targetScore[level]) {
            print(GameManager.instanceManager.currentSocre);
            isPassed = true;
        }
        
        if (CagePlatformController.instanceCagePlatform.birdCounter == 0 && GameManager.instanceManager.currentSocre < targetScore[level]) {
            isOver = true;
        }
        if (isOver) {
            print("Over");

            Invoke("LoadNowScene", 10f);
        }
        if (isPassed == true) {
            print("passed");

            Invoke("LoadNextScene", 10f); 
        }
    }

    public void LoadNextScene() {
        if (level < 4) {
            SceneManager.LoadScene(level + 1);
        } else if (level == 4) {
            SceneManager.LoadScene(4);
        }
    }

    public void LoadNowScene() {
        SceneManager.LoadScene(level);
    }
}
