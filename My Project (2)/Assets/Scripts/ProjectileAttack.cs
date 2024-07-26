using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public GameObject Manager;
    public GameObject Player;
    public bool Alive;
    [SerializeField] public float movementspeed;
    // Start is called before the first frame update
    void Start()
    {
        movementspeed = 3;
        Alive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.GetComponent<Manager>().BossRoom)
        {
            Alive = true;
        }
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BossWall")
        {
            transform.localPosition += new Vector3(-0.01f, 10, 0);
            Alive = false;
        }
    }
    public void Shoot()
    {
        StartCoroutine(ShootWithDelay());
    }

    private IEnumerator ShootWithDelay()
    {
        int i = 0;
        while (i < 100 && Alive)
        {
            // Perform the transformation
            transform.localPosition += new Vector3(-0.01f, 0, 0);
            // Wait for 0.1 seconds before continuing to the next iteration
            i++;
            yield return new WaitForSeconds(0.1f);
        }

    }

}
