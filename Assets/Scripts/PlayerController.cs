using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health;
    public TMP_Text scoreText, healthText;
    private int score;
    [SerializeField] Rigidbody rb;
    [SerializeField] int StartHealth = 5;
    Vector3 dir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
        score = 0;
        health = StartHealth;
        SetScoreText();
        SetHealthText();

    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir = dir.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (dir * Time.fixedDeltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        HandlePickup(other);
        HandleTrap(other);
        HandleGoal(other);

    }

    private void HandlePickup(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
    }

    private void HandleTrap(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
            if(health <= 0)
            {
                Debug.Log("Game Over!");
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                return;
            }
        }
    }

    private void HandleGoal(Collider other)
    {
        if (!other.gameObject.CompareTag("Goal"))
            return;
        Debug.Log("You win!");
    }

    void SetScoreText()
    {
        if (scoreText == null)
        {
            Debug.Log("Score: " + score);
            return;
        }
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        if(healthText == null)
        {
            Debug.Log("Health: " + health);
        }
        
    }
}
