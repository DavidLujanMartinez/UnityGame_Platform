using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPuntos : MonoBehaviour
{
    [SerializeField] private GameObject[] puntos;
    private int posicion = 0;

    [SerializeField] private float velocidad = 2f;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(puntos[posicion].transform.position, transform.position) < .1f) {
            posicion++;
            if (posicion >= puntos.Length) {
                posicion = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, puntos[posicion].transform.position, Time.deltaTime * velocidad);
    }
}
