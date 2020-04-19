using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    public GameController gameController;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (gameController.score >= 200)
        {
            var main = ps.main;
            main.simulationSpeed = hSliderValue;
        }
    }
}
