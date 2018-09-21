using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraS : MonoBehaviour {

    public GameObject alvo;
    public float limiteX, limiteY, velocidade;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(alvo != null) { 

        float dist = Vector2.Distance(alvo.transform.position, transform.position);

        if (dist > limiteX || dist > limiteY)
        {
            float x;
            float y;

            if (alvo.transform.position.x - limiteX < 0)
            {
                x = 0.0f;
            }
            else
            {
                x = alvo.transform.position.x;
                if (x > 107.4f)
                {
                  x = 107.4f;
                }

            }

            if (alvo.transform.position.y - limiteY < 0)
            {
                y = 0.0f;
            }
            else
            {
                y = alvo.transform.position.y;
                if (y > 6.3f)
                {
                    y = 6.3f;
                }
             }


            Vector3 pN = new Vector3(x, y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, pN, velocidade * Time.deltaTime);
         
            
        }
        }
    }
}
