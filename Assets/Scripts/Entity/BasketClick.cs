using UnityEngine;

public class BasketClick : MonoBehaviour
{
    void OnMouseDown()
    {
        BasketSpawner spawner = FindFirstObjectByType<BasketSpawner>();
        if (spawner != null)
        {
            spawner.RemoveBasket(gameObject);
        }
    }
}
