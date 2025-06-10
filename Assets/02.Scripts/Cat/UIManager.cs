using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager SoundManager;

        public GameObject playObj;
        public GameObject introUI;
        public GameObject playUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        private void Awake()
        {
            introUI.SetActive(true);
            playUI.SetActive(false);
            playObj.SetActive(false);
        }

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
        }

        public void OnStartButton() 
        {
            bool isNoText = inputField.text == "";

            if(isNoText)
            {
                Debug.Log("입력한 텍스트 없음");
            }
            else
            {
                Debug.Log($"{nameTextUI.text} 입력");
                //Text컴포넌트     //InputField컴포넌트
                nameTextUI.text = inputField.text;
                
                playObj.SetActive(true);
                playUI.SetActive(true);
                introUI.SetActive(false);

                GameManager.isPlay = true;
                SoundManager.SetBGMSound("Play");
            }
        } 
    }
}
