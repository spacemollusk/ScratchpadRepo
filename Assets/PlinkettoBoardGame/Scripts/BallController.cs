using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    private InstatiatedBall prefabBall;

    [SerializeField]
    private float endPosZValue = 3f;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 worldSpaceSpawnPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            InstantiateBall(endPos);
        }
    }

    private void InstantiateBall(Vector3 endPos)
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }
        if (gameManager.isPlayerTurn)
        {
            endPos.z = endPosZValue;
            worldSpaceSpawnPos = Camera.main.ScreenToWorldPoint(endPos);
            Instantiate(prefabBall, worldSpaceSpawnPos, Quaternion.identity);
            gameManager.isPlayerTurn = false;
        }
    }
}
