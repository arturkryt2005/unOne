using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] massiv;
    public AudioSource[] zvuki;
    // Start is called before the first frame update
    void Start()
    {
        zvuki = new AudioSource[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            zvuki[i] = transform.GetChild(i).GetComponent<AudioSource>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(int clipNumber, int sourceNumber)
    {
        zvuki[sourceNumber].PlayOneShot(massiv[clipNumber]);
    }
}
