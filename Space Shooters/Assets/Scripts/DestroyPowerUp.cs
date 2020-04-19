using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Pickup"))
        {
            return;
        }
        if (other.CompareTag("Bolt") || other.CompareTag("Pickup"))
        {
            return;
        }
        if (other.CompareTag("Enemy") || other.CompareTag("Pickup"))
        {
            return;
        }
        if (other.CompareTag("Boundary") || other.CompareTag("Fire"))
        {
            return;
        }
        if (other.CompareTag("Bolt") || other.CompareTag("Fire"))
        {
            return;
        }
        if (other.CompareTag("Enemy") || other.CompareTag("Fire"))
        {
            return;
        }
        if (other.CompareTag("Pickup") || other.CompareTag("Fire"))
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        gameController.AddScore(scoreValue);
    }
}
