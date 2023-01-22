using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float Interval;
    private float initialIntervalValue;

    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        initialIntervalValue = Interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Interval > 0)
        {
            Interval -= Time.deltaTime;
        }
        else
        {
            GameObject enemyClone = Instantiate(Enemy, transform.position, quaternion.identity);
            enemyClone.name = "Bat";
            Interval = initialIntervalValue;
        }
    }
}
