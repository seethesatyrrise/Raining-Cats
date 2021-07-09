using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] protected GameObject m_PauseMenu;

    //protected int m_EnemyKillCount;
    protected bool m_IsPaused;

    private static GameManager s_Instance;

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
            //SceneManager.sceneUnloaded -= SceneUnloaded;
        }

        m_IsPaused = false;
        m_PauseMenu?.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    /// <summary>
    /// toggle Pause.
    /// </summary>
    public void TogglePause()
    {
        if (m_IsPaused) { Resume(); } else { Pause(); }
    }

    /// <summary>
    /// Pause game.
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0;
        m_PauseMenu.SetActive(true);
        m_IsPaused = true;
    }

    /// <summary>
    /// Resume game.
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1;
        m_PauseMenu.SetActive(false);
        m_IsPaused = false;
    }
}
