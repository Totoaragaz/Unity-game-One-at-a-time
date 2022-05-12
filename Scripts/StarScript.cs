using UnityEngine;

public class StarScript : MonoBehaviour
{
    public Transform Player;
    public Transform Star;
    public SpriteRenderer WallJumpChoice;
    public SpriteRenderer DashChoice;
    public SpriteRenderer PickaxeChoice;
    public BoxCollider2D WallJumpBox;
    public BoxCollider2D DashBox;
    public BoxCollider2D PickaxeBox;
    public BoxCollider2D PlayerBox;
    public Rigidbody2D PlayerRigidbody;
    public bool StarChoice=false;
    public bool ChoiceMade = false;

    bool Position()
    {
        if (Mathf.Abs(Player.position.x - Star.position.x) < 1 && Mathf.Abs(Player.position.y - Star.position.y) < 0.5) return true;
        else return false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Crouch") && Position())
        {
            FindObjectOfType<AudioManager>().Play("ClickSound");
            PlayerFreeze();
            StarChoice=true;
            WallJumpChoice.enabled = true;
            DashChoice.enabled = true;
            PickaxeChoice.enabled = true;
            WallJumpBox.enabled = true;
            DashBox.enabled = true;
            PickaxeBox.enabled = true;
        }
    }

    void FixedUpdate()
    {
        if (ChoiceMade)
        {
            WallJumpChoice.enabled = false;
            DashChoice.enabled = false;
            PickaxeChoice.enabled = false;
            WallJumpBox.enabled = false;
            DashBox.enabled = false;
            PickaxeBox.enabled = false;
            PlayerUnfreeze();
            StarChoice = false;
            ChoiceMade = false;
        }
    }

    void PlayerFreeze()
    {
        PlayerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        PlayerBox.enabled = false;
    }

    void PlayerUnfreeze()
    {
        PlayerBox.enabled = true;
        PlayerRigidbody.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        PlayerRigidbody.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }
}
