using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Public variables
    public static GameManager Instance;
    public GameObject startUI;
    public GameObject scoreUI;
    //Private variables
    [SerializeField] private GameObject gameOverUI;
    //Protected variables

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetGameOverUI()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BtnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
