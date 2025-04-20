using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coinCount = 0; // Store collected coins

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoin()
    {
        coinCount++;
        Debug.Log("Coins Collected: " + coinCount); // Debug log for tracking
    }

    public int GetCoinCount()
    {
        return coinCount; // If needed elsewhere
    }
}

