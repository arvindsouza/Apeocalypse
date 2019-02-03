using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint, pauseMenu;

    private Walk player;
    private ApeHealth Health;
    private Health HUDHealth;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Walk>();
        Health = FindObjectOfType<ApeHealth>();
        HUDHealth = FindObjectOfType<Health>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
	}

    public void RespawnPlayer()
    {
        Health.curHealth = Health.MaxHealth;
        player.transform.position = currentCheckpoint.transform.position;
        HUDHealth.checkHealth();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
