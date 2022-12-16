using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardShake : MonoBehaviour
{
    public LayerMask layermask;


    [SerializeField]
    private Collider[] plankHitColliders;

    private bool isShaking = false;

    [Header("Object Shakey Variables")]

    [SerializeField]
    private float shakeSpeed;
    [SerializeField]
    private float shakeIntensity;

    private float rotateZ;

    private void Update()
    {
        if (isShaking == true)
        {
            foreach (Collider collider in plankHitColliders)
            {
                rotateZ = Mathf.SmoothStep(0, shakeIntensity, Mathf.PingPong(Time.time * shakeSpeed, 1));
                collider.gameObject.transform.rotation = Quaternion.Euler(0, 0, rotateZ);
            }
        }
    }

    private void PlankCollisions()
    {
      
       plankHitColliders = Physics.OverlapBox(transform.position, transform.localScale /2, Quaternion.identity, layermask);
       int i = 0;
       
       foreach (var collider in plankHitColliders) { 
            Debug.Log("Hit : " + plankHitColliders[i].name + i);
            i++;


        }
       isShaking = true;
        StartCoroutine(ShakingBool());
     
        
    }
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hammer"))
        {
            PlankCollisions();
            
        }
    }

    private IEnumerator ShakingBool()
    {
        yield return new WaitForSeconds(2);
        isShaking=false;
    }
  
  
}
