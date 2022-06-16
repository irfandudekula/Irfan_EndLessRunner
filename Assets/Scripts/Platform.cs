using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] platformprefabs;                        // set of number of platforms to spawn
    public float zpos = 0;
    public float platformlength;                               // length of platform
    public Transform Player;
    private List<GameObject> Activeplatforms = new List<GameObject>();
   
    void Start()
    {
        for (int i = 0; i < 5; i++)                                     // spawn platforms at number below 3 at start point
        {
            if (i == 0)
            {
                Spawnplatform(0);
            }
            else
            {
                Spawnplatform(Random.Range(0, platformprefabs.Length));                 // randomly spawn platforms
            }
        }
    }

 
    void Update()               
    {
        if (Player.transform.position.z - platformlength > zpos - (5 * platformlength))                                     // if player position moves then platform spawning increases
        {
            Spawnplatform(Random.Range(0, platformprefabs.Length));                                                 // spwaning randomly and deleting backwards
            deleteplatforms();
        }
    }
    public void Spawnplatform(int platformIndex)                                                                        
    {
        GameObject go = Instantiate(platformprefabs[platformIndex], transform.forward * zpos, transform.rotation);                                    // spawning platform based on index
        Activeplatforms.Add(go);    
        zpos += platformlength;
    }
    private void deleteplatforms()
    {
        Destroy(Activeplatforms[0]);                                                        // destroying platforms
        Activeplatforms.RemoveAt(0);
    }
}
