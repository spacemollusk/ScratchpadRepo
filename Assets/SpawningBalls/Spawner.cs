using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public event EventHandler OnBallCreated;

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private Vector3 spawnLocation;

    private  int randomNumber = 2;
   
    void Start()
    {
        InvokeRepeating("InstatiateBall", 1, randomNumber);
    }

    private void Update()
    {
        randomNumber = UnityEngine.Random.Range(0, 10);
    }
    private void InstatiateBall()
    {
       
        Instantiate(ball, spawnLocation, Quaternion.identity);
        OnBallCreated?.Invoke(this, EventArgs.Empty);
    }
}
