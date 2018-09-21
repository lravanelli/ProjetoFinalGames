using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public float intervalo;
    public float yMover, velocidade;

    private Vector3 position;
    private float yFinal, yInicial;

    // Use this for initialization
    void Start () {
        yInicial = transform.position.y;
        yFinal = yInicial - yMover;
        position = transform.position;
        StartCoroutine(Animar());
    }

    IEnumerator Animar()
    {

        yield return new WaitForSeconds(intervalo);
        if (position.y != yFinal)
        {
            position = new Vector3(transform.position.x, yFinal, transform.position.z);
        }
        else
        {
            position = new Vector3(transform.position.x, yInicial, transform.position.z);
        }

        StartCoroutine(Animar());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, position, velocidade * Time.deltaTime);
    }
}
