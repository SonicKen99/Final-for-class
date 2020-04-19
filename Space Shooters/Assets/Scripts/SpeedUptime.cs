using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUptime : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    public TimeAttack timeAttack;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (timeAttack.timeLeft <= 0)
        {
            var main = ps.main;
            main.simulationSpeed = hSliderValue;
        }
    }
}
