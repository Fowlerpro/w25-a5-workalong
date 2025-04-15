using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float thrust = 3;
    [SerializeField] private float rotationSpeed = 360;
    [SerializeField] private float maxVelocity = 15;
    [SerializeField] private float bulletSpeed = 3;
    [SerializeField] private float bulletLifetime = 1;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private KeyCode left = KeyCode.LeftArrow;
    [SerializeField] private KeyCode right = KeyCode.RightArrow;
    [SerializeField] private KeyCode forward = KeyCode.W;
    [SerializeField] private KeyCode backward = KeyCode.S;
    [SerializeField] private KeyCode fire = KeyCode.Space;
    [SerializeField] private KeyCode stop = KeyCode.G;


    private void Update()
    {
        // Spawn bullet on mouse click
        //int leftClickID = 0;
        if (Input.GetKeyDown(fire))
        {
            // Bullet transform information when spawned
            Vector3 pos = transform.position + transform.up;
            Quaternion rot = Quaternion.identity;

            // Create a clone of bullet object
            GameObject bullet = Instantiate(bulletPrefab, pos, rot);
            Rigidbody2D bulletRB2D = bullet.GetComponent<Rigidbody2D>();

            // Shoot bullet in facing direction
            Vector2 force = transform.up * bulletSpeed;
            bulletRB2D.AddForce(force, ForceMode2D.Impulse);

            // Destroy bullet after this much time
            Destroy(bullet, bulletLifetime);
        }
    }

    // Update is called once per physics frame
    void FixedUpdate()
    {
        // Forcibly rotate player when using left-right inputs
        if (Input.GetKey(left))
        {
            float rotationAngle = rotationSpeed * Time.deltaTime;
            rb2d.MoveRotation(rotationAngle + transform.rotation.eulerAngles.z);
        }
        if (Input.GetKey(right))
        {
            float rotationAngle = -rotationSpeed * Time.deltaTime;
            rb2d.MoveRotation(rotationAngle + transform.rotation.eulerAngles.z);
        }

        // Add force to player
        if (Input.GetKey(forward))
        {
            // Cap movement speed
            bool canApplyVelocity = rb2d.linearVelocity.magnitude < maxVelocity;
            if (canApplyVelocity)
            {
                Vector2 thrustForce = transform.up * thrust;
                rb2d.AddForce(thrustForce);
            }
        }
        if (Input.GetKey(backward))
        {
            // Cap movement speed
            bool canApplyVelocity = rb2d.linearVelocity.magnitude < maxVelocity;
            if (canApplyVelocity)
            {
                Vector2 thrustForce = -transform.up * thrust;
                rb2d.AddForce(thrustForce);
            }
        }
        if (Input.GetKey(stop))
        {
            float rotationAngle = 0;
            rb2d.MoveRotation(rotationAngle);
            Vector2 thrustForce = transform.up * 0;
            rb2d.AddForce(thrustForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //Asteroid asteroid = collider2D.GetComponent<Asteroid>();
        //if (asteroid == null)
        //    return;

        // Don't run code past this check if not an asteroid
        bool isAsteroid = collider2D.gameObject.CompareTag("Asteroid");
        if (!isAsteroid)
            return;

        // Lose a life, handle case when lives run out
        //gameManager.RemoveLife();
        if (gameManager.IsGameOver())
        {
            // Destroy player -- code stops running after this!
            Destroy(this.gameObject);
        }

        // Reset player position
        rb2d.MovePosition(Vector2.zero);

        // Reset asteroids...
    }
}
