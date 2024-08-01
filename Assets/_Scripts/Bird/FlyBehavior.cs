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
    [SerializeField] private PipeSpawn pipeSpawn;
    Rigidbody2D rb;
    AudioSource audioSource;
    bool playerDeath;
    //Protected variables

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerDeath = false;
        rb.simulated = false;
        pipeSpawn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        BirdFly();
    }

    void BirdFly()
    {
        if (gameObject.transform.position.y > 1.35f) return;
        if (Mouse.current.leftButton.wasPressedThisFrame && !playerDeath)
        {
            rb.simulated = true;
            GameManager.Instance.startUI.SetActive(false);
            pipeSpawn.gameObject.SetActive(true);
            audioSource.clip = flySfx;
            audioSource.Play();
            rb.velocity = Vector2.up * velocityUp;
        }
        transform.rotation = Quaternion.Euler(0,0, rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerDeath = true;
        audioSource.clip = hitSfx;
        audioSource.Play();
        GameManager.Instance.GetGameOverUI();
    }
}
