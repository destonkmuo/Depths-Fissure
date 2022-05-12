using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsAndLevels : MonoBehaviour
{

    public Text lvl;
    public Text agi;
    public int agiVal = 0;
    public Text fort;
    public int forVal = 0;
    public Text str;
    public int strVal = 0;
    public Text sp;
    public int SkillPoints = 0;

    public ExpDisplay ED;

    void Start()
    {
        ED = ED.GetComponent<ExpDisplay>();
    }
    void Update() 
    {

        lvl.text = "LEVEL : " +ED.level+"";
        agi.text = "AGILITY : " +agiVal+"";
        fort.text = "FORTITUDE : " +forVal+"";
        str.text = "STRENGTH : " +strVal+"";
        sp.text = "SKILL POINTS : " +SkillPoints+"";
    }

}
