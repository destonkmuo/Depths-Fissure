using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    public float Distance;
    public bool isAngered;
    public NavMeshAgent _agent;
    public HealthDisplay HD;
    public Animator anim;
    public bool Swing = false;
    public float _time = 2f;
    [System.NonSerialized] public float health = 100f;
    [System.NonSerialized] public float maxHealth = 100f;
    public Slider slider;
    public GameObject Chest;
    public ExpDisplay ED;
    public float expDropAmount;

    // Start is called before the first frame update
    void Start()
    {
        HD = HD.GetComponent<HealthDisplay>();
        ED = ED.GetComponent<ExpDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            GameObject chest = Instantiate(Chest, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            chest.SetActive(true);
            ED.currentExp += expDropAmount;
            Destroy(gameObject);
        }
        slider.value = health/maxHealth;
        Distance =  Vector3.Distance(Player.transform.position, this.transform.position);

        if(Distance < 15f && !Swing) {
            isAngered = true;
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isSwing", false);
        }
        if(Distance > 12f && !Swing) {
            isAngered = false;
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isSwing", false);
        }
        if(Distance < 2f) {
        if(_time > 0) {
             isAngered = false;
            _time -= Time.deltaTime;
        }
        if(_time < 0) {
            _time = 0;
        }
        if(_time == 0) {
            _time = 2f;
            Swing = true;
            anim.SetBool("isSwing", true);
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }
        }else {
            _agent.isStopped = false;
            Swing = false;
            anim.SetBool("isSwing", false);
            anim.SetBool("isIdle", true);
        }
        if(isAngered) {
            _agent.isStopped = false;
            _agent.SetDestination(Player.transform.position);

        }
        if(!isAngered) {
            _agent.isStopped = true;
        }
    }


}
