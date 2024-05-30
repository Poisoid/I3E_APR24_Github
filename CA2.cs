using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
    // Player properties
    public TextMeshProUGUI scoreText;
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    private int currentScore = 0;

    void Start()
    {
        // Initialization code if needed
    }

    void Update()
    {
        // Player update logic if needed
    }

    public void IncreaseScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString();
    }

    public void IncreaseSpeed(float amount)
    {
        moveSpeed += amount;
        Debug.Log("Player speed increased to " + moveSpeed);
    }

    public void IncreaseJumpHeight(float amount)
    {
        jumpHeight += amount;
        Debug.Log("Player jump height increased to " + jumpHeight);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectible collectible = other.GetComponent<Collectible>();
        if (collectible != null)
        {
            collectible.Collected(this);
            Destroy(collectible.gameObject); // Optionally destroy the collectible after collection
        }
    }
}

public class Collectible : MonoBehaviour
{
    // Virtual function to handle collection
    public virtual void Collected(PlayerController player)
    {
        // Default implementation (if any)
    }
}

public class SpeedBoost : Collectible
{
    public float speedIncrease = 2f;

    // Override the Collected method to increase the player's speed
    public override void Collected(PlayerController player)
    {
        player.IncreaseSpeed(speedIncrease);
        Debug.Log("Collected SpeedBoost and gained a speed boost of " + speedIncrease + "!");
    }
}

public class JumpBoost : Collectible
{
    public float jumpHeightIncrease = 2f;

    // Override the Collected method to increase the player's jump height
    public override void Collected(PlayerController player)
    {
        player.IncreaseJumpHeight(jumpHeightIncrease);
        Debug.Log("Collected JumpBoost and gained a jump height boost of " + jumpHeightIncrease + "!");
    }
}
