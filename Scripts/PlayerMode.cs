using UnityEngine;
//1.WallJump
//2.Dash
//3.Pickaxe

public class PlayerMode : MonoBehaviour
{
    public float Mode=0;
    public PlayerMovement pm;
    public BoxCollider2D bc;

    void Start()
    {
        Mode = PlayerPrefs.GetFloat("PlayerMode", 0);
    }

    void Update()
    {
        if (Mode == 1)
        {
            bc.sharedMaterial.friction = 0.2f;
            pm.CurrentSprite.sprite = pm.WallJumpSprite;
        }
        if (Mode==2)
        {
            bc.sharedMaterial.friction = 0f;
            pm.CurrentSprite.sprite = pm.DashSprite;
        }
        if (Mode==3)
        {
            bc.sharedMaterial.friction = 0f;
            pm.CurrentSprite.sprite = pm.PickaxeSprite;
        }
    }
}
