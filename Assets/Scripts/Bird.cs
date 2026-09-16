using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public LogicManager logicManager;
    public Rigidbody2D birdRigidBody;

    [SerializeField] float flapStrength = 5f;

    bool isBirdAlive = true;

    void Start()
    {
        logicManager = GameObject
            .FindGameObjectWithTag("LogicManager")
            .GetComponent<LogicManager>();
    }

    void Update()
    {
        if (!isBirdAlive)
            return;

        // COMPUTER: Space
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            BirdMovement();
        }

        // MOBILE: Touch left half of screen
        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.wasPressedThisFrame)
            {
                Vector2 touchPosition = touch.position.ReadValue();

                if (touchPosition.x < Screen.width / 2f)
                {
                    BirdMovement();
                }
            }
        }

        // Bird went outside the playable area
        if (transform.position.y > 5f || transform.position.y < -6f)
        {
            GameOver();
        }
    }

    public void BirdMovement()
    {
        birdRigidBody.linearVelocityY = flapStrength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopPipe") ||
            collision.gameObject.CompareTag("BottomPipe"))
        {
            Debug.Log("Collision recorded");

            GameOver();
        }
    }

    private void GameOver()
    {
        if (!isBirdAlive)
            return;

        isBirdAlive = false;
        logicManager.gameOver();
    }
}