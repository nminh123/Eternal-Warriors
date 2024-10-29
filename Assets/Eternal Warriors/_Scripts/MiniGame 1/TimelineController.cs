using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class TimelineController : MonoBehaviour
{
    private PlayableDirector playableDirector;
    public Player player;
    public TimeEnd timeEnd;
    public Button skipButton;
    public GameObject timeLine;
    public GameObject munk;
    public GameObject startGameCanvas;
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        playableDirector.stopped += OnTimelineStopped; // them su kien khi timeline dung
        skipButton.onClick.AddListener(SkipCutscene);
    }
    private void SkipCutscene()
    {
        // Dung timeline lai ngay lap tuc
        playableDirector.Stop();
        OnTimelineStopped(playableDirector);
        
    }
    private void OnTimelineStopped(PlayableDirector director)
    {
        // Cho phep nguoi choi dieu khien nhan vat sau khi timeline ket thuc
        player.EnableControl(true);
        timeEnd.EnableControl(true);
        timeLine.SetActive(false);
        munk.SetActive(false);
        startGameCanvas.SetActive(true);
    }

    void OnDestroy()
    {
        playableDirector.stopped -= OnTimelineStopped; // Bo su kien
        skipButton.onClick.RemoveListener(SkipCutscene); //// Bo su kien nut
    }
}
