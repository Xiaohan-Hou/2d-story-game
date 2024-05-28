using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawnManager : MonoBehaviour
{
    //For target array
    public GameObject[] targetArray;
    private int targetIndex;

    //Script communication
    private AppleGameManager appleGameManager;

    //Handling spawn location
    private float randomLocationX;
    private float randomLocationY;
    private float leftLimit = -7;
    private float rightLimit = 7;
    private float topLimit = 20;
    private float bottomLimit = 10;

    //Spwan time interval
    private float spawntargetsInterval = 1.0f;

    void Start()
    {
        //Script communciation
        appleGameManager = GameObject.Find("GameManager").GetComponent<AppleGameManager>(); ;
    }

    public IEnumerator SpawnTargets()
    {
        while (appleGameManager.isGameActive)
        {
            //Interval
            yield return new WaitForSeconds(spawntargetsInterval);

            //Getting a random target
            targetIndex = Random.Range(0, targetArray.Length);

            //Getting a random location
            randomLocationX = Random.Range(leftLimit, rightLimit);
            randomLocationY = Random.Range(topLimit, bottomLimit);

            //Spawn
            Instantiate(targetArray[targetIndex], new Vector2(randomLocationX, randomLocationY), targetArray[targetIndex].transform.rotation);
        }
    }
}
