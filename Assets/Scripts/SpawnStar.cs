using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab của item cần spawn
    public int itemCount = 10;    // Số lượng item cần spawn
    private float offsetDistance = 0.1f; 
    private Collider2D shapeCollider;

    void Start()
    {
        shapeCollider = GetComponent<Collider2D>();
        if (shapeCollider == null)
        {
            Debug.LogWarning("Không tìm thấy Collider2D trên đối tượng!");
            return;
        }

        SpawnItemsOnTopEdge();
    }

    void SpawnItemsOnTopEdge()
    {
        for (int i = 0; i < itemCount; i++)
        {
            Vector3 spawnPosition = GetRandomPositionOnTopEdge();
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionOnTopEdge()
    {

         float topY = shapeCollider.bounds.max.y + offsetDistance;
        
        float randomX = Random.Range(shapeCollider.bounds.min.x, shapeCollider.bounds.max.x);

        return new Vector3(randomX, topY, 0);
    }
}
