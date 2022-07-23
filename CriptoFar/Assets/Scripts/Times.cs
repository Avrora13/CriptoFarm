using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Times : MonoBehaviour
{
    public int hour;
    public int minute; 
    public float timer = 1;
    public TMP_Text timesText;
    public Cash cash;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            minute++;
            timer = 1;
        }
        if(minute == 60)
        {
            hour++;
            minute = 0;
            float randomCost = Random.Range(-0.4f, 0.4f);
            cash.bitcoinCost = cash.bitcoinCost + (cash.bitcoinCost * randomCost);
            cash.procents[0].text = $"{Mathf.Round(randomCost * 100)}%";
            randomCost = Random.Range(-0.4f, 0.4f);
            cash.kittycoinCost = cash.kittycoinCost + (cash.kittycoinCost * randomCost);
            cash.procents[1].text = $"{Mathf.Round(randomCost * 100)}%";
        }
        if(hour == 24)
        {
            hour = 0;
        }
        if (hour < 10 && minute < 10)
        {
            timesText.text = $"0{hour}:0{minute}";
        }
        else if(hour < 10)
        {
            timesText.text = $"0{hour}:{minute}";
        }
        else if(minute < 10)
        {
            timesText.text = $"{hour}:0{minute}";
        }
        else
        {
            timesText.text = $"{hour}:{minute}";
        }
    }
}
