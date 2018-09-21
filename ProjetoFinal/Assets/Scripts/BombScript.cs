using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    public float intervalo;
    public float xMover, velocidade;
    public GameObject explosion;

    private Vector3 position;
    private float xFinal, xInicial;
    private bool posicaoInicialPlayer;
    private GameObject player;

    // Use this for initialization
    void Start () {
        xInicial = transform.position.x;
        xFinal = xInicial - xMover;
        position = transform.position;
        StartCoroutine(Animar());
    }

    IEnumerator Animar()
    {

        yield return new WaitForSeconds(intervalo);
        if (position.x != xFinal)
        {
            position = new Vector3(xFinal, transform.position.y, transform.position.z);
        }
        else
        {
            position = new Vector3(xInicial, transform.position.y, transform.position.z);
        }

        StartCoroutine(Animar());
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.Lerp(transform.position, position, velocidade * Time.deltaTime);
        if (posicaoInicialPlayer)
        {
            posicaoInicialPlayer = false;
            Vector3 pN = new Vector3(-3.77f, 0.53f, 0.0f);
            player.transform.position = pN;
            player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Player>().enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Instantiate(explosion, c.transform.position, c.transform.rotation);

        CoinsPoints.pointsLife--;
        if (CoinsPoints.pointsLife == 0)
        {
            Destroy(c.gameObject);
        }
        else
        {
            c.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            c.gameObject.GetComponent<Player>().enabled = false;
            player = c.gameObject;
            posicaoInicialPlayer = true;
        }

    }
}
