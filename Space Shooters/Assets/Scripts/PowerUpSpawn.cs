using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] powerup;
    public Vector3 spawnValues;
    public int powerupCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < powerupCount; i++)
            {
                GameObject hazard = powerup[Random.Range(0, powerup.Length)];
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
        }
    }
}
