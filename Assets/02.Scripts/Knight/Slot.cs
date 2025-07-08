using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private IItemObject item; // 슬롯에 들어올 아이템
    public Image itemImage; // 먹은 아이템의 이미지가 들어갈곳
    public Button slotButton; //아이템 Use()를 하기위한 버튼

    public bool isEmpty = true;

    private void Awake()
    {
        slotButton = GetComponent<Button>();

        slotButton.onClick.AddListener(UseItem);
        itemImage = transform.GetChild(0).GetComponent<Image>();
    }

    private void OnEnable()
    {
        //if(isEmpty) // 슬롯이 비어있을때
        //{
        //    slotButton.interactable = false;
        //    itemIcon.gameObject.SetActive(false);
        //}
        //else // 슬롯이 차있을 때
        //{
        //    slotButton.interactable = true;
        //    itemIcon.gameObject.SetActive(true);
        //}

        //위의 내용을 줄이면 아래 두줄로 줄일수있음
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }

    public void AddItem(IItemObject newItem)
    {
        item = newItem;
        isEmpty = false;
        itemImage.sprite = newItem.Icon;
        itemImage.SetNativeSize();
    }

    public void UseItem()
    {
        if(item != null )
        {
            item.Use();
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }
}
