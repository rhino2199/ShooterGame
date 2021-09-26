/****
 * Created by: Ryan Circelli
 * Date Created: Sept 20, 2021
 * 
 * Last Edited By: Ryan Circelli
 * Last Updated Sept 22,2021
 * 
 * Description:Spawns Enemies
 * 
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variables

    public float MaxRadius = 10f;
    public float Interval = 5f;
    public GameObject ObjToSpawn = null;
    private Transform Origin = null;
  



    private void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
    }

    void Spawn()
    {
        if (Origin == null){return;}
        Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
        Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
    }
}
