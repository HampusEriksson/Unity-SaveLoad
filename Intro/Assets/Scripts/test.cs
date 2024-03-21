using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public int health = 100;
    public float speed = 5.0f;
    private bool isAlive = true;

    // Methods
    void Start()
    {
        Debug.Log("Player initialized.");
    }

    void Update()
    {
        if (isAlive)
        {
            Move();
        }
        else
        {
            Die();
        }
    }

    void Move()
    {
        // Code to move the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void Die()
    {
        // Code to handle player death
        Debug.Log("Player has died.");
        // Optionally: Respawn logic, game over screen, etc.
    }

    // Example of a public method that can be called from other scripts
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            isAlive = false;
        }
    }
}