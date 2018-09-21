using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float velocidade;
    public float impulso;
    public AudioClip audioPulo;
    public AudioClip audioQueda;
    public AudioClip audioCoin;
    public Transform sensorChao;
    public GameObject boss;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRender;
    private Animator animar;
    private bool pular;
    private float mover;
    private bool estaNoChao;

    private AudioSource som;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        animar = GetComponent<Animator>();
        som = GetComponent<AudioSource>();
    }

    void Update()
    {

        // Input 
        mover = Input.GetAxisRaw("Horizontal") * velocidade;

        // Orientacao
        if (mover > 0.0f)
        {
            spriteRender.flipX = false;
        }
        else if (mover < 0.0f)
        {
            spriteRender.flipX = true;
        }

        // Detectar o chao
        estaNoChao = Physics2D.Linecast(transform.position, sensorChao.position,
            1 << LayerMask.NameToLayer("Chao"));

        // Pulo
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            pular = true;
            som.clip = audioPulo;
            som.Play();
        }

        // Animacoes
        animar.SetFloat("pMover", Mathf.Abs(mover));
        animar.SetBool("pNoChao", estaNoChao);
    }

    void FixedUpdate()
    {
        // Mover
        rb2d.velocity = new Vector2(mover, rb2d.velocity.y);

        // Pulo
        if (pular)
        {
            rb2d.AddForce(Vector2.up * impulso);
            pular = false;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Chao")
        {
            som.clip = audioQueda;
            som.Play();
        }
        
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "Coin")
        {
            som.clip = audioCoin;
            som.Play();
        }
        if (c.gameObject.tag == "Boss")
        {
            boss.SetActive(true);
        }
    }
}
