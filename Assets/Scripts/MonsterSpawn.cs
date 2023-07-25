using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject[] objects;
    public Transform[] SpawnPoints;
    public Camera camera;
    protected GameObject targetMonster;

    void Start()
    {
        RandomSelectSpawnPoint();

    }

    public void Update()
    {
        
    }

    public void RandomSelectSpawnPoint()
    {
        int target = Random.Range(0, objects.Length);
        for (int l = 0 ; l < objects.Length ; l++)
        {
            int number = Random.Range(0, SpawnPoints.Length);
            if (l == target)
            {
                objects[l].tag = "target";
                targetMonster = Instantiate(objects[l], SpawnPoints[number]);
                camera.transform.SetParent(targetMonster.transform);
                camera.transform.localPosition = new Vector3(0.5f, 1.25f, 2f);
                camera.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

            }
            else
            {
                objects[l].tag = "dummy";
                Instantiate(objects[l], SpawnPoints[number]);
                number = Random.Range(0, SpawnPoints.Length);
                Instantiate(objects[l], SpawnPoints[number]);
            }

        }
    }

}