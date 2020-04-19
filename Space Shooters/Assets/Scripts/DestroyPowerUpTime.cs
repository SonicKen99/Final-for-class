using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUpTime : MonoBehaviour
{
    public int scoreValue;
    private TimeAttack timeAttack;

    private void Start()
    {

        GameObject timeAttackObject = GameObject.FindWithTag("GameController");
        if (timeAttackObject != null)
        {
            timeAttack = timeAttackObject.GetComponent<TimeAttack>();
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
        timeAttack.AddScore(scoreValue);
    }
}
