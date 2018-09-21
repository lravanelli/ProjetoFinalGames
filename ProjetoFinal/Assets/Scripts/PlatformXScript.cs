using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformXScript : MonoBehaviour
{
    public GameObject alvo;
    public float intervalo;
    public float xMover, velocidade;

    private Vector3 position;
    private Vector3 positionPlayer;
    private float xFinal, xInicial;
    private bool emCima;

    // Use this for initialization
    void Start()
    {
        emCima = false;
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
            if (alvo != null && emCima)
            {
                positionPlayer = new Vector3(alvo.transform.position.x - xMover, alvo.transform.position.y, alvo.transform.position.z);
            }
            else if (alvo != null)
            {
                positionPlayer = alvo.transform.position;
            }
        }
        else
        {
            position = new Vector3(xInicial, transform.position.y, transform.position.z);
            if (alvo != null && emCima)
            {
                positionPlayer = new Vector3(alvo.transform.position.x + xMover, alvo.transform.position.y, alvo.transform.position.z);
            }
            else if (alvo != null)
            {
                positionPlayer = alvo.transform.position;
            }
        }

        StartCoroutine(Animar());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, position, velocidade * Time.deltaTime);
        if (alvo != null && emCima) {
            alvo.transform.position = Vector3.Lerp(alvo.transform.position, positionPlayer, velocidade * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            emCima = true;
            positionPlayer = alvo.transform.position;
        }

    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            emCima = false;
        }

    }
}