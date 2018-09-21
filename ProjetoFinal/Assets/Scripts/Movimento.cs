using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimento : MonoBehaviour {

    public float limiteX;
    public float retornarX;
    public float velocidade;

    
    void Update()
    {
        if (transform.position.x < limiteX)
        {
            transform.position = new Vector3(retornarX,
            transform.position.y, 0.0f);
        }

        transform.Translate(Vector3.left * velocidade * Time.deltaTime);

    }



}
