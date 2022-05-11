using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeDX : MonoBehaviour
{
public int textChatInt = 0;
public GameObject Dialouge;
public PlayerController PS;

void Start() {
    PS = PS.GetComponent<PlayerController>();
}
private void OnTriggerStay(Collider other) {
    if(other.tag == "npc" && Input.GetKeyDown("e")) {
        PS.sprintSpeed = 0;
        textChatInt = 0;      
        Dialouge.SetActive(true);
    }
}
}
