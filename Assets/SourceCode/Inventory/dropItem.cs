using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class dropItem : MonoBehaviour, IPointerClickHandler
{

    public GameObject Player;
    public InventorySystem IS;
    public Slot S;

    void start() {
        
        IS = IS.GetComponent<InventorySystem>();
        S = S.GetComponent<Slot>();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
    for (int i = 0; i < IS.allSlots; i++)
            {
        if(IS.slot[i].GetComponent<Slot>().empty == false && transform.parent.GetComponent<Slot>().item == IS.slot[i].GetComponent<Slot>().item ) {
        IS.slot[i].GetComponent<Slot>().item.transform.SetParent(null);
        IS.slot[i].GetComponent<Slot>().item.transform.localPosition = Player.transform.localPosition + new Vector3(0,0,-1);
        IS.slot[i].GetComponent<Slot>().item.SetActive(true);
        IS.slot[i].GetComponent<Slot>().item = null;
        IS.slot[i].GetComponent<Slot>().type = null;
        IS.slot[i].GetComponent<Slot>().description = null;
        IS.slot[i].GetComponent<Slot>().icon = null;
        IS.slot[i].GetComponent<Slot>().empty = true;
        transform.parent.GetComponent<Image>().sprite = null;
        transform.parent.GetComponent<Image>().color = new Color32(15, 59, 49, 225);
                }
        }
    }
}
