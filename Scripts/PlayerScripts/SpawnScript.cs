using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPoint : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject player;
    private Vector3 respawnLocation;

    
    void Start()
    {
        player = (GameObject)Resources.Load("Player",typeof(GameObject));
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        respawnLocation = player.transform.position;
        SpawnPlayer();
    }
    

    private void SpawnPlayer()
    {
        GameObject.Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
    }
}
