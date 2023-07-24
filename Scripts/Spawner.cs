using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject knife;

    public float min_X = -2.5f, max_X = 2.5f;
    public float spawnTime_Min = 0.5f, spawnTime_Max = 1f;

    void Start()
    {
        //StartCoroutine(SpawnKnife());

        Invoke("SpawnKnife", Random.Range(spawnTime_Min,  spawnTime_Max)); // second way to create spawners by using invoke f-s
    }

    void SpawnKnife()
    {
        float x = Random.Range(min_X, max_X); // spawn can return any number between setted -2.5 and 2.5

        Quaternion knifeRot = Quaternion.Euler(0, 0, 90); // we set up rotation with quaternion

        GameObject k = Instantiate(knife, new Vector3(x, transform.position.y, 0f), knifeRot);

        Invoke("SpawnKnife", Random.Range(spawnTime_Min,  spawnTime_Max));
    }

    //IEnumerator SpawnKnife() // one way to create spawners
    //{
     //   yield return new WaitForSeconds(Random.Range(spawnTime_Min,  spawnTime_Max)); // we wait for 1f(second) and then execute code below

     //   GameObject k = Instantiate(knife); // creates copy of a prefab

     //   float x = Random.Range(min_X, max_X); // spawn can return any number between setted -2.5 and 2.5

     //   k.transform.position = new Vector2(x, transform.position.y);

     //   StartCoroutine(SpawnKnife());
    //}
}
