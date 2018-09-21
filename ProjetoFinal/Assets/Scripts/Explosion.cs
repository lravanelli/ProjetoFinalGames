using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public AudioClip audioE;

    private AudioSource som;

    // Use this for initialization
    void Start () {
        som = GetComponent<AudioSource>();
        som.clip = audioE;
        som.Play();
        Destroy(gameObject, 0.8f);
	}
	
}
