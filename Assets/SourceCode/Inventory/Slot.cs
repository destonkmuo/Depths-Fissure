using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerClickHandler {

  public bool empty;
  public Sprite icon;
  public GameObject item;
  public string type;
  public int ID;
  public string description;
  public GameObject Player;
  public GameObject SlotHolder;
  public GameObject weaponSlot, Utility1, Utility2, Special1, Special2, Special3;
  public InventorySystem IS;
  public HotBarScript HB;
  public GameObject PlayersHand;
  public int numberOf = 0;

  void start()
  {
    IS = IS.GetComponent<InventorySystem>();
    HB = HB.GetComponent<HotBarScript>();
  }
  public void OnPointerClick(PointerEventData pointerEventData)
  {
    UseItem();
    // Make tags for different types of items, aka weapons, chest piece, potions, etc, and find a way to add them to the player panel
    // when add to the player panel everything should be shown and useable.
  }

  void Update()
  {
    if (item != null) {
      transform.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
    }

    for (int i = 0; i < IS.allSlots; i++) {
      if (IS.slot[i].GetComponent<Slot>().empty == false) {
        IS.slot[i].transform.GetChild(1).gameObject.SetActive(true);
      } else if (IS.slot[i].GetComponent<Slot>().empty == true) {
        IS.slot[i].transform.GetChild(1).gameObject.SetActive(false);
      }
    }
  }

  void switchItem()
  {
    Debug.Log(item);
    item.SetActive(true);
    item.GetComponent<Rigidbody>().isKinematic = true;
    transform.GetComponent<Image>().sprite = null;
    transform.GetComponent<Image>().color = new Color32(15, 59, 49, 225);
    // is equipped is true, get from item script and apply here.
    empty = true; // WORKS FOR REMOVING, SET EMPTY FOR THAT SPECIFIC ITEM = TRUE and then just remove the images and stuff from the slot
    item = null;
  }
  public void UseItem()
  {
    if (item != null && type == "weapon" && IS.weaponSlotUsed == false) {
      item.tag = "itemOff";
      weaponSlot.GetComponent<HotBarScript>().itemWP = item;
      weaponSlot.GetComponent<HotBarScript>().typeWP = type;
      weaponSlot.GetComponent<HotBarScript>().IDWP = ID;
      weaponSlot.GetComponent<HotBarScript>().descriptionWP = description;
      item.transform.parent = PlayersHand.transform;
      item.GetComponent<Rigidbody>().isKinematic = true;
      GameObject itemCopy = Instantiate(item);
      item.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = false;
      item.transform.position = item.transform.parent.position;
      itemCopy.transform.parent = weaponSlot.transform;
      item.transform.rotation = Quaternion.Euler(-270, 0, 190);
      weaponSlot.GetComponent<Image>().sprite = transform.GetComponent<Image>().sprite;
      weaponSlot.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
      IS.weaponSlotUsed = true;
      switchItem();
    }

    if (item != null && type == "utility" && IS.utility1SlotUsed == false) {
      item.tag = "itemOff";
      Utility1.GetComponent<HotBarScript>().itemWP = item;
      Utility1.GetComponent<HotBarScript>().typeWP = type;
      Utility1.GetComponent<HotBarScript>().IDWP = ID;
      Utility1.GetComponent<HotBarScript>().descriptionWP = description;
      item.transform.parent = Utility1.transform;
      item.transform.parent = Player.transform.GetChild(5).transform;
      Utility1.GetComponent<Image>().sprite = transform.GetComponent<Image>().sprite;
      Utility1.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
      Player.transform.GetChild(5).transform.GetChild(0).GetComponent<util>().enabled = true;
      IS.utility1SlotUsed = true;
      switchItem();
    } else if (item != null && type == "utility" && IS.utility2SlotUsed == false && IS.utility1SlotUsed == true) {
      item.tag = "itemOff";
      Utility2.GetComponent<HotBarScript>().itemWP = item;
      Utility2.GetComponent<HotBarScript>().typeWP = type;
      Utility2.GetComponent<HotBarScript>().IDWP = ID;
      Utility2.GetComponent<HotBarScript>().descriptionWP = description;
      item.transform.parent = Utility2.transform;
      item.transform.parent = Player.transform.GetChild(6).transform;
      Utility2.GetComponent<Image>().sprite = transform.GetComponent<Image>().sprite;
      Utility2.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
      Player.transform.GetChild(6).transform.GetChild(0).GetComponent<util>().enabled = true;
      IS.utility2SlotUsed = true;
      switchItem();
    }
  }
  public void UpdateSlot() { transform.GetComponent<Image>().sprite = icon; }
}