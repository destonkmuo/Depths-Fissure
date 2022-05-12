using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public playerAnimations PA;
    public GameObject _Block;
    public GameObject BlockBroken;
    public GameObject Crack;
    public AudioSource source;
    public AudioClip clip;
    public bool isBlockBroken = false;
    [System.NonSerialized] public float blockAmount = 10;
    [System.NonSerialized] public float originalBlockAmount = 10;
    public float BlockInc;
    public float blockRegenTimer = .1f;
    public float ogblockRegenTimer = .1f;
    public PlayerController PS;
    public TraderDialogue TD;
    public SkillsAndLevels SL;
    // Start is called before the first frame update
    void Start()
    {
        SL = SL.GetComponent<SkillsAndLevels>();
        TD = TD.GetComponent<TraderDialogue>();
        PA = PA.GetComponent<playerAnimations>();
        PS = PS.GetComponent<PlayerController>();
    }
    void Update() 
    {
        originalBlockAmount = 10f * Mathf.Floor(1 + SL.forVal * .15f);
        Color tmp = Crack.transform.GetComponent<Image>().color;
        tmp.a = BlockInc/originalBlockAmount;
        Crack.transform.GetComponent<Image>().color = tmp;

        if(blockAmount == 0) {
            source.PlayOneShot(clip);
            isBlockBroken = true;
            _Block.SetActive(false);
            BlockBroken.SetActive(true);
            blockAmount -= 1;
        }
        if(blockAmount == -1) {
            blockRegenTimer -= Time.deltaTime;
        }
        if(blockRegenTimer < 0) {
            blockRegenTimer = 0;
        }
        if(blockRegenTimer == 0) {
            blockAmount = originalBlockAmount;
            blockRegenTimer = ogblockRegenTimer;
            BlockInc = 0;
            _Block.SetActive(true);
            isBlockBroken = false;
            BlockBroken.SetActive(false);
            if(TD.isMoving) {
            PS.movementEnable = true;
            PS.movementEnable1 = true;
            }
        }
        
    }

   /* public bool time(float time){
        float _time = time;
        bool isDone;
        if(_time > 0) {
            _time -= Time.deltaTime;
        }
        if(_time < 0) {
            _time = 0;
        }
        if(_time == 0) {
            isDone = true;
        } else {
            return false
        }
        return isDone;
    }
    */
}
