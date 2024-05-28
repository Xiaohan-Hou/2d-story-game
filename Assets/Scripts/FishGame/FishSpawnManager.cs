using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnManager : MonoBehaviour
{
    //Array for spawn targets
    public GameObject[] leftArray;
    public GameObject[] rightArray;

    //Array index
    private int leftIndex;
    private int rightIndex;

    //Handling random location
    private float randomLocationX;
    private float randomLocationY;

    //Script communication
    private FishGameManager fishGameManager;

    void Start()
    {
        //Script communication
        fishGameManager = GameObject.Find("GameManager").GetComponent<FishGameManager>();
    }

    //Spawn left targets
    public IEnumerator SpawnLeftTargets()
    {
        while (fishGameManager.isGameActive)
        {
            yield return new WaitForSeconds(1.0f);

            leftIndex = Random.Range(0, leftArray.Length);

            randomLocationX = Random.Range(-11, -10);
            randomLocationY = Random.Range(1, -4);

            Instantiate(leftArray[leftIndex], new Vector2(randomLocationX, randomLocationY), leftArray[leftIndex].transform.rotation);
        }
    }

    //Spawn right targets
    public IEnumerator SpawnRightTargets()
    {
        while (fishGameManager.isGameActive)
        {
            yield return new WaitForSeconds(1.0f);

            rightIndex = Random.Range(0, rightArray.Length);

            randomLocationX = Random.Range(10,11);
            randomLocationY = Random.Range(1,-4);

            Instantiate(rightArray[rightIndex], new Vector2(randomLocationX, randomLocationY), rightArray[rightIndex].transform.rotation);
        }
    }
}
