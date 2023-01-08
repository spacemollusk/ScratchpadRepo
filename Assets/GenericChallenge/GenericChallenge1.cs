using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericChallenge1<T> : MonoBehaviour where T : MonoBehaviour
{
  
    private void Start()
    {
        OnItemPickup();
    }
    
    void OnItemPickup()
    {
        GameObject item = new GameObject();
        item.name = $"Well worn {typeof(T)}. ";

        item.AddComponent<T>();
        item.SetActive(false);

        Debug.Log($"You found a {typeof(T)}");
    }

}
