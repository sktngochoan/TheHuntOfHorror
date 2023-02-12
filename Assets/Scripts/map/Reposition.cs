using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
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
        for(int i = 0;i<3;i++)
        {
            SpawnObject();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        if (!collision.CompareTag("Area"))
        {
            return;
        }
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);
        Vector3 playerDir = GameManager.instance.player.inputVector2;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        
        switch (transform.tag)
        {
            case "Ground":
                DestroyObject();
                for (int i = 0; i < 6; i++)
                {
                    SpawnObject();
                }
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if(diffY > diffX)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                break;
        }
    }

    private void SpawnObject()
    {
        int spawnObjcetId = Random.Range(0, spawnObjects.Length);
        Vector2 position = GetRandomCoordinates();
        spawnObject = Instantiate(spawnObjects[spawnObjcetId], position, Quaternion.identity);
        spawnObject.tag = "object";
    }
    private void DestroyObject()
    {
        GameObject[] gameObjectToDestroy = GameObject.FindGameObjectsWithTag("object");
        for(int i = 0;i<gameObjectToDestroy.Length;i++)
        {
            if(gameObjectToDestroy[i].transform.position.x > Mcamera.transform.position.x
                || gameObjectToDestroy[i].transform.position.y > Mcamera.transform.position.y)
            {
                Destroy(gameObjectToDestroy[i]);
            }
        }
    }
    private Vector2 GetRandomCoordinates()
    {
        randomX = Random.Range(100 + offsetX, Screen.width - offsetX);
        randomY = Random.Range(100 + offsetY, Screen.height - offsetY);

        Vector2 coordinates = new Vector2(randomX, randomY);
        Vector2 screenToWourldPoint = Mcamera.ScreenToWorldPoint(coordinates);
        return screenToWourldPoint;
    }


}
