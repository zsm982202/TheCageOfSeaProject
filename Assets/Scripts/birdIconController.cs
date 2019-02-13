using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdIconController : MonoBehaviour {

    public int birdType = 0;
    public AudioSource birdClick;
    private void Start() {
        birdClick = this.GetComponent<AudioSource>();
    }

    private void OnMouseDown() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform == transform) {
                birdClick.Play();
                GameManager.instanceManager.birdObject = this.gameObject;
                GameManager.instanceManager.isBirdChosen = true;
                GameManager.instanceManager.birdKind = this.birdType;
            }
            
        }
    }
}
