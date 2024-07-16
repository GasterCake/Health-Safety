using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    private bool grounded;
    private float horizontalInput;
    public GameObject manager;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 10;
        grounded = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput*speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            rb.velocity= new Vector2(rb.velocity.x, speed);
            grounded = false;
        }
        if (horizontalInput > 0) { transform.localScale = new Vector3(1, 1, 1); }
        else if (horizontalInput < 0) { transform.localScale = new Vector3(-1, 1, 1); }
        //Debug.Log(grounded);
        anim.SetBool("Walking", horizontalInput != 0);
        anim.SetBool("Grounded", grounded);

        if (transform.position.y < -10) {
            manager.GetComponent<Manager>().Restart();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flag") {
            manager.GetComponent<Manager>().Win();
        }
    }


}
