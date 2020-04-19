using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrollerTime : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizedZ;
    public TimeAttack timeAttack;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizedZ);
        transform.position = startPosition + Vector3.forward * newPosition;

         if (timeAttack.timeLeft <= 0)
        {
            scrollSpeed =  -50;
        } 
    }
}
