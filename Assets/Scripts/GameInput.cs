using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    public Vector2 GetMovementVector()
    {
        if (playerInputActions == null)
        {
            Debug.LogError("playerInputActions не инициализирован!");
            return Vector2.zero;
        }
        return playerInputActions.Player.Move.ReadValue<Vector2>();
    }
}
