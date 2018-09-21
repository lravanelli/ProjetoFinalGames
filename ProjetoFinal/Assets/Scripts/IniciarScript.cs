using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarScript : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Iniciar(0.5f));
        }
    }

    IEnumerator Iniciar(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("GameScene");
    }
}
