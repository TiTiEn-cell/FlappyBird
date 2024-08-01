using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeIncressScore : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            Score.Instance.UpdateScore();
        }
    }
}
