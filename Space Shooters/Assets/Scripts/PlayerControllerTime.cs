using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary2
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerControllerTime : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary2 boundary;

    public GameObject shot;
    public Transform shotSpawn;
    //public Transform shotSpawn2;
    public float fireRate;
    public AudioClip musicClip;
    public AudioSource musicSource;
    public TimeAttack timeAttack;
    public GameObject playerExplosion;


    private bool isActive = false;
    private float nextFire;
   // private float nextFire2;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        musicSource.clip = musicClip;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {       
                nextFire = Time.time + fireRate;
                //  GameObject clone = 
                GetComponent<AudioSource>().Play();
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;

        }
        //if (timeAttack.score >= 200)
       // {

           // fireRate = 10;
        //}

        //if (timeAttack.timeLeft <= 0)
        //{
          //  Instantiate(playerExplosion, gameObject.transform.position, gameObject.transform.rotation);
          //  gameObject.SetActive(false);
            
       // }
            //if (Input.GetButton("Fire1") && Time.time > nextFire2)
            // {
            //   nextFire2 = Time.time + fireRate;
            //  GameObject clone = 
            //    GetComponent<AudioSource>().Play();           
            //    Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);

            //  }
        }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.CompareTag("Fire") && isActive == false)
            {
                isActive = true;
                fireRate = fireRate / 2;
               
            }
             isActive = false;

        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            timeAttack.lives = timeAttack.lives - 1;
            timeAttack.GameOver();
        }
    }
}
