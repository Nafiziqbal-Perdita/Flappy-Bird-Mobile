using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class Pistol : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] AudioManager audioManager;//audio manager will be stored here

    [SerializeField] float shootingRange = 100f;
    [SerializeField] int damage = 1;
    [SerializeField] LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer.enabled = false;
    }
    void Update()
    {
        // Temporary PC shooting control
        if (Keyboard.current != null &&
            Keyboard.current.fKey.wasPressedThisFrame)
        {
            Shoot();
        }


        // MOBILE: Touch left half of screen
        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.wasPressedThisFrame)
            {
                Vector2 touchPosition = touch.position.ReadValue();

                if (touchPosition.x > Screen.width / 2f)//right half of the screen
                {
                    Shoot();
                }
            }
        }




    }




    void Shoot()
    {
        Debug.Log("FIRE!!!");

        RaycastHit2D hit = Physics2D.Raycast(
            firePoint.position,
            firePoint.right,
            shootingRange
        );

        Vector3 endPosition;

        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);

            endPosition = hit.point;

            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.takeDamage(damage);
                }
            }
        }
        else
        {
            endPosition =
                firePoint.position +
                firePoint.right * shootingRange;
        }

        StartCoroutine(ShowShot(endPosition));
    }

    IEnumerator ShowShot(Vector3 endPosition)
    {
        lineRenderer.enabled = true;
        audioManager.PlayGunShot();

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, endPosition);

        yield return new WaitForSeconds(0.03f);

        lineRenderer.enabled = false;
    }





}