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
        // Kiểm tra xem đối tượng có tồn tại không trước khi gọi phương thức
        if (player != null)
        {
            player.EnableControl(true);
        }

        if (timeEnd != null)
        {
            timeEnd.EnableControl(true);
        }

        if (timeLine != null)
        {
            timeLine.SetActive(false);
        }

        if (munk != null)
        {
            munk.SetActive(false);
        }

        if (startGameCanvas != null)
        {
            startGameCanvas.SetActive(true);
        }
    }

    void OnDestroy()
    {
        playableDirector.stopped -= OnTimelineStopped; // Bo su kien
        skipButton.onClick.RemoveListener(SkipCutscene); //// Bo su kien nut
    }
}
