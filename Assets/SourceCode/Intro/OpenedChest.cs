using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedChest : MonoBehaviour
{
    public CameraController CS;
    public PlayerController PS;
    public GameObject Text;

    void Start() {
        CS = CS.GetComponent<CameraController>();
        PS = PS.GetComponent<PlayerController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "player" && Input.GetKeyDown("e")) {
            CS.targetOffSet = new Vector3(0, 80, -120);
            PS.movementEnable1 = false;
            Text.SetActive(true);
        }
    }

}
