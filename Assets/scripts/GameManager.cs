using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private AudioManager audio2;
    public GameObject panel;
    public TextMeshProUGUI nameprice;
    public TextMeshProUGUI litr;
    public Vector3 offset;
    public Slider slider1;
    public TextMeshProUGUI balance;
    public double money;
    public string vibor;
    public GameObject poyavlenie;
    // Start is called before the first frame update
    void Start()
    {
        audio2 = FindObjectOfType<AudioManager>();
        poyavlenie.SetActive(false);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        balance.text = money.ToString();
    }

    public void Open(string benz, RaycastHit hit)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        vibor = benz;

        panel.SetActive(true);
        if (benz == "92") {
            nameprice.text = "�������: 92 \n ���� �� �. 100";
        }
        else if(benz == "52")
        {
            nameprice.text = "�������: 52 \n ���� �� �. 110";
        }
        else if (benz == "95")
        {
            nameprice.text = "�������: 95 \n ���� �� �. 90";
        }
        panel.transform.position = hit.point + offset;
    }
    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        panel.SetActive(false);
    }
    public void Slider()
    {
        litr.text = slider1.value + " �.";
    }

    public void Buy()
    {
        double cash = 0;

        if(vibor == "95")
        {
            cash = slider1.value * 90;
        }
        else if (vibor == "92")
        {
            cash = slider1.value * 100;
        }
        else if (vibor == "52")
        {
            cash = slider1.value * 110;
        }
        if (money - cash < 0)
        {
            poyavlenie.SetActive(true);
            Invoke("ViclPoyavlenie", 2f);
        }
        else
        {
            money -= cash;
            audio2.PlaySound(0,0);
            audio2.PlaySound(1,1);
            Close();
        }
    }
    public void ViclPoyavlenie()
    {
        poyavlenie.SetActive(false);
    }
}
