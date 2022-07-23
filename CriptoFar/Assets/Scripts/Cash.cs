using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public float money;
    public float bitcoin;
    public float kittycoin;
    public float kittycoinCost;
    public float bitcoinCost;
    public float bitcoinSec;
    public float kittySec;
    public float timer = 1;
    public TMP_Text moneyText;
    public List<TMP_Text> bitcoinText;
    public GameObject buyPanel;
    public GameObject player;
    public GameObject comp;
    public List<Base> bases;
    public GameObject copyBase;
    public List<TMP_Text> procents;

    private void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            bitcoin += bitcoinSec;
            kittycoin += kittySec;
            timer = 1;
        }
        moneyText.text = $"{money}$";
        bitcoinText[0].text = $"{bitcoin}";
        bitcoinText[1].text = $"{bitcoinCost}$";
        bitcoinText[2].text = $"{kittycoin}";
        bitcoinText[3].text = $"{kittycoinCost}$";
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Vector3.Distance(player.transform.position,comp.transform.position) <= 3)
            {
                Cursor.visible = !Cursor.visible;
                Cursor.lockState = CursorLockMode.None;
                buyPanel.SetActive(!buyPanel.activeSelf);
            }
        }
        if (Vector3.Distance(player.transform.position, comp.transform.position) > 3 && buyPanel.activeSelf == true)
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = CursorLockMode.None;
            buyPanel.SetActive(!buyPanel.activeSelf);
        }
        if(bases.Count >= 1)
        {
            float bitAll = 0;
            float kittyAll = 0;
            foreach (Base b in bases)
            {
                if (b.criptoNow == Base.cripto.Bitcoin)
                {
                    bitAll += b.speedMining; 
                }
                else if (b.criptoNow == Base.cripto.KittyCoin)
                {
                    kittyAll += b.speedMining;
                }
            }
            bitcoinSec = bitAll;
            kittySec = kittyAll;
        }
    }
    public void buyStation()
    {
        if (money >= 1000)
        {
            money -= 1000;
            GameObject baser = Instantiate(copyBase, new Vector3(38, 0.5f, 51), Quaternion.identity);
            baser.SetActive(true);
            baser.GetComponent<Base>().criptoNow = Base.cripto.Bitcoin;
            bases.Add(baser.GetComponent<Base>());
        }
    }

    public void sellBitcoin()
    {
        if (bitcoin > 0)
        {
            money += Mathf.Round(bitcoin * bitcoinCost);
            bitcoin = 0;
        }
    }

    public void sellKitty()
    {
        if(kittycoin > 0)
        {
            money += Mathf.Round(kittycoin * kittycoinCost);
            kittycoin = 0;
        }
    }
}
