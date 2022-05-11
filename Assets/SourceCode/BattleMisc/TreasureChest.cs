using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : MonoBehaviour
{
    public Animator anim;
    public bool isOpen = false;
    public GameObject sword1;
    public GameObject sword2;
    public GameObject sword3;
    public GameObject sword4;
    public GameObject sword5;
    public GameObject sword6;
    public GameObject sword7;
    public GameObject sword8;
    public GameObject sword9;
    public GameObject sword10;
    public GameObject sword11;
    public GameObject sword12;
    public GameObject healPotion;

    public float cooldownTimer = 3f;
    public AudioSource source;
    public AudioClip clip;

    void Update() {
        if (cooldownTimer > 0 && isOpen) {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer < 0) {
            cooldownTimer = 0;
        }
        if(cooldownTimer == 0) {
            rarityInterpreter();
            Destroy(this.gameObject);
            cooldownTimer = 3f;
        }
    }

    public void rarityInterpreter() {
        int rarity = Random.Range(0, 99);
        if(rarity < 1) {
            int randomPickdrop = Random.Range(0, 3);
            if(randomPickdrop == 0) {
                GameObject item = Instantiate(sword10, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            } else if(randomPickdrop == 1) {
                GameObject item = Instantiate(sword11, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            } else if(randomPickdrop == 2) {
                GameObject item = Instantiate(sword12, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            }
        } else if(rarity < 10) {
            int randomPickdrop = Random.Range(0, 3);
            if(randomPickdrop == 0) {
                GameObject item = Instantiate(sword7, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            } else if(randomPickdrop == 1) {
                GameObject item = Instantiate(sword8, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            } else if(randomPickdrop == 2) {
                GameObject item = Instantiate(sword9, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            }
        } else if(rarity < 25) {
            int randomPickdrop = Random.Range(0, 3);
            if(randomPickdrop == 0) {
                GameObject item = Instantiate(sword4, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            } else if(randomPickdrop == 1) {
                GameObject item = Instantiate(sword5, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            } else if(randomPickdrop == 2) {
                GameObject item = Instantiate(sword6, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            }
        } else if(rarity < 65) {
            int randomPickdrop = Random.Range(0, 3);
            if(randomPickdrop == 0) {
                GameObject item = Instantiate(sword1, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            } else if(randomPickdrop == 1) {
                GameObject item = Instantiate(sword2, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);
            } else if(randomPickdrop == 2) {
                GameObject item = Instantiate(sword3, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                item.SetActive(true);   
            }
        } else {
            GameObject item = Instantiate(healPotion, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            item.SetActive(true);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "player") {
            if(Input.GetKeyDown("e") && !isOpen) {
                source.PlayOneShot(clip);
                anim.SetBool("isOpen", true);
                isOpen = true;
            }
        }
    }
}