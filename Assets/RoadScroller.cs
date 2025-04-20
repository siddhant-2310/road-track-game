using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    public float scrollSpeed = 2f; // Adjust speed to match player movement
    private Renderer roadRenderer;

    void Start()
    {
        roadRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Scroll texture downwards to simulate movement
        Vector2 offset = new Vector2(0, -Time.time * scrollSpeed);

        roadRenderer.material.mainTextureOffset = offset;
    }
}
