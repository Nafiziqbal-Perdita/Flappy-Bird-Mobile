using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float pipeMoveSpeed = 3f;
    [SerializeField] float deadZone = -14f;

    void Update()
    {
      
        transform.position += Vector3.left * pipeMoveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}