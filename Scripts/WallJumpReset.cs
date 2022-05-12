using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpReset : MonoBehaviour
{
    public CharacterController2D controller;
    public float WJF = 500f;
    public PlayerMode pmode;

    void OnTriggerEnter2D()
    {
        if (pmode.Mode == 1)
        {
            controller.WallGrounded = true;
            if (controller.FacingRight)
            {
                controller.WallJumpForce = -WJF;
            }
            else controller.WallJumpForce = WJF;
        }
    }

    void OnTriggerExit2D()
    {
        controller.WallJumpForce = 0f;
        controller.WallGrounded = false;
    }
}
