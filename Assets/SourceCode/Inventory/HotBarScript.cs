using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HotBarScript : MonoBehaviour, IPointerClickHandler {
  public InventorySystem IS;
  public Slot S;
  public GameObject Player;
  public GameObject itemWP;
  public string typeWP;
  public int IDWP;
  public string descriptionWP;
  public GameObject playersHand;
  void start()
  {
    IS = IS.GetComponent<InventorySystem>();
    S = S.GetComponent<Slot>();
  }
  public void OnPointerClick(PointerEventData pointerEventData) { handler(); }

  void change()
  {
    itemWP.tag = "item";
    transform.GetComponent<Image>().sprite = null;
    transform.GetComponent<Image>().color = new Color32(14, 49, 49, 225);
    Color tmp = transform.GetComponent<Image>().color;
    tmp.a = 0f;
    transform.GetComponent<Image>().color = tmp;
    itemWP = null;
  }
  void handler()
  {
    if (IS.weaponSlotUsed == true && transform.GetComponent<Image>().sprite != null) {
      bool OpenSlot = true;
      Debug.Log(gameObject);
      for (int i = 0; i < IS.allSlots; i++) {
        if (IS.slot[i].GetComponent<Slot>().empty && OpenSlot == true && typeWP == "weapon" && transform.tag == "weapon") {
          playersHand.transform.GetChild(0).parent = IS.slot[i].transform;
          IS.slot[i].GetComponent<Slot>().item = itemWP;
          IS.slot[i].GetComponent<Slot>().type = typeWP;
          IS.slot[i].transform.GetComponent<Image>().sprite = transform.GetComponent<Image>().sprite;
          IS.slot[i].GetComponent<Slot>().icon = transform.GetComponent<Image>().sprite;
          itemWP.transform.parent = IS.slot[i].transform;
          Destroy(gameObject.transform.GetChild(0).gameObject);
          IS.slot[i].GetComponent<Slot>().empty = false;
          IS.slot[i].GetComponent<Slot>().item.SetActive(false);
          IS.weaponSlotUsed = false;
          OpenSlot = false;
          change();
        }
      }
      OpenSlot = true;
    }

    if (IS.utility1SlotUsed == true && transform.GetComponent<Image>().sprite != null && typeWP == "utility" && transform.tag == "utility1") {
      bool OpenSlot = true;
      for (int i = 0; i < IS.allSlots; i++) {
        if (IS.slot[i].GetComponent<Slot>().empty && OpenSlot == true) {
          IS.slot[i].GetComponent<Slot>().item = itemWP;
          IS.slot[i].GetComponent<Slot>().type = typeWP;
          itemWP.tag = "item";
          Player.transform.GetChild(5).transform.GetChild(0).GetComponent<util>().enabled = false;
          Player.transform.GetChild(5).transform.GetChild(0).parent = IS.slot[i].transform;
          IS.slot[i].transform.GetComponent<Image>().sprite = transform.GetComponent<Image>().sprite;
          IS.slot[i].GetComponent<Slot>().icon = transform.GetComponent<Image>().sprite;
          itemWP.transform.parent = IS.slot[i].transform;
          transform.GetComponent<Image>().sprite = null;
          transform.GetComponent<Image>().color = new Color32(14, 49, 49, 225);
          Color tmp = transform.GetComponent<Image>().color;
          tmp.a = 0f;
          transform.GetComponent<Image>().color = tmp;
          IS.utility1SlotUsed = false;
          IS.slot[i].GetComponent<Slot>().empty = false;
          IS.slot[i].GetComponent<Slot>().item.SetActive(false);
          OpenSlot = false;
          itemWP = null;
        }
      }
      OpenSlot = true;
    } else if (IS.utility2SlotUsed == true && transform.GetComponent<Image>().sprite != null && typeWP == "utility" && transform.tag == "utility2") {
      bool OpenSlot = true;
      for (int i = 0; i < IS.allSlots; i++) {
        if (IS.slot[i].GetComponent<Slot>().empty && OpenSlot == true) {
          IS.slot[i].GetComponent<Slot>().item = itemWP;
          IS.slot[i].GetComponent<Slot>().type = typeWP;
          itemWP.tag = "item";
          Player.transform.GetChild(6).transform.GetChild(0).GetComponent<util>().enabled = false; //change item script on or off
          Player.transform.GetChild(6).transform.GetChild(0).parent = IS.slot[i].transform;
          IS.slot[i].transform.GetComponent<Image>().sprite = transform.GetComponent<Image>().sprite;
          IS.slot[i].GetComponent<Slot>().icon = transform.GetComponent<Image>().sprite;
          itemWP.transform.parent = IS.slot[i].transform;
          transform.GetComponent<Image>().sprite = null;
          transform.GetComponent<Image>().color = new Color32(14, 49, 49, 225);
          Color tmp = transform.GetComponent<Image>().color;
          tmp.a = 0f;
          transform.GetComponent<Image>().color = tmp;
          IS.utility2SlotUsed = false;
          IS.slot[i].GetComponent<Slot>().empty = false;
          IS.slot[i].GetComponent<Slot>().item.SetActive(false);
          OpenSlot = false;
          itemWP = null;
        }
      }
      OpenSlot = true;
    }
  }
}