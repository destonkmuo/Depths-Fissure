using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillsButtons : MonoBehaviour, IPointerClickHandler
{
    public SkillsAndLevels SL;

    void Start() {
        SL = SL.GetComponent<SkillsAndLevels>();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {

        if(transform.tag == "agility") {
            if(SL.SkillPoints > 0) {
                SL.SkillPoints -= 1; 
                SL.agiVal += 1;
                }
        }
        if(transform.tag == "fortitude") {
            if(SL.SkillPoints > 0) { 
                SL.SkillPoints -= 1; 
                SL.forVal += 1;
                }
        }
        if(transform.tag == "strength") {
            if(SL.SkillPoints > 0) { 
                SL.SkillPoints -= 1; 
                SL.strVal += 1;
                }
        }
        if(transform.tag == "intellect") {
            if(SL.SkillPoints > 0) { 
                SL.SkillPoints -= 1; 
                SL.inteVal += 1;
                }
        }
        if(transform.tag == "volition") {
            if(SL.SkillPoints > 0) { 
                SL.SkillPoints -= 1; 
                SL.voiVal += 1;
                }
        }
    }
}
