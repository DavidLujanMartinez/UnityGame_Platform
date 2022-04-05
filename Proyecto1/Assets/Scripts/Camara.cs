using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] private Transform pj;

    // Update is called once per frame
    private void Update()
    {
        this.transform.position = new Vector3(pj.position.x, pj.position.y, this.transform.position.z);
    }
}
