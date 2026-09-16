using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;

    [SerializeField] float flapStrength = 5f;

    void Update()
    {
        // COMPUTER: Space key
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            BirdMovement();
        }

        // MOBILE: Touch the left half of the screen
        if (Touchscreen.current != null)    
        {
            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.wasPressedThisFrame)
            {
                Vector2 touchPosition = touch.position.ReadValue();

                // Check whether touch is on left half
                if (touchPosition.x < Screen.width / 2f)
                {
                    BirdMovement();
                }
            }
        }
    }

    public void BirdMovement()
    {
        birdRigidBody.linearVelocityY = flapStrength;
    }
}