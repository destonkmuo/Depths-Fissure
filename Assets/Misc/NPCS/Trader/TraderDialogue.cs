using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraderDialogue : MonoBehaviour
{
    public Text text;
    public Button btn1;
    public PlayerController PS;
    public DialougeDX DX;
    public GameObject Dialouge;
    public bool isChatDone = false;
    public bool isChartStarted = false;
    public bool isMoving = true;
    public GameObject traderPanel;
    void Start() {
    Button btn = btn1.GetComponent<Button>();
	btn.onClick.AddListener(TaskOnClick);  
    PS = PS.GetComponent<PlayerController>(); 
    DX = DX.GetComponent<DialougeDX>();
    }
    // Update is called once per frame
    void Update() {
        if(!isChatDone) {
        if(DX.textChatInt == 0) {
            isMoving = false;
            text.text = "HELLO WANDERER...";
        }
        if(DX.textChatInt == 1) {
            text.text = "I HAVEN'T SEEN YOU IN THIS TOWN BEFORE";
        }
        if(DX.textChatInt == 2) {
            text.text = "OH...";
        }
        if(DX.textChatInt == 3) {
            text.text = "YOU'RE A SPAWN OF THE LICH OF THE DEPTHS?!?!";
        }
        if(DX.textChatInt == 4) {
            text.text = "YOU DONT LOOK VERY STRONG THOUGH";
        }
        if(DX.textChatInt == 5) {
            text.text = "WELL MOST TRAVELERS USUALLY TAKE THE PATH SOUTH EAST FROM HERE JUST FOLLOW THE PATH";
        }
        if(DX.textChatInt == 6) {
            text.text = "THERE YOU CAN FIND BANDITS AND IF THE LORE IS CORRECT THE GOBLIN KING";
        }
        if(DX.textChatInt == 7) {
            text.text = "GOOD LUCK... THERE IS A SWORD IN THE CENTER OF THE VILLAGE, SEE IF YOU ARE WORTHY";
            isMoving = true;
            PS.rotationEnable1 = true;
        }
        if(DX.textChatInt == 8) {
            text.text = "";
            Dialouge.SetActive(false);
            isChatDone = true;
        }
        } else {
            PS.sprintSpeed = 1;
            PS.rotationEnable1 = true;   
        }

    }
    public void TaskOnClick() {
        DX.textChatInt += 1;
    }
}
