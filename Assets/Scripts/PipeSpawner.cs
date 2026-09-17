using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    [SerializeField] GameObject pipe;
    [SerializeField] float spawnRate = 3f;
    float timer = 0f;
    float heightOffset = 4f;

    void Start()
    {
        pipeSpawner();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            pipeSpawner();
            timer = 0f;
        }

    }



    void pipeSpawner()
    {
        float minPoint = transform.position.y - heightOffset;
        float maxPoint = transform.position.y + heightOffset;
        float randomY = Random.Range(minPoint, maxPoint);

        Instantiate(pipe, new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);


    }



}
