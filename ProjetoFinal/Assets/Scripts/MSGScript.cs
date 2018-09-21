using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSGScript : MonoBehaviour {

    public Text texto;
    // Use this for initialization
    IEnumerator Start()
    {

        yield return new WaitForSeconds(1.0f);
        if (texto.text == "")
        {
            texto.text = "Tecle espaço para iniciar!";
        }
        else
        {
            texto.text = "";
        }

        StartCoroutine(Start());
    }

}
