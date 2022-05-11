using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class util : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthDisplay HD;
    public GameObject Player;

    public GameObject WS, SS1, SS2, SS3, UT1, UT2;
    public InventorySystem IS;
    void Start()
    {
        IS = IS.GetComponent<InventorySystem>();
        HD = HD.GetComponent<HealthDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        healBuff();
    }
    void healBuff()
    {
        if(Player.transform.GetChild(5).transform.childCount > 0)
        {
            if(Player.transform.GetChild(5).transform.GetChild(0).transform == this.transform)
                if(Input.GetKeyDown("5"))
                {
                    HD.health += .4f;
                    UT1.transform.GetComponent<Image>().sprite = null;
                    UT1.transform.GetComponent<Image>().color = new Color32(15, 59, 49, 225);
                    IS.utility1SlotUsed = false;
                    Destroy(gameObject);

                }
        }
        if(Player.transform.GetChild(6).transform.childCount > 0)
        {
            if(Player.transform.GetChild(6).transform.GetChild(0).transform == this.transform)
                if(Input.GetKeyDown("6"))
                {
                    HD.health += .4f;
                    UT2.transform.GetComponent<Image>().sprite = null;
                    UT2.transform.GetComponent<Image>().color = new Color32(15, 59, 49, 225);
                    IS.utility2SlotUsed = false;
                    Destroy(gameObject);

                }
        }
    }
}
// Make a second script and pull values for specific utils
