using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

    
    public AudioClip audioC;

    private AudioSource som;
    private Animator animar;


    // Use this for initialization
    void Start () {
        animar = GetComponent<Animator>();
        som = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator RetirarSom() {
        yield return new WaitForSeconds(1.0F);
        som.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player") {

            animar.enabled = true;
            som.clip = audioC;
            som.Play();
            StartCoroutine(RetirarSom());
            CoinsPoints.pointsLife++;
            
        }
    }
}
