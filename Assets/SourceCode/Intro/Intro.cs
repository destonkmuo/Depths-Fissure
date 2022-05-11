using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public AudioSource soundSource;
    public float whisperVolume;
    public GameObject player;
    // Start is called before the first frame update

    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        soundSource.Play();
    }

    void OnGUI()
    {
        whisperVolume = player.transform.position.z / 300;
        soundSource.volume = whisperVolume;
    }
}
