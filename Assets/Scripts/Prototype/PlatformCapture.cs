using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCapture : MonoBehaviour
{
    public int WhoCaptured =0;
    int PlayersInArea = 0;
    bool SittingInside = false;
    public float TimeToCapture = 10f;
    float captureTimer = 0;
    private IEnumerator CaptureCourotine;
    Color StartColor = Color.green;
    Color CapColor = Color.blue;
    Collider TheFirstCollider = new Collider();
    Collider TheSecondCollider = new Collider();
    Material mat;
    private void OnTriggerEnter(Collider other)
    { 
        if(other.CompareTag("Player"))
        {
            if(PlayersInArea==0)
            {
                TheFirstCollider = other;
            }else
            {
                TheSecondCollider = other;
            }

            PlayersInArea++;
            SittingInside = true;

            if(PlayersInArea==1)
            {
                CaptureCourotine = CaptureThePlatform(TheFirstCollider);
                StartCoroutine(CaptureCourotine);
              
            }
        }

    
    }
    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayersInArea--;
            print(PlayersInArea);

            if(PlayersInArea ==0)
            {
                StopCoroutine(CaptureCourotine);
                captureTimer = 0;
            }

           else if (other == TheFirstCollider && PlayersInArea==1)
            {
                StopCoroutine(CaptureCourotine);
                captureTimer = 0;
                StartCoroutine(CaptureThePlatform(TheSecondCollider));
            }
             else if(other == TheSecondCollider && PlayersInArea ==1)
            {
                StartCoroutine(CaptureThePlatform(TheFirstCollider));
            }
        }
      
    }

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        mat.color = StartColor;
    }

    IEnumerator CaptureThePlatform(Collider col)
    {
        while(SittingInside && captureTimer<TimeToCapture)
        {
            yield return new WaitForSeconds(1f);
            captureTimer++;
            print(captureTimer);
        }
        TestCharacter tester = col.GetComponent<TestCharacter>();

        WhoCaptured = tester.PlayerNum;
        mat.color = CapColor;
    }
}
