using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    //Public variables
    //Private variables
    
    [SerializeField] private float velocityUp = 1.5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private AudioClip hitSfx;
    [SerializeField] private AudioClip flySfx;
    Rigidbody2D rb;
    AudioSource audioSource;
    //Protected variables

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BirdFly();
    }

    void BirdFly()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            audioSource.clip = flySfx;
            audioSource.Play();
            rb.velocity = Vector2.up * velocityUp;
        }
        transform.rotation = Quaternion.Euler(0,0, rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.clip = hitSfx;
        audioSource.Play();
        GameManager.Instance.GetGameOverUI();
    }
}
