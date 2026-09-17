using UnityEngine;

public class HitImpact : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  [SerializeField] float destroyTime = 1f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
