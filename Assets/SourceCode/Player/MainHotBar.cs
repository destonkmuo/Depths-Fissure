using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHotBar : MonoBehaviour
{

    public GameObject HB1;
    public GameObject HB2;
    public GameObject HB3;
    public GameObject HB4;
    public GameObject HB5;
    public GameObject HB6;

    public InventorySystem IS;

    void start()
  {
    IS = IS.GetComponent<InventorySystem>();
  }

    // Update is called once per frame

    public bool weaponSlotBool = false;
    public bool utilBool2 = false;
    public bool utilBool3 = false;
    public bool utilBool4 = false;
    public bool utilBool5 = false;
    public bool utilBool6 = false;


    void Update()
    {
        if(HB1.GetComponent<Image>().sprite != null && gameObject.tag == "weapon" && IS.weaponSlotUsed == true && weaponSlotBool == false) {
            gameObject.GetComponent<Image>().sprite = HB1.GetComponent<Image>().sprite;
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
            weaponSlotBool = true;
        } else if(HB1.GetComponent<Image>().sprite == null && weaponSlotBool == true) {
            transform.GetComponent<Image>().color = new Color32(14, 49, 49, 225);
            gameObject.GetComponent<Image>().sprite = null;
            weaponSlotBool = false;
        }
        /*if(HB2.GetComponent<Image>().sprite != null && gameObject.tag == "special1" && IS.weaponSlotUsed == true && utilBool2 == false) {
            gameObject.GetComponent<Image>().sprite = HB2.GetComponent<Image>().sprite;
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
            utilBool2 = true;
        } else if(HB2.GetComponent<Image>().sprite == null && utilBool2 == true) {
            transform.GetComponent<Image>().color = new Color32(14, 49, 49, 225);
            gameObject.GetComponent<Image>().sprite = null;
            utilBool2 = false;
        }
        if(HB3.GetComponent<Image>().sprite != null && gameObject.tag == "special2" && IS.weaponSlotUsed == true && utilBool3 == false) {
            gameObject.GetComponent<Image>().sprite = HB3.GetComponent<Image>().sprite;
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
            utilBool3 = true;
        } else if(HB3.GetComponent<Image>().sprite == null && utilBool3 == true) {
            transform.GetComponent<Image>().color = new Color32(14, 49, 49, 225);
            gameObject.GetComponent<Image>().sprite = null;
            utilBool3 = false;
        }
        if(HB4.GetComponent<Image>().sprite != null && gameObject.tag == "special3" && IS.weaponSlotUsed == true && utilBool4 == false) {
            gameObject.GetComponent<Image>().sprite = HB4.GetComponent<Image>().sprite;
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
            utilBool4 = true;
        } else if(HB4.GetComponent<Image>().sprite == null && utilBool4 == true) {
            transform.GetComponent<Image>().color = new Color32(14, 49, 49, 225);
            gameObject.GetComponent<Image>().sprite = null;
            utilBool4= false;
        }*/
        if(HB5.GetComponent<Image>().sprite != null && gameObject.tag == "utility1" && IS.utility1SlotUsed == true && utilBool5 == false) {
            gameObject.GetComponent<Image>().sprite = HB5.GetComponent<Image>().sprite;
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
            utilBool5 = true;
        } else if(HB5.GetComponent<Image>().sprite == null && utilBool5 == true) {
            transform.GetComponent<Image>().color = new Color32(14, 49, 49, 225);          
            gameObject.GetComponent<Image>().sprite = null;
            utilBool5 = false;
        }
        if(HB6.GetComponent<Image>().sprite != null && gameObject.tag == "utility2" && IS.utility2SlotUsed == true && utilBool6 == false) {
            gameObject.GetComponent<Image>().sprite = HB6.GetComponent<Image>().sprite;
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
            utilBool6 = true;
        } else if(HB6.GetComponent<Image>().sprite == null && utilBool6 == true) {
            transform.GetComponent<Image>().color = new Color32(14, 49, 49, 225);
            gameObject.GetComponent<Image>().sprite = null;
            utilBool6 = false;
        }
    }
}
