using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    AudioSource audioSource;
    Rigidbody2D rb2D;
    float x;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        rb2D.velocity = new Vector2(x, rb2D.velocity.y);
        if (rb2D.velocity.x != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
