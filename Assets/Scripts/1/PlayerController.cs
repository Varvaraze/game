using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private float movingSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    private float minMovingSpeed = 0.1f;
    private bool isWalking = false;
    
   


    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        

        animator = transform.Find("PlayerVisual")?.GetComponent<Animator>();  

       
        if (animator == null)
        {
            Debug.LogError("Animator not found in PlayerVisual. Please ensure Animator is attached to PlayerVisual.");
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (GameInput.Instance != null)
        {
            Vector2 inputVector = GameInput.Instance.GetMovementVector();
            inputVector = new Vector2(inputVector.x, 0).normalized; 
            //Debug.Log(inputVector);

            rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

            isWalking = Mathf.Abs(inputVector.x) > minMovingSpeed;

           
            if (animator != null)
            {
                animator.SetBool("isWalking", isWalking);
            }
          
        }
        else
        {
            Debug.LogError("GameInput.Instance is null! Please make sure GameInput is initialized.");
        }
    }

    public bool IsWalkingmetod()
    {
        return isWalking;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }


}
