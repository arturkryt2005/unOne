using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject hand;
    private RaycastHit hit;
    public float pickDistance;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        hand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, pickDistance)) return;
        if (gameManager.panel.activeSelf)
        {
            return;
        }
        if (hit.collider.tag == "92" || hit.collider.tag == "52" || hit.collider.tag == "95") {
            hand.SetActive(true);
        }

        else { 
            hand.SetActive(false); 
        }

        if(Input.GetKeyDown(KeyCode.E) && hand.activeSelf)
        {
            Open(hit.collider.tag, hit);
        }
    }
    
    void Open(string benz, RaycastHit hit1)
    {
        hand.SetActive(false);
        gameManager.Open(benz, hit1);
    }

}
