using System.Collections.Generic;
using UnityEngine;

public class BasketSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float[] basketX;
    public GameObject basket;
    public int maxBaskets = 5;                // Max baskets allowed on screen
    private List<GameObject> spawnedBaskets = new List<GameObject>(); // Track spawned baskets
    public List<float>freePositions = new List<float>();

    void Start()
    {
        Invoke("Spawn", 5f);
        freePositions = new List<float>(basketX);
    }

    void Update()
    {
    }
    public void Spawn()
    {
        if (spawnedBaskets.Count < maxBaskets)
        {
            int x = Random.Range(0, freePositions.Count);
            float spawnX = freePositions[x];
            freePositions.RemoveAt(x);
            float spawnY = transform.position.y;
            Vector3 position = new Vector3(spawnX, spawnY, 0);
            GameObject newBasket = Instantiate(basket, position, Quaternion.identity);

            // Add to the tracking list
            spawnedBaskets.Add(newBasket);
        }

        // Always check again after delay
        Invoke("Spawn", 2f);
    }

    public void RemoveBasket(GameObject basketToRemove)
    {
        if (spawnedBaskets.Contains(basketToRemove))
        {
            // Free up this basket's X position
            float xPos = Mathf.Round(basketToRemove.transform.position.x * 100f) / 100f;
            if (!freePositions.Contains(xPos))
            {
                freePositions.Add(xPos);
            }

            // Remove basket from list and destroy it
            spawnedBaskets.Remove(basketToRemove);
            Destroy(basketToRemove);
        }
    }

}
