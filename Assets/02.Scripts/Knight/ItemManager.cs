using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public Button inventoryButton;

    [SerializeField] private GameObject[] items;

    [SerializeField] private Transform slotGroup;
    public Slot[] slots;

    private void Start()
    {
        // 자신과 자식 중에서 Slot Component가 있는 대상을 모두 가져오는 기능
        // true를 넣으면 off되어있는 것들까지 가져옴
        slots = slotGroup.GetComponentsInChildren<Slot>(true);

        //인벤토리 버튼을 눌렀을 때 oninventory 함수 실행
        inventoryButton.onClick.AddListener(OnInventory);
    }

    public void OnInventory()
    {
        //GameObject.activeSelf -> 현재 Active 상태
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void DropItem(Vector3 dropPos)
    {
        // 랜덤 아이템 설정
        var randomIndex = Random.Range(0, items.Length);

        //item을 랜덤으로 생성하는 기능
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        //item을 랜덤한 방향으로 힘을 가하는 기능
        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        //item을 랜덤한 회전으로 힘을 가하는 기능
        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        foreach (var slot in slots) // 모든 슬롯에 대해
        {
            if(slot.isEmpty)
            {
                slot.AddItem(item);
                break;
            }
        }
    }
}
