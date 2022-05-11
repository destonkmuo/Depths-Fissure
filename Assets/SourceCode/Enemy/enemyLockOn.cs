using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLockOn : MonoBehaviour
{
public CameraController cam;
public GameObject player;
public bool isLocked = false;

        void Update() {
            transform.position = player.transform.position;
        }

        void Start() {
            cam = cam.GetComponent<CameraController>();
        }
        private void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown("q") && !isLocked && other.tag == "Enemy") {
            isLocked = true;
            cam.target = other.transform;
        } 

        // find a way to add a free unlock
        }

        private void OnTriggerExit(Collider other) {
            if (other.tag == "Enemy") {
            isLocked = false;
            cam.target = player.transform;
            }
        }
}
