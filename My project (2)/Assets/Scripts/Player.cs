using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//I was here

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed;
    public bool grounded;
    private float horizontalInput;
    public GameObject manager;
    private Animator anim;
    public int Health;
    public GameObject Attack1;
    public GameObject Attack2;
    public GameObject Attack3;
    private int Entered;
    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 10;
        grounded = false;
        Health = 100;
        Entered = 0;
        // BossRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            SoundManger.instance.PlaySound(jumpSound);
            grounded = false;

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            grounded = false;

        }
        if (Health <= 0)
        {
            manager.GetComponent<Manager>().Restart();
        }
        if (horizontalInput > 0) { transform.localScale = new Vector3(5, 5, 1); }
        else if (horizontalInput < 0) { transform.localScale = new Vector3(-5, 5, 1); }
        //Debug.Log(grounded);
        anim.SetBool("Walking", horizontalInput != 0);
        anim.SetBool("Grounded", grounded);
        if (transform.position.y < -10)
        {
            manager.GetComponent<Manager>().Restart();
        }
    }
    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            manager.GetComponent<Manager>().Win();
        }
        if (collision.gameObject.tag == "BossRoom" && Entered == 0)
        {
            manager.GetComponent<Manager>().BossRoom = true;
            Entered = Entered + 1;
            //Debug.Log(BossRoom);

        }
        if (collision.gameObject.tag == "Damage")
        {
            Health = Health - 100;
        }
        if (Entered >= 1)
        {
            manager.GetComponent<Manager>().BossRoom = true;
        }
        if (collision.gameObject.tag == "BossRoom")
        {
            manager.GetComponent<Manager>().BossRoom = true;
            Attack1.GetComponent<ProjectileAttack>().Shoot();
            Attack2.GetComponent<ProjectileAttack>().Shoot();
            Attack3.GetComponent<ProjectileAttack>().Shoot();

        }
        if (collision.gameObject.tag == "Flag")
        {
            manager.GetComponent<Manager>().Win();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {


    }

}
