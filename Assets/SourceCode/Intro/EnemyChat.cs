using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChat : MonoBehaviour
{
    public Text text;
    public int textChatInt = 0;
    public Button btn1;
    public PlayerController PS;
    public CameraController CS;
    public OnIntroFinish OIF;

    void Start() {
    Button btn = btn1.GetComponent<Button>();
	btn.onClick.AddListener(TaskOnClick);  
    PS = PS.GetComponent<PlayerController>(); 
    CS = CS.GetComponent<CameraController>();
    
    }
    // Update is called once per frame
    void Update() {
        if(textChatInt == 1) {
            text.text = "I SEE YOU'VE FINALLY AWOKEN VIA MY SOULS";
        }
        if(textChatInt == 2) {
            text.text = "WHATS THAT?";
        }
                if(textChatInt == 3) {
            text.text = "YOU WISH TO RETURN TO THE OVERWORLD AND SEEK REVENGE UPON THOSE WHO TORTURED YOU?";
        }
                if(textChatInt == 4) {
            text.text = "HA";
        }
                if(textChatInt == 5) {
            text.text = "CAN YOU EVEN KILL A TROGLADYTE???";
        }
                if(textChatInt == 6) {
            text.text = "OH ...";
        }
                if(textChatInt == 7) {
            text.text = "IT SEEMS YOUR MEMORY HAS FADED";
        }
                if(textChatInt == 8) {
            text.text = "ALLOW ME TO RECOLLECT YOUR MEMORY";
        }
                if(textChatInt == 9) {
            text.text = "THESE RUNES YOU CALL KEYS, PRESS THE WASD TO MOVE AROUND OBVIOUSLY YOU GOT HERE SO YOU KNOW THIS";
            PS.movementEnable1 = true;
            CS.targetOffSet = new Vector3(0, 10, -22);
        }
        if(textChatInt == 10) {
            text.text = "PRESS THE RUNE I FOR YOUR INVENTORY, PRESS IT AGAIN TO LEAVE";
        }
        if(textChatInt == 11) {
            text.text = "THERE YOU CAN CHOOSE WHICH WEAPONRY SUITS YOUR ENEMIES DEATH";
        }
        if(textChatInt == 12) {
            text.text = "PRESS THE RUNE R TO BLOCK YOUR ENEMIES ATTACKS... THOUGH YOU ARE FRAGILE SO YOU HAVE YOUR LIMITS";
        }
        if(textChatInt == 13) {
            text.text = "PRESS THE RUNE SPACE TO JUMP, YOU WILL NEED THIS TO TRAVERSE THE VAST OVERWORLD";
        }
        if(textChatInt == 14) {
            text.text = "YOU WILL USE THE ... MOUSE??? THATS NOT A MOUSE";
        }
        if(textChatInt == 15) {
            text.text = "USE THE LEFT KEY ON THE BLOCK THAT TRAVERSES A PAD, THIS WILL ADMINISTER ATTACKS AND INPUTS THIS WAY, IN ORDER TO TRULY SWING YOU MUST ROTATE YOUR CHARACTER";
        }
        if(textChatInt == 16) {
            text.text = "REMEMBER YOU ARE THE WEAPON THE SWORD IS MERELY A TOOL";
        }
        if(textChatInt == 17) {
            text.text = "PRESS THE RUNE LEFT SHIFT TO SPRINT AS WELL AS THE Q RUNE TO LOCK ON TO ENEMIES";
        }
        if(textChatInt == 18) {
            text.text = "NOW THAT YOU'VE LEARNED ALL THE BASIC CONTROLS WE WILL MOVE TO YOUR EYES";
        }
        if(textChatInt == 19) {
            text.text = "IMPLANTED IN THEM ARE FLAT SURFACES YOU MORTALS CALL USER INTERFACE";
        }
        if(textChatInt == 20) {
            text.text = "ON THE VERY LEFT IS THE EXPERIENCE BAR ... WHEN YOU SLAY ENEMIES THIS BAR WILL GO UP";
        }
        if(textChatInt == 21) {
            text.text = "TO THE RIGHT OF IT IS A SHIELD WHICH INDICATES THE AMOUNT OF BLOCKS YOU CAN TAKE TILL YOU GET KNOCKED UNCONCIOUS";
        }
        if(textChatInt == 22) {
            text.text = "DOWN AT THE BOTTOM YOU SEE TWO BARS, THE GREEN INDICATES YOUR HEALTH, THE BLUE INDICATES YOUR STAMINA";
        }
        if(textChatInt == 23) {
            text.text = "NOW FINALLY PRESS O TO OPEN YOUR MASTERY";
        }
        if(textChatInt == 24) {
            text.text = "HERE YOU CAN UPGRADE YOUR STATS";
        }
        if(textChatInt == 25) {
            text.text = "NOW YOU MAY RETURN TO THE OVERWORLD AS A GLEANER... ";
        }
        if(textChatInt == 25) {
            text.text = "GOOD LUCK ...";
            OIF.LoadLevel(1);
            textChatInt += 1;
        }
    }
    public void TaskOnClick() {
        textChatInt += 1;
    }
}
