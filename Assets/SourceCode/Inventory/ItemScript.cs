using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    public string type;
    public string description;
    public bool stackable;
    public int ID;
    public Sprite icon;
    public bool pickedUp;
    public bool equipped;
    public float Damage;


    public void Update() {
        if(equipped)
        {
            //perform weapon acts here
        }
    }

    public void ItemUsage()
    {
        //Weapon

        if(type == "Weapon") {

            equipped = true;

        }
        // Magic
        // Health Item

        // beverage
    }



}
