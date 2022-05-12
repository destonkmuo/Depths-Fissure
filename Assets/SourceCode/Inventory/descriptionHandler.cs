using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class descriptionHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler// required interface when using the OnPointerEnter method.
{
    public GameObject text_GO;
    public Text text;
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!transform.GetComponent<Slot>().empty) {
            text_GO.transform.position = new Vector2(transform.position.x, transform.position.y + 100);
        text.text = "NAME: " + transform.GetComponent<Slot>().description.ToUpper() + "\nTYPE: " + transform.GetComponent<Slot>().type.ToUpper();
        }
    }
    public void OnPointerExit(PointerEventData eventData) {

        text.text = "";
    }
}