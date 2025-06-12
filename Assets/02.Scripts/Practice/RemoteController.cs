using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    
    public GameObject videoScreen;
    public Button[] buttonUI;
    public VideoClip[] clips; // 영상 파일 배열
    private VideoPlayer videoPlayer;

    public int currClipIndex = 0; // 현재 영상 Index


    //public bool isOn = false;
    public bool isMute = false;

    private void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[currClipIndex]; // default 영상 설정
    }

    private void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }

    public void OnScreenPower()
    {

        /* NOT을 활용하여 줄여서 적은 방법.
        if (!isOn)
        {
            videoScreen.SetActive(true);
            isOn = true;
        }
        else
        {
            videoScreen.SetActive(false);
            isOn = false;
        }
        

        코드 줄이기 2///////////////
        isOn = !isOn;
        videoScreen.SetActive(isOn);

        */

        //더 줄이기 GameObject 속성을 활용하여 적은 방법
        videoScreen.SetActive(!videoScreen.activeSelf);
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute); // 영상의 소리 음소거

        //현재 영상의 Mute속성을 활용한 방법
        videoPlayer.SetDirectAudioMute(0, !videoPlayer.GetDirectAudioMute(0));
    }

    public void OnNextChannel() // 오른쪽 버튼
    {
        currClipIndex++;
        if (currClipIndex > clips.Length - 1)
            currClipIndex = 0;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    public void OnPrevChannel() // 왼쪽 버튼
    {
        currClipIndex--;
        if (currClipIndex < 0)
            currClipIndex = clips.Length - 1;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    /*
    public void OnChangeChannel(bool isNext)
    {
        int value = isNext ? 1 : -1;
        if(isNext)
        {
            currClipIndex++;
            if (currClipIndex > clips.Length - 1)
                currClipIndex = 0;
        }
        else
        {
            currClipIndex--;
            if (currClipIndex < 0)
                currClipIndex = clips.Length - 1;
        }

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }
    */
}
