using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public PlayerRPS player;
    public GameManagerRPSM gameManager;
    public float choosingInterval;
    private float timer = 0;
    int lastSelection = 0;
    Card[] cards;

    private void Start()
    {
        cards = GetComponentsInChildren<Card>();
    }

    void Update()
    {
        if (gameManager.State != GameManagerRPSM.GameState.ChooseAttack)
        {
            timer = 0;
            return;
        }

        if (timer < choosingInterval)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        ChooseAttack();
    }

    public void ChooseAttack()
    {
        var random = Random.Range(1, cards.Length);
        var selection = (lastSelection + random) % cards.Length;
        player.SetChosenCard(cards[selection]);
        lastSelection = selection;
    }
}
