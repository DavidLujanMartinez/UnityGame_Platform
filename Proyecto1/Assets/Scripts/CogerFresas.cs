using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CogerFresas : MonoBehaviour
{

    private int cont=0;
    [SerializeField] private Text TextoFresas;
    [SerializeField] private AudioSource coger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fresas")) {
            coger.Play();
            Destroy(collision.gameObject);
            cont++;
            TextoFresas.text = "Fresas : " + cont;
        }
    }
}
