using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathEffect;
    [SerializeField] float enemyMoveSpeed = 2.5f;
    [SerializeField] float deadZone = -14f;
    [SerializeField] int enemyHealth = 1;
    public LogicManager logicManager;


    void Start()
    {
        logicManager=GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
    }

    void Update()
    {

        transform.position += Vector3.left * enemyMoveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }


    public void takeDamage(int damagePoint)
    {
        enemyHealth -= damagePoint;

        Debug.Log("Damage Recorded");
        if (enemyHealth <= 0)
        {
            killEnemy();
        }

    }

    public void killEnemy()
    {
        Debug.Log("Enemy Killed");
        logicManager.scoreIncrement(5);
        Instantiate(
      deathEffect,
      transform.position,
      Quaternion.identity
  );
        Destroy(gameObject);
    }




}
