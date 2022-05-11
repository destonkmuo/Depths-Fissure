using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    private void Start() { }

    private void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.X)
            && transform.GetComponent<ItemScript>().ID == 243686
            && transform.tag == "itemOff"
        )
        { // Draws Weapon
            PickUp();
        }
    }

    public bool equipped = false;
    private void PickUp()
    {
        if (equipped == false)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            transform.localPosition = new Vector3(0, 2, 2f);
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            equipped = true;
        }
        else
        {
            rb.isKinematic = true;
            coll.isTrigger = false;
            transform.localPosition = new Vector3(0, 1.6f, -.9f);
            transform.localRotation = Quaternion.Euler(0, 0, -60);
            equipped = false;
        }
    }
}
