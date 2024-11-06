using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
    private Animator anim;
    private ScriptMovement scriptMovement;
    private ScriptCheck scriptCheck;
    public int state;

    void Awake()
    {
        anim = GetComponent<Animator>();
        scriptMovement = GetComponent<ScriptMovement>();
        scriptCheck = GetComponent<ScriptCheck>();
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                if (scriptMovement.moveX != 0) // đang đứng yên xong di chuyển
                    state = 1;

                if (Input.GetKeyDown(KeyCode.DownArrow)) // đang đứng yên xong ngồi
                    state = 2;

                if (Input.GetKeyDown(KeyCode.UpArrow)) // đang đứng yên xong nhảy lên
                    state = 3;

                break;

            case 1:
                if (scriptMovement.moveX == 0) // đang chạy xong đứng im
                    state = 0;
                if (Input.GetKeyDown(KeyCode.UpArrow)) // đang chạy xong nhảy lên
                    state = 3;
                if (scriptCheck.isFalling)
                    state = 4;

                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.UpArrow)) // đang cúi xong đứng lên
                    state = 0;
                if (scriptCheck.isFalling)
                    state = 4;

                break;
            case 3:
                if (scriptCheck.isFalling)
                    state = 4;

                break;

            case 4:
                if (!scriptCheck.isFalling)
                    state = 0;

                break;
        }


        anim.SetInteger("state", state);

    }
}