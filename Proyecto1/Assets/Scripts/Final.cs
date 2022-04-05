using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    private AudioSource finalNivel;

    private bool terminado = false;

    // Start is called before the first frame update
    private void Start()
    {
        finalNivel = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Personaje" && !terminado) {
            finalNivel.Play();
            terminado = true;
            Invoke("terminarNivel", 2f);
            
        }
    }

    private void terminarNivel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
