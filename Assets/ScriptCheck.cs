using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCheck : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isGrounded;
    public bool isFalling;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            isGrounded = false;
    }
    private void Update()
    {
        if (rb.velocity.y < -.1)
            isFalling = true;
        else
            isFalling = false;
    }

}
