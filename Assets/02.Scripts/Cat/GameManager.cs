using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager SoundManager;
        public TextMeshProUGUI playTimeUI;
        public TextMeshProUGUI scoreUI;

        private static float timer;
        public static int score; // 사과를 먹은 개수
        public static bool isPlay;

        private void Start()
        {
            SoundManager.SetBGMSound("Intro");
        }

        private void Update()
        {
            if (!isPlay) return;

            timer += Time.deltaTime;

            //playTimeUI.text = string.Format("플레이 시간 : {0:F1}초", timer);
            playTimeUI.text = $"플레이 시간 : {timer:F1}초";
            scoreUI.text = $"X {score}";
        }

        public static void ResetPlayUI()
        {
            timer = 0f;
            score = 0;
        }
    }
}
