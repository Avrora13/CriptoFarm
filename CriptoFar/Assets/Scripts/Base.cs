using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
    public float speedMining;
    public GameObject player;
    public GameObject comp;
    public GameObject panelBase;
    public TMP_Text countMining;
    public TMP_Text nameCripto;
    public TMP_Dropdown dropdown;
    public Cash cash;
    public enum cripto
    {
        Bitcoin,
        KittyCoin
    }
    public cripto criptoNow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(player.transform.position, comp.transform.position) <= 3)
            {
                Cursor.visible = !Cursor.visible;
                Cursor.lockState = CursorLockMode.None;
                panelBase.SetActive(!panelBase.activeSelf);
                player.GetComponent<baseRange>().playerBase = this;
            }
        }
        if (Vector3.Distance(player.transform.position, comp.transform.position) > 3 && panelBase.activeSelf == true)
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = CursorLockMode.None;
            panelBase.SetActive(!panelBase.activeSelf);
            player.GetComponent<baseRange>().playerBase = null;
        }
        countMining.text = $"{speedMining}/sec.";
        nameCripto.text = criptoNow.ToString();
    }

    public void ChangeCripto()
    {
        if(cash.money >= 150)
        {
            if (dropdown.value == 0)
            {
                player.GetComponent<baseRange>().playerBase.criptoNow = Base.cripto.Bitcoin;
            }
            else if (dropdown.value == 1)
            {
                player.GetComponent<baseRange>().playerBase.criptoNow = Base.cripto.KittyCoin;
            }
            cash.money -= 150;
            speedMining = speedMining - (Random.Range(0.05f, 0.15f) * speedMining);
        }    
    }

    public void UpgradeCard()
    {
        if(cash.money >= 200)
        {
            player.GetComponent<baseRange>().playerBase.speedMining *= Random.Range(1.1f, 2.5f);
            cash.money -= 200;
        }
    }
}
