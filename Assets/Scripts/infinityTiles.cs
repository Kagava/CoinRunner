using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinityTiles : MonoBehaviour
{
    public GameObject[] tiles;
    public float placeSpawnZ = 0;
    public float leghtTile = 16;
    public int valueTimes = 1000;
    public Transform pT;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < valueTimes; i++)
        {
            if (i == 0)
            {
                spawningTiles(0);
            }
            else
            {
                spawningTiles(Random.Range(0, tiles.Length));
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pT.position.z> placeSpawnZ - (valueTimes * leghtTile))
        {
            spawningTiles(Random.Range(0, tiles.Length));
        }
    }
    public void spawningTiles(int tileIndex)
    {
        Instantiate(tiles[tileIndex], transform.forward * placeSpawnZ, transform.rotation);
        placeSpawnZ += leghtTile;
    }
}
