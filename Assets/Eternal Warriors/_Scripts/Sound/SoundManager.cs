using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   
    public static SoundManager instance;
    private Dictionary<string, AudioClip> soundClips = new Dictionary<string, AudioClip>();
    public AudioSource SoundSource;

    private void Awake() 
    { 
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundSource = GetComponent<AudioSource>();

        if (SoundSource == null)
        {
            SoundSource = gameObject.AddComponent<AudioSource>();
        }
        LoadSoundClips();
    }

    void LoadSoundClips()
    {
        //add am thanh
        soundClips.Add("Eat", Resources.Load<AudioClip>("Sound/MiniGame 1/Eat"));
        soundClips.Add("Start", Resources.Load<AudioClip>("Sound/MiniGame 1/Start"));
        soundClips.Add("Bonus", Resources.Load<AudioClip>("Sound/MiniGame 1/Bonus"));
        soundClips.Add("Victory", Resources.Load<AudioClip>("Sound/MiniGame 1/Victory"));
    }

    public void PlaySound(string soundName)
    {
        if (soundClips.ContainsKey(soundName))
        {
            SoundSource.PlayOneShot(soundClips[soundName]);
        }
        else
        {
            Debug.LogError("Khong co" + soundName);
        }
    }
}
