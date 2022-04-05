using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorMorir : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource morirSonido;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinchos")) {
            muerte();
        }
    }

    private void muerte() {
        morirSonido.Play();
        anim.SetTrigger("Morir");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void riniciar() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
