using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private const string IS_WALKING = "isWalking";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        animator.SetBool(IS_WALKING, PlayerController.Instance.IsWalkingmetod());
        AdjustPlayerFacingDirection();
    }


    private void AdjustPlayerFacingDirection()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        Vector3 playerPosition = PlayerController.Instance.GetPlayerScreenPosition();

        if (0 > inputVector.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
