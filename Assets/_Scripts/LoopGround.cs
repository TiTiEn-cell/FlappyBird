using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float maxWidth = 6f;

    private SpriteRenderer spriteRenderer;
    private Vector2 startSize;
    //Protected variables

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startSize = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + speed * Time.deltaTime,spriteRenderer.size.y);
        if (spriteRenderer.size.x > maxWidth)
        {
            spriteRenderer.size = startSize;
        }
    }
}
