using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : MonoBehaviour
{   
    public static SoundMng instance;
    public AudioClip attackSound;
    public AudioSource attackSource;

    private void Awake() 
    { 
        instance = this;
    }
 
    // Start is called before the first frame update
    void Start()
    {
        attackSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
