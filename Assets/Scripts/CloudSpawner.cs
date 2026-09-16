using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
   
    [SerializeField] GameObject cloud;
    [SerializeField] float spawnRate = 3f;
    float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            cloudSpawner();
            timer = 0f;
        }

    }



    void cloudSpawner()
    {
        float minPoint = -5f;
        float maxPoint = 5f;
        float randomY = Random.Range(minPoint, maxPoint);

        Instantiate(cloud, new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);


    }
}
