using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] GameObject shootCountText;
    [SerializeField] PlayerController player;
    [SerializeField] Hole hole;
    [SerializeField] GameObject comingSoon;

    private void Start()
    {
        // gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if(hole.Entered && gameOverPanel.activeInHierarchy == false)
        {
            shootCountText.SetActive(false);
            gameOverPanel.SetActive(true);
            gameOverText.text = "Finished!<br>Shoot Count : " + player.ShootCount;
        }
    }

    public void BackToMainMenu()
    {
        SceneLoader.Load("MainMenu");
    }

    public void Replay()
    {
        SceneLoader.ReloadLevel();
    }

    public void PlayNext()
    {
        SceneLoader.LoadNextLevel();
    }

    public void ComingSoon()
    {
        comingSoon.SetActive(true);
    }
}
