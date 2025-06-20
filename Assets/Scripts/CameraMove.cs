using UnityEngine;

public class CameraMove : MonoBehaviour
{

    Transform playerTransform;
    Vector3 offset;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
