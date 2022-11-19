using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;   

public class Card : MonoBehaviour
{
    public Attack AttackValue;
    public PlayerRPS player;
    public Vector2 startPosition;
    Vector2 startScale;
    Color originalColor;
    bool isClickable = true; 

    private void Start()
    {
        startPosition = this.transform.position;
        startScale = this.transform.localScale;
        originalColor = GetComponent<Image>().color;
    }

    public void onClick()
    {
        if (isClickable) player.SetChosenCard(newCard: this);
    }

    internal void Reset()
    {
        transform.position = startPosition;
        transform.localScale = startScale;
        GetComponent<Image>().color = originalColor;
    }

    public void SetClickable(bool value)
    {
        isClickable = value;
    }
}
