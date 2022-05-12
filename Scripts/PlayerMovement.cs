using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public SpriteRenderer CurrentSprite;
    public Sprite WallJumpSprite;
    public Sprite DashSprite;
    public Sprite PickaxeSprite;
    public Vector2 Force;
    public PlayerMode pmode;
    private bool cooldown=false;

    void Update()
    {
        horizontalMove=Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }


        if (Input.GetKey("space"))
        {
            if (pmode.Mode == 2 && cooldown==false)
            {
                cooldown = true;
                Freezey();
                FindObjectOfType<AudioManager>().Play("DashSound");
                if (controller.FacingRight)
                    rb.AddForce(Force);
                else rb.AddForce(-Force);
                Invoke("DashCooldown", 1f);
                
            }
        }
    }

    void Freezey()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        Invoke("Unfreeze", 0.3f);
    }

    void Unfreeze()
    {
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }

    void DashCooldown()
    {
        cooldown = false;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void LevelEnter(Vector2 EnterForce)
    {
        rb.AddForce(EnterForce);
    }
}
