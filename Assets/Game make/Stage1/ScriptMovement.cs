using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private ScriptCheck scriptCheck;
    private ScriptAnimation scriptAnimation;

    public int speed;
    public int jumpForce;
    //public int downForce;

    public float moveX;


    // Start is called before the first frame update

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        scriptAnimation = GetComponent<ScriptAnimation>();
        scriptCheck = GetComponent<ScriptCheck>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        transform.Translate(moveX * speed * Time.deltaTime, 0, 0);// Di chuyển sang trái và phải

        // di chuyển quay sang trái và phải
        if (moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }


        if (scriptAnimation.state == ScriptAnimation.PlayerState.Idle && Input.GetKeyDown(KeyCode.UpArrow)) //ẩn lên là nhảy lên
            rigidBody2D.velocity = Vector2.up * jumpForce;
        //Debug.Log(Isgrounded);

        /*if (scriptAnimation.state == 3 && Input.GetKeyDown(KeyCode.DownArrow)) // ấn xuống là trôi xuống
            Rb.velocity = Vector2.down * DownForce;*/





    }


}
