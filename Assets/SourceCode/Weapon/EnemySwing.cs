using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwing : MonoBehaviour
{
    public Collider col;
    public EnemyAI EAI;
    public HealthDisplay HD;
    public float _time = .1f;
    public Block B;
    public AudioSource source;
    public AudioClip clip;
    public GameObject BlockBreak;
    public playerAnimations PA;

    void Start() {
        EAI = EAI.GetComponent<EnemyAI>();
        HD = HD.GetComponent<HealthDisplay>();
        PA = PA.GetComponent<playerAnimations>();
    }
    
    void Update() {
    if(EAI.Swing) {
        transform.GetComponent<BoxCollider>().enabled = true;
    } else {
        transform.GetComponent<BoxCollider>().enabled = false;
    }

    /*if(PA.Swing) {
        transform.GetComponent<BoxCollider>().enabled = true;
    } else {
        transform.GetComponent<BoxCollider>().enabled = false;
    }*/

    }
    void OnTriggerEnter(Collider other) {
      if(other.tag == "player" && !PA.isGuarding) {
        HD.health -= transform.GetComponent<ItemScript>().Damage;
      }else if(other.tag == "player" && PA.isGuarding && !B.isBlockBroken){
          BlockBreak.SetActive(true);
          source.PlayOneShot(clip);
          B.blockAmount -= 1;
          B.BlockInc += 1;
      } else if(other.tag == "player" && PA.isGuarding && B.isBlockBroken) {
            HD.health -= transform.GetComponent<ItemScript>().Damage;
      }
    }

}
