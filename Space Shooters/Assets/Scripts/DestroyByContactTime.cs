using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactTime : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
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
        if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.CompareTag ("Player"))
        {
            if (timeAttack.lives >= 1)
            {
                //gameController.lives = gameController.lives - 1;
                Destroy(gameObject);
                timeAttack.GameOver();
            }
            else
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            }
            
        }
        if (other.CompareTag ("Bolt") || other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        timeAttack.AddScore(scoreValue);
        //Destroy(other.gameObject);
        //Destroy(gameObject);
    }
}
