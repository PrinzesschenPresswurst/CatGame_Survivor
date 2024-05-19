using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treat : MonoBehaviour
{
    public static event EventHandler<OnFishCollectedEventArgs> OnFishCollected;
    [SerializeField] private int score;
    

    public class OnFishCollectedEventArgs: EventArgs
    {
        public int TreatScore;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //todo probably check for cat 
        OnFishCollected?.Invoke(this, new OnFishCollectedEventArgs
        {
            TreatScore = score,
        });
        Destroy(this.gameObject);
    }
}
