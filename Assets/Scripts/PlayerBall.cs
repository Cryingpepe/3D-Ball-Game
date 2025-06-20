using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{

    public float JumpPower;
    public int itemCount;
    public GM manager;
    private AudioSource audios;
    bool isJumping;
    private GameInput InputAction;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audios = GetComponent<AudioSource>();
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
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            itemCount++;
            audios.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            if (itemCount == manager.TotalItemCount)
            {
                SceneManager.LoadScene("Scene1" + (manager.stage + 1));
            }
            else
            {
                SceneManager.LoadScene("Scene1" + manager.stage);
            }
        }
    }
}
