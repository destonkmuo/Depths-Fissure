using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpDisplay : MonoBehaviour
{

    private float expMax = 100;
    private float currentExp = 0;
    public Slider slider;
    public float level = 0;
    public Text text;
    public SkillsAndLevels SL;

    void Start()
    {
        SL = SL.GetComponent<SkillsAndLevels>();
    }

    void Update() {
        void levelIncrease() {
            level += 1;
            SL.SkillPoints += 3;
            expMax = Mathf.Floor(1.3f * expMax);
            text.text = ""+level+"";
        }
        if (currentExp == expMax) {
            currentExp = 0;
            levelIncrease();
        }

        if (currentExp > expMax) {
            currentExp = currentExp - expMax;
            levelIncrease();
        }

        slider.value = currentExp / expMax;
    }
}
