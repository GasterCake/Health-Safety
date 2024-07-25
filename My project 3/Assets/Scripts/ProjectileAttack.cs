using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public GameObject Manager;
    public GameObject Attack;
    public GameObject Player;
    public bool Alive;
    [SerializeField] public float movementspeed;
    // Start is called before the first frame update
    void Start()
    {
        movementspeed = 3;
        Attack = this;
        Alive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive == true)
        {
            
        }
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Manager.GetComponent<Manager>().BossRoom)
        {
            Alive = true;



        }
    }
    public void Shoot()
    {
        for (int i = 0; i < 10; i++)
        {
            //float xVelocity = GetComponent<Rigidbody2D>().velocity.x * movementspeed;
            //float yVelocity = GetComponent<Rigidbody2D>().velocity.y;
            //Alive = true;
            //xVelocity = xVelocity + 20;
            //transform.localPosition = new Vector2(xVelocity, yVelocity);
            transform.localPosition += new Vector3(10, 0, 0);
        }
    }

}
