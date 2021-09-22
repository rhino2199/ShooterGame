/****
 * Created by: Ryan Circelli
 * Date Created: Sept 22, 2021
 * 
 * Last Edited By: Ryan Circelli
 * Last Updated Sept 22,2021
 * 
 * Description:Manages the pool of ammo
 * 
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    #region AmmoManager Singleton
    //Variables
    public static AmmoManager AmmoManagerSingleton = null;

    #endregion
    void SetAmmoManager()
    {
        if (AmmoManagerSingleton == null)
        {
            AmmoManagerSingleton = this;
        } else
        {
            AmmoManagerSingleton = null;
        }
    }

    public GameObject AmmoPrefab = null;
    public int PoolSize = 100;
    public Queue<Transform> AmmoQueue = new Queue<Transform>();

    private GameObject[] AmmoArray;

    private void Awake()
    {
        SetAmmoManager();

        if (AmmoManagerSingleton == null) { return; }

        AmmoArray = new GameObject[PoolSize];
        for (int i = 0; i < PoolSize; i++)
        {
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
            Transform ObjTransform = AmmoArray[i].transform;

            AmmoQueue.Enqueue(ObjTransform);
            AmmoArray[i].SetActive(false);
        }
    }
        public static Transform SpawnAmmo(Vector3 Position, Quaternion Rotation)
    {
        Transform SpawnedAmmo = AmmoManagerSingleton.AmmoQueue.Dequeue();
        SpawnedAmmo.gameObject.SetActive(true);
        SpawnedAmmo.position = Position;
        SpawnedAmmo.localRotation = Rotation;
        AmmoManagerSingleton.AmmoQueue.Enqueue(SpawnedAmmo);
        return SpawnedAmmo;
    }
        
   
}
