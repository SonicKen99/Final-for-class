using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
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
            if(gameController.lives >=1)
            {
                //gameController.lives = gameController.lives - 1;
                Destroy(gameObject);
                gameController.GameOver();
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
        gameController.AddScore(scoreValue);
       //Destroy(other.gameObject);
        //Destroy(gameObject);
    }
}
