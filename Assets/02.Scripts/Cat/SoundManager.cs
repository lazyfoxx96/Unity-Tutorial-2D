using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip introBgmClip;
        public AudioClip playBgmClip;
        public AudioClip jumpClip;
        public AudioClip colliderClip;

        public void SetBGMSound(string bgmName)
        {
            if(bgmName == "Intro")
            {
                audioSource.clip = introBgmClip; // 오디오 소스 사운드 파일 설정
            }
            else if(bgmName == "Play")
            {
                audioSource.clip = playBgmClip; // 오디오 소스 사운드 파일 설정
            }
            
            audioSource.playOnAwake = true; //시작할때 자동 재생
            audioSource.loop = true; // 자동 반복 기능

            audioSource.volume = 0.05f; // 음량
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

        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip);
        }

    }
}


