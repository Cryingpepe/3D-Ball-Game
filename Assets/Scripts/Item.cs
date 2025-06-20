using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.back, speed * Time.deltaTime);
    }

}
