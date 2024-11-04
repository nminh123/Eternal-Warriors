using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class Timeline : MonoBehaviour
{
    private PlayableDirector playableDirector;
    public Button skipButton;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        /*playableDirector.stopped += OnTimelineStopped;*/ // them su kien khi timeline dung
        skipButton.onClick.AddListener(SkipCutscene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SkipCutscene()
    {
        // Dung timeline lai ngay lap tuc
        playableDirector.Stop();
        //OnTimelineStopped(playableDirector);

    }
    void OnDestroy()
    {
        /*playableDirector.stopped -= OnTimelineStopped;*/ // Bo su kien
        skipButton.onClick.RemoveListener(SkipCutscene); //// Bo su kien nut
    }
}
