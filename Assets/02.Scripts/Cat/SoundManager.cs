using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource audioSource;
        public AudioClip bgmClip;
        public AudioClip jumpClip;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            SetBGMSound();
        }

        public void SetBGMSound()
        {
            audioSource.clip = bgmClip; // 오디오 소스 사운드 파일 설정
            audioSource.playOnAwake = true; //시작할때 자동 재생
            audioSource.loop = true; // 자동 반복 기능

            audioSource.volume = 0.01f; // 음량
            audioSource.Play(); // 시작
        }

        /// <summary>
        ///playOneShot을 쓰게되더라도 임시로 쓰는거기때문에
        ///메인사운드는 끊기지 않는다.
        /// </summary>
        public void OnJumpSound()
        {
            //이벤트 사운드
            audioSource.PlayOneShot(jumpClip);
        }

    }
}


