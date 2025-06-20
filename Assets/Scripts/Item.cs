using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.back, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            PlayerBall playerBall = other.GetComponent<PlayerBall>();
            playerBall.itemCount++;
            gameObject.SetActive(false);
        }
    }
}
