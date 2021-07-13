using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    [SerializeField] Transform mark;

    [SerializeField] int bananasCount = 0;
    [SerializeField] int applesCount = 0;
    [SerializeField] int milkCount = 0;

    public int BananasCount => bananasCount;
    public int ApplesCount => applesCount;
    public int MilkCount => milkCount;

    bool isPaused;
    bool hatEnabled;

    static GameManager s_Instance;

    public static GameManager Instance
    {
        get
        {
            if (s_Instance != null) { return s_Instance; }

            s_Instance = FindObjectOfType<GameManager>();
            if (s_Instance == null)
            {
                s_Instance = new GameObject("Game Manager").AddComponent<GameManager>();
            }

            return s_Instance;
        }
    }


    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }

        isPaused = false;
        pauseMenu?.SetActive(false);
        hatEnabled = false;
        mark = GameObject.Find("Mark").transform;
        mark.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused) { Resume(); } else { Pause(); }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void PickUpCountUp(string tag)
    {
        switch (tag)
        {
            case ("Banana"):
                bananasCount++;
                break;
            case ("Apple"):
                applesCount++;
                break;
            case ("Milk"):
                milkCount++;
                break;
            default:
                Debug.Log("You Picked Up Something Weird");
                break;
        }

        if (bananasCount >= 4 && applesCount >= 4 && milkCount >= 4)
        {
            hatEnabled = true;
        }
    }

    public void GetAttention(Transform item)
    {
        mark.gameObject.SetActive(true);
        mark.position = item.position;
    }

    public void RemoveMark()
    {
        mark.gameObject.SetActive(false);
    }
}
