using System.Diagnostics;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Virtual function to be overridden by child classes
    public virtual void Collected()
    {
        Debug.Log("Collectible collected!");
    }
}

public class SpeedBoostCollectible : Collectible
{
    public override void Collected()
    {
        // Access the player's FirstPersonController component
        StarterAssets.FirstPersonController playerController = GetComponent<StarterAssets.FirstPersonController>();

        // Increase movement speed
        playerController.movementSettings.ForwardSpeed += 2f;
        playerController.movementSettings.BackwardSpeed += 2f;
        playerController.movementSettings.StrafeSpeed += 2f;

        Debug.Log("Speed boost collected!");
    }
}

public class JumpBoostCollectible : Collectible
{
    public override void Collected()
    {
        // Access the player's FirstPersonController component
        StarterAssets.FirstPersonController playerController = GetComponent<StarterAssets.FirstPersonController>();

        // Increase jump height
        playerController.m_JumpForce += 5f;

        Debug.Log("Jump boost collected!");
    }
}