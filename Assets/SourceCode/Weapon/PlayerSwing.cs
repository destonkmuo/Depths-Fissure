using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour{
    public Collider col;
    public playerAnimations PA;
    public AudioSource AS;
    public AudioClip AC;

    void Start() {
        PA = PA.GetComponent<playerAnimations>();
    }

    void OnTriggerEnter(Collider other) {
      if(other.tag == "Enemy" && PA._time > .845f) {
        AS.PlayOneShot(AC);
        other.transform.GetComponent<EnemyAI>().health -= transform.GetComponent<ItemScript>().Damage;
      }
    }
}
