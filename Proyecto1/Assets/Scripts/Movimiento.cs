using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;

    [SerializeField] private float movimiento = 7f;
    [SerializeField] private float salto = 16f;

    [SerializeField] private LayerMask puedoSaltar;

    private enum mov { Quieto, Correr, Saltar, Caer};

    [SerializeField] private AudioSource saltar;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movimiento,rb.velocity.y);

        if (Input.GetButtonDown("Jump")&& EstaSuelo())
        {
            saltar.Play();
            rb.velocity = new Vector2(rb.velocity.x, salto);
        }

        UpdateAnimacion();
    }


    private void UpdateAnimacion() {

        mov estado;

        if (dirX > 0f)
        {
            sprite.flipX = false;
            estado = mov.Correr;
        }
        else if (dirX < 0f)
        {
            sprite.flipX = true;
            estado = mov.Correr;
        }
        else
        {
            estado = mov.Quieto;
        }

        if (rb.velocity.y > .1f) {
            estado = mov.Saltar;
        }
        else if (rb.velocity.y < -.1f) {
            estado = mov.Caer;
        }

        anim.SetInteger("Estado", (int)estado);
    }



    private bool EstaSuelo() {

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,0f, Vector2.down, .1f, puedoSaltar);

    }
}
