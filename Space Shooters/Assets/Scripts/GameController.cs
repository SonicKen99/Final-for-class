using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GameObject[] powerup;
    public Vector3 spawnValues2;
    public int powerupCount;
    public float spawnWait2;
    public float startWait2;
    public float waveWait2;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text LivesText;
    public Text TimeAttackText;

    public AudioClip musicClip;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;
    public AudioSource musicSource;

    public float timeLeft = 60;
    public Text TimeText;
    private bool timerIsActive = true;

    public int lives;
    private bool gameOver;
    private bool restart;
    public int score;
    

    void Start()
    {
        gameOver = false;
        restart = false;
        lives = 3;
        RestartText.text = "";
        GameOverText.text = "";
        TimeAttackText.text = "";
        GameOver();
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
        musicSource.clip = musicClipThree;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                SceneManager.LoadScene("Space Shooter Challenge");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("TimeAttack");
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (timerIsActive)
        {
            timeLeft -= Time.deltaTime;
            TimeText.text = (timeLeft).ToString("0");
            if (timeLeft <= 0)
            {
                timerIsActive = false;
                GameOver();

            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        yield return new WaitForSeconds(startWait2);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                /* bool flag = (Random.value > 0.5f);
                  if (flag)
                  {
                  
                  spawnValues.z (16 or -16)

                  }
                 */
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                //GameObject clone = 
                    Instantiate(hazard, spawnPosition, spawnRotation);
                //ReverseDirection(clone);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);
            for (int i = 0; i < powerupCount; i++)
            {
                GameObject power = powerup[Random.Range(0, powerup.Length)];
                /* bool flag = (Random.value > 0.5f);
                  if (flag)
                  {
                  
                  spawnValues.z (16 or -16)

                  }
                 */
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues2.x, spawnValues2.x), spawnValues2.y, spawnValues2.z);
                Quaternion spawnRotation = Quaternion.identity;
                //GameObject clone = 
                Instantiate(power, spawnPosition, spawnRotation);
                //ReverseDirection(clone);
                yield return new WaitForSeconds(spawnWait2);

            }
            yield return new WaitForSeconds(waveWait2);

            if (gameOver)
            {
                RestartText.text = "Press 'K' for Restart";
                TimeAttackText.text = "Press 'R for TimeAttack Mode";
                restart = true;
                
                break;
            }
        }
    }

    /*void ReverseDirection(GameObject clone)
    {
        clone.transform.rotation.y = 0;
        clone.GetComponent<Mover> ().speed = 5;
    }
    */
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 200 && timerIsActive)
        {
            
            timerIsActive = false;
            GameOverText.text = "You Win! Game Created By Kendrick Rivera.";
            musicSource.Stop();
            musicSource.clip = musicClip;
            musicSource.Play();
            gameOver = true;
            restart = true;
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            GameOver();
        }
    }

    public void GameOver()
    {
        LivesText.text = "Lives: " + lives.ToString();
        if (lives == 0 || timeLeft <= 0)
        {

            GameOverText.text = "Game Over!";
            musicSource.Stop();
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            gameOver = true;
            restart = true;
        }

    }


}
