using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnObjects;
    [SerializeField]
    private Camera Mcamera;
    [SerializeField]
    private int offsetX;
    [SerializeField]
    private int offsetY;

    GameObject spawnObject;
    private int randomX;
    private int randomY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        int spawnObjcetId = Random.Range(0,spawnObjects.Length);
        Vector2 position = GetRandomCoordinates();
        spawnObject = Instantiate(spawnObjects[spawnObjcetId], position, Quaternion.identity);
    }

    private Vector2 GetRandomCoordinates()
    {
        randomX = Random.Range(0 + offsetX, Screen.width - offsetX);
        randomY = Random.Range(0 + offsetY, Screen.height - offsetY);

        Vector2 coordinates = new Vector2(randomX, randomY);
        Vector2 screenToWourldPoint = Mcamera.ScreenToWorldPoint(coordinates);
        return screenToWourldPoint;
    }
}
