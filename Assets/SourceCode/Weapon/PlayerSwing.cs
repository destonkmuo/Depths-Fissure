using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour{
    public Collider col;
    public playerAnimations PA;
    public AudioSource AS;
    public AudioClip AC;
    public SkillsAndLevels SL;

    void Start() {
      SL = SL.GetComponent<SkillsAndLevels>();
        PA = PA.GetComponent<playerAnimations>();
    }

    void OnTriggerEnter(Collider other) {
      if(other.tag == "Enemy" && PA._time > .845f) {
        AS.PlayOneShot(AC);
        other.transform.GetComponent<EnemyAI>().health -= transform.GetComponent<ItemScript>().Damage * 1 + SL.strVal * .08f;
        Debug.Log(transform.GetComponent<ItemScript>().Damage * 1 + SL.strVal * .1f);
      }
    }
}
