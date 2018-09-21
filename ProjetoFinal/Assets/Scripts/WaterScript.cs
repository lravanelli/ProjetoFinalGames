using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

    public GameObject explosion;
    private bool posicaoInicialPlayer;
    private GameObject player;

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

    void Update()
    {
        if (posicaoInicialPlayer)
        {
            posicaoInicialPlayer = false;
            Vector3 pN = new Vector3(-3.77f, 0.53f, 0.0f);
            player.transform.position = pN;
            player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Player>().enabled = true;
        }
    }
}
