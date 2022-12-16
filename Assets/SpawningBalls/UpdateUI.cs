using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI ballsCountText;

    private Spawner spawner;

    void Start()
    {
        spawner = GetComponent<Spawner>();


    }

 
    void Update()
    {
        
    }
}
