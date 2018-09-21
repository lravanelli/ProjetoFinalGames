using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public float impulso;
    public float intervalo;
    public float mover;
    public float velocidade;
    public GameObject explosion;
    public AudioClip[] audios;

    private Animator animator;
    private bool pular;
    private Rigidbody2D rb2d;
    private float percent;
    private GameObject player;
    private AudioSource som;
    
    // Use this for initialization
    void Start()
    {
        pular = false;
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        StartCoroutine(Animar());
        som = GetComponent<AudioSource>();
    }


    IEnumerator Animar()
    {

        yield return new WaitForSeconds(intervalo);
        if (CoinsPoints.lifeBoss > 0)
        {
            percent = Random.Range(0.0f, 100.0F);
            if (percent <= 40.0f)
            {
                animator.SetTrigger("skill_1");
                if (player.transform.position.x >= 108.0f)
                {
                    StartCoroutine(LessPoints());
                }
                som.clip = audios[1];
                som.Play();
            }

            if (percent > 40.0f && percent <= 70.0f)
            {
                animator.SetTrigger("skill_2");
                if (player.transform.position.x >= 111.0f)
                {
                    StartCoroutine(LessPoints());
                }
                som.clip = audios[0];
                som.Play();
            }

            /*if (percent > 70.0f && percent <= 80.0f)
            {
                animator.SetTrigger("skill_3");
            }*/

            if (percent > 70.0f && percent <= 90.0f)
            {
                animator.SetTrigger("idle_2");
                som.clip = audios[0];
                som.Play();
            }

            if (percent > 90.0f && percent <= 100.0f)
            {
                animator.SetTrigger("evade_1");
            }
        }
        //animator.SetTrigger("hit_2");
        //animator.SetTrigger("death");
        
        //animator.SetTrigger("idle_2");
        StartCoroutine(Animar());
    }

    IEnumerator LessPoints()
    {
        yield return new WaitForSeconds(0.8f);
        CoinsPoints.pointsLife--;
        if(CoinsPoints.pointsLife <= 0)
        {
            Destroy(player);
        }
        else
        {
            player.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<SpriteRenderer>().enabled = true;
        }
        

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            rb2d = c.gameObject.GetComponent<Rigidbody2D>();
            
            pular = true;
            CoinsPoints.lifeBoss--;

            if (CoinsPoints.lifeBoss <= 0)
            {
                
                animator.SetTrigger("hit_2");
                animator.SetTrigger("death");
                som.clip = audios[2];
                som.Play();
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                animator.SetTrigger("idle_2");
                som.clip = audios[0];
                som.Play();
            }
            
        }

    }

    void FixedUpdate()
    {
        // Pulo
        if (pular)
        {
            rb2d.velocity = new Vector2(mover * velocidade, rb2d.velocity.y);
            rb2d.AddForce(Vector2.up * impulso);
            
            pular = false;
        }
    }
}
