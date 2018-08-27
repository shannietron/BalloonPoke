using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
public class spawnObject : MonoBehaviour {

    public float minSpawnTime = 0f;
    public float maxSpawnTime = 0.5f;
    private float nextSpawnTime;

    public GameObject balloonPrefab;
    public Vector3 center;
    public Vector3 size;
    public Balloon.BalloonColor color = Balloon.BalloonColor.Random;

    // Use this for initialization
    void Start() {
        SpawnBalloon(color);
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime) + Time.time;
            Debug.Log(nextSpawnTime);

    }

    // Update is called once per frame
    void Update() {

        if ((Time.time > nextSpawnTime))
        {
            SpawnBalloon(color);
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime) + Time.time;
                Debug.Log(nextSpawnTime - Time.time);
            }

    }
    public void SpawnBalloon(Balloon.BalloonColor color = Balloon.BalloonColor.Red)
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        GameObject balloon = Instantiate(balloonPrefab, pos, Quaternion.identity);
        balloon.GetComponentInChildren<Balloon>().SetColor(color);
        }
}
}