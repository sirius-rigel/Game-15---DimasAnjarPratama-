using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    GameObject scorePanel;

    [SerializeField]
    GameObject grass;

    [SerializeField]
    GameObject road;

    [SerializeField]
    int extend = 7;

    [SerializeField]
    int frontDistance = 10;

    [SerializeField]
    int minZPos = -5;

    [SerializeField]
    int maxTerrainRepeat = 3;

    Dictionary<int, TerrainBlocks> map = new Dictionary<int, TerrainBlocks>(50);

    TMP_Text gameOverText;

    private void Start()
    {
        //Game Over Panel
        gameOverPanel.SetActive(false);
        gameOverText = gameOverPanel.GetComponentInChildren<TMP_Text>();

        //Belakang
        for (int z = minZPos; z <= 0; z++)
        {
            CreateTerrain(grass, z);
        }

        //Depan
        for (int z = 1; z <= frontDistance; z++)
        {
            var prefab = GetNextRandomTerrainPrefab(z);

            //Instantiate Block
            CreateTerrain(prefab, z);
        }

        player.SetUp(minZPos, extend);
    }

    private int playerLastMaxTravel;

    private void Update()
    {
        //Cek Player Hidup atau Mati
        if (player.IsDie && gameOverPanel.activeInHierarchy == false)
            ShowGameOverPanel();

        //Infinite Terrain
        if (player.MaxTravel == playerLastMaxTravel)
            return;

        playerLastMaxTravel = player.MaxTravel;

        //Bikin ke Depan
        var randTb = GetNextRandomTerrainPrefab(player.MaxTravel + frontDistance);
        CreateTerrain(randTb, player.MaxTravel + frontDistance);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ShowGameOverPanel()
    {
        gameOverText.text = "YOUR SCORE : " + player.MaxTravel;  
        scorePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    private void CreateTerrain(GameObject prefab, int zPos)
    {
        var go = Instantiate(prefab, new Vector3(0, 0, zPos), Quaternion.identity);
        var tb = go.GetComponent<TerrainBlocks>();
        tb.Build(extend);

        map.Add(zPos, tb);
    }

    private GameObject GetNextRandomTerrainPrefab(int nexPos)
    {
        bool isUniform = true;
        var tbref = map[nexPos - 1];
        for (int distance = 2; distance <= maxTerrainRepeat; distance++)
        {
            if (map[nexPos - distance].GetType() != tbref.GetType())
            {
                isUniform = false;
                break;
            }
        }

        if (isUniform)
        {
            if (tbref is Grass)
                return road;
            else
                return grass;
        }

        return Random.value > 0.6f ? road : grass;
    }
}
