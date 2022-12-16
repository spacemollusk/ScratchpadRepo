using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpokeScript : MonoBehaviour
{

    public event EventHandler OnSpokeCollided;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Material spokeMaterial;

    private void Start()
    {
        OnSpokeCollided += AwardPointsBasedOnSpokeColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnSpokeCollided?.Invoke(this, EventArgs.Empty);
    }

    private void AwardPointsBasedOnSpokeColor(object sender, EventArgs e)
    {
        int materialIndex;
        for (int i = 0; i <= gameManager.materials.Length - 1; i++)
        {
            if (gameManager.materials[i] == spokeMaterial)
            {
                materialIndex = i;
                AddPoints(materialIndex);
            }
        }
    }

    private void AddPoints(int materialIndex)
    {
        switch (materialIndex)
        {
            case 0: gameManager.PlayerPoints += 10;
                break;
            case 1: gameManager.PlayerPoints += 15;
                break;
            case 2: gameManager.PlayerPoints += 20;
                break;
                
        }
    }

    private void OnDestroy()
    {
        OnSpokeCollided -= AwardPointsBasedOnSpokeColor;
    }
}
