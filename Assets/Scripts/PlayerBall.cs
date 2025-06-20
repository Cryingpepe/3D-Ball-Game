using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBall : MonoBehaviour
{

    public float JumpPower;
    public int itemCount;
    bool isJumping;
    private GameInput InputAction;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        InputAction = new GameInput();
        InputAction.Enable();
        isJumping = false;
    }

    void Update()
    {
        if (InputAction.Player.Jump.triggered && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = InputAction.Player.Move.ReadValue<Vector2>().x;
        float v = InputAction.Player.Move.ReadValue<Vector2>().y;
        rb.AddForce(new Vector3(h, 0, v) * 1f, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            isJumping = false;
        }
    }
}
