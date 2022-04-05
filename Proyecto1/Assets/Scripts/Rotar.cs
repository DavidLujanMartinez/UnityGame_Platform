using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    [SerializeField] private float velocidad= 1f;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, 360 * velocidad * Time.deltaTime);
    }
}
