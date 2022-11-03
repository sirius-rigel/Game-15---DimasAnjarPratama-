using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TMPro;


public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text stepText;

    [SerializeField]
    ParticleSystem dieParticles;

    [SerializeField, Range(0.01f, 1f)]
    float moveDuration = 0.2f;

    [SerializeField, Range(0.01f, 1f)]
    float jumpHeight = 0.5f;

    private float backBoundary;

    private float leftBoundary;

    private float rightBoundary;

    [SerializeField] private int maxTravel;

    public int MaxTravel
    {
        get => maxTravel;
    }

    [SerializeField] private int currentTravel;

    private int CurrentTravel
    {
        get => currentTravel;
    }

    public bool IsDie { get => this.enabled == false;}

    public void SetUp(int minZPos, int extend)
    {
        backBoundary = minZPos - 1;
        leftBoundary = -(extend + 1);
        rightBoundary = extend + 1;
    }

    private void Update()
    {
        var moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            moveDir += new Vector3(0, 0, 1);
        else if (Input.GetKey(KeyCode.S))
            moveDir += new Vector3(0, 0, -1);
        else if (Input.GetKey(KeyCode.D))
            moveDir += new Vector3(1, 0, 0);
        else if (Input.GetKey(KeyCode.A))
            moveDir += new Vector3(-1, 0, 0);

        if (moveDir != Vector3.zero && IsJumping() == false)
            Jump(moveDir);
    }

    private void Jump(Vector3 targetDirection)
    {
        //Atur Rotasi Pinguin
        var TargetPosition = transform.position + targetDirection;
        transform.LookAt(TargetPosition);

        //Loncat
        var moveSeq = DOTween.Sequence(transform);
        moveSeq.Append(transform.DOMoveY(jumpHeight, moveDuration / 2));
        moveSeq.Append(transform.DOMoveY(0, moveDuration / 2));

        if (
            TargetPosition.z <= backBoundary
            || TargetPosition.x <= leftBoundary
            || TargetPosition.x >= rightBoundary
        )
            return;

        if (Tree.AllPositions.Contains(TargetPosition))
            return;

        //Gerak Maju Mundur Kanan Kiri
        transform.DOMoveX(TargetPosition.x, moveDuration);
        transform.DOMoveZ(TargetPosition.z, moveDuration) .OnComplete(UpdateTravel);
    }

    private void UpdateTravel()
    {
        currentTravel = (int) this.transform.position.z;
        if(currentTravel > maxTravel) maxTravel = currentTravel;

        stepText.text = "SCORE: " + maxTravel.ToString();
    }

    private bool IsJumping()
    {
        return DOTween.IsTweening(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled == false)
            return;

        if (other.tag == "Car")
        {
            AnimateCrash();
        }
    }

    private void AnimateCrash()
    {
        transform.DOScaleY(0.1f, 0.2f);
        transform.DOScaleX(3, 0.2f);
        transform.DOScaleZ(2, 0.2f);
        this.enabled = false;
        dieParticles.Play();
    }

    private void OnTriggerStay(Collider other) { }

    private void OnTriggerExit(Collider other) { }
}
