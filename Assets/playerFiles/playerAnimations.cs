using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{

    public bool isWalking = false;
    public bool isGuarding = false;
    public Animator anim;
    public GameObject StaminaBar;
    public InventorySystem IS;
    public PlayerController PS;
    public Block B;
    public bool Swing;
    public HealthDisplay HD;
    public float _time = .85f;
    public GameObject Hand;
    public TraderDialogue TD;
    public AudioSource Slash;
    public AudioClip SlashClip;
    public AudioSource Walking;
    public AudioClip WalkingClip;
    public AudioSource Running;
    public AudioClip RunningClip;
    void Start() {
        IS = IS.GetComponent<InventorySystem>();
        PS = PS.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        B = B.GetComponent<Block>();
        HD = HD.GetComponent<HealthDisplay>();
        TD = TD.GetComponent<TraderDialogue>();
    }

    void Update() {
        if(_time > 0) {
            _time -= Time.deltaTime;
        }
        if(_time < 0) {
            _time = 0;
        }
        if(_time == 0 && Input.GetKeyDown(KeyCode.Mouse0) && IS.weaponSlotUsed && !IS.inventoryEnabled && Hand.transform.childCount > 0) {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("Idle", false);
            anim.SetBool("isSlash", true);
            Slash.PlayOneShot(SlashClip);
            Hand.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = true;
            Swing = true;
            _time = .85f;
        } else if(Hand.transform.childCount > 0 && !isWalking && Swing && _time == 0f) {
            anim.SetBool("isSlash", false);
            anim.SetBool("Idle", true);
            Hand.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = false;
            Swing = false;
        }
        if(!B.isBlockBroken) {
            if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                if(!IS.inventoryEnabled) {
                    anim.SetBool("isWalking", true);
                    anim.SetBool("Idle", false);
                    isWalking = true;
                }
            } else {
                anim.SetBool("isWalking", false);
                isWalking = false;
            }
            if(!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d") && !IS.inventoryEnabled && !B.BlockBroken && !isWalking)
            {
                Debug.Log("A");
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("Idle", true);
                isWalking = false;
            } else if(Input.GetKey("w") && Input.GetKey("a") && Input.GetKey("s") && Input.GetKey("d") && IS.inventoryEnabled && B.BlockBroken && isWalking) {
               anim.SetBool("Idle", false); 
            }
            if(isWalking == true && Input.GetKey(KeyCode.LeftShift) && StaminaBar.transform.localScale.x > 0 && !IS.inventoryEnabled) {
                anim.SetBool("isRunning", true);
                anim.SetBool("isWalking", false);
            } else {
                anim.SetBool("isRunning", false);
            }
            if(Input.GetKeyDown(KeyCode.Space) && !IS.inventoryEnabled && !B.BlockBroken) {
                anim.SetBool("jumping", true);
            } else {
                anim.SetBool("jumping", false);
                anim.SetBool("Idle", true);
            }
            if(Input.GetKey("r")) {
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                PS.movementEnable1 = false;
                isGuarding = true;
                anim.SetBool("isGuard", true);
            } else {
                PS.movementEnable1 = true;
                isGuarding = false;
                anim.SetBool("isGuard", false);
            }
        }
        if(B.isBlockBroken) {
                isGuarding = false;
                anim.SetBool("isGuard", false);
                anim.SetBool("blockBroken", true);
                PS.movementEnable1 = false;
            } else {
                anim.SetBool("blockBroken", false);
            }
        if(HD.health == 0f) {
            anim.SetBool("onDeath", true);
        } else if (HD.health == HD.healthMax) {
            anim.SetBool("onDeath", false);
        }
    }
}

