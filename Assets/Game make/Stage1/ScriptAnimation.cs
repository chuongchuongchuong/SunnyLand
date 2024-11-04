using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
    private Animator anim;
    private ScriptMovement scriptMovement;
    private ScriptCheck scriptCheck;

    void Awake()
    {
        anim = GetComponent<Animator>();
        scriptMovement = GetComponent<ScriptMovement>();
        scriptCheck = GetComponent<ScriptCheck>();
    }

    public enum PlayerState
    {
        Idle,
        isRunning,
        isCrouching,
        isJumpingUp,
        isFallingDown,
    }

    public PlayerState state;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case PlayerState.Idle:
                if (scriptMovement.moveX != 0) // đang đứng yên xong di chuyển
                    state = PlayerState.isRunning;

                if (Input.GetKeyDown(KeyCode.DownArrow)) // đang đứng yên xong ngồi
                    state = PlayerState.isCrouching;

                if (Input.GetKeyDown(KeyCode.UpArrow)) // đang đứng yên xong nhảy lên
                    state = PlayerState.isJumpingUp;

                break;

            case PlayerState.isRunning:
                if (scriptMovement.moveX == 0) // đang chạy xong đứng im
                    state = PlayerState.Idle;
                if (Input.GetKeyDown(KeyCode.UpArrow)) // đang chạy xong nhảy lên
                    state = PlayerState.isJumpingUp;
                if (scriptCheck.isFalling)
                    state = PlayerState.isFallingDown;

                break;

            case PlayerState.isCrouching:
                if (Input.GetKeyDown(KeyCode.UpArrow)) // đang cúi xong đứng lên
                    state = PlayerState.Idle;
                if (scriptCheck.isFalling)
                    state = PlayerState.isFallingDown;

                break;
            case PlayerState.isJumpingUp:
                if (scriptCheck.isFalling)
                    state = PlayerState.isFallingDown;

                break;

            case PlayerState.isFallingDown:
                if (!scriptCheck.isFalling)
                    state = PlayerState.Idle;

                break;
        }

        PlayerStateUpdate();
    }

    void PlayerStateUpdate()
    {
        switch (state)
        {
            case PlayerState.Idle:
                anim.SetInteger("state", 0); break;
            case PlayerState.isRunning:
                anim.SetInteger("state", 1); break;
            case PlayerState.isCrouching:
                anim.SetInteger("state", 2); break;
            case PlayerState.isJumpingUp:
                anim.SetInteger("state", 3); break;
            case PlayerState.isFallingDown:
                anim.SetInteger("state", 4); break;
        }
    }

}