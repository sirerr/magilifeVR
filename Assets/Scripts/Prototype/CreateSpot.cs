using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpot : MonoBehaviour
{
   public float LifeTime = 2f;
    private void Awake()
    {
        StartCoroutine(Life());
    }

    IEnumerator Life()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }
}
