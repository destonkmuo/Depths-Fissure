using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class HealthDisplay : MonoBehaviour {

  public Image HealthBarIndicator;
  public GameObject deathScreen;
  public GameObject player;
  public PlayerController PC;
  public AudioSource source;
  public AudioClip clip;
  public AudioSource IntenseMusic;
  public VideoPlayer CalmMusic;
  // Start is called before the first frame update
  void Start() {
    PC = PC.GetComponent<PlayerController>();
   }

  // Update is called once per frame

  public float health = 100f;
  public float healthMax = 100f;
  public float _time = 5;
  void Update()
  {
    if (health < 0) {
      health = 0;
    }
    if (health > healthMax) {
      health = healthMax;
    }
    if (health > 0) {
      healthChecker();
    }
    if(health == 0) {
      deathScreen.SetActive(true);
      PC.movementEnable1 = false;
        if(_time == 5) {
          source.PlayOneShot(clip);
        }
        if(_time > 0) {
            _time -= Time.deltaTime;
        }
        if(_time < 0) {
            _time = 0;
        }
        if(_time == 0) {
            health = healthMax;
            deathScreen.SetActive(false);
            _time = 5;
            PC.movementEnable1 = true;
            player.transform.position = PC.spawnLocation;
        }
    }
  }

  public bool healthUp = true;
  public bool healthDown = false;
  float healthTime = 1f;
  public Camera MainCamera;
  public RawImage blur;
  public GameObject Blur;
  void healthChecker()
  {
    float x = health/healthMax;
    Debug.Log(health);
    HealthBarIndicator.transform.localScale = new Vector3(x, 1, 0);
    if (x <= .5f) {
      CalmMusic.SetDirectAudioVolume(0, 0f);
      IntenseMusic.volume = 1f;
      Blur.SetActive(true);
      blur.canvasRenderer.SetAlpha(1f - x * 3);
      if (healthTime > 0 && healthUp == true) {
        healthTime -= Time.deltaTime;
      }
      if (healthTime > 0 && healthUp == true) {
        MainCamera.transform.position = MainCamera.transform.position + new Vector3(.0025f / x, .0025f / x, 0);
      }
      if (healthTime < 0 && healthUp == true) {
        healthUp = false;
        healthDown = true;
        healthTime = .05f;
      }

      if (healthTime > 0f && healthDown == true) {
        healthTime -= Time.deltaTime;
      }
      if (healthTime > 0 && healthDown == true) {
        MainCamera.transform.position = MainCamera.transform.position - new Vector3(.0025f / x, .0025f / x, 0);
      }
      if (healthTime < 0 && healthDown == true) {
        healthUp = true;
        healthDown = false;
        healthTime = .05f;
      }
    } else if (x > .5f) {
      CalmMusic.SetDirectAudioVolume(0, 1f);
      IntenseMusic.volume = 0f;
      Blur.SetActive(false);
      blur.canvasRenderer.SetAlpha(0);
    }
  }
}
