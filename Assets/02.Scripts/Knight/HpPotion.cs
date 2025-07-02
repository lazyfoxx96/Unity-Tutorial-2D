using UnityEngine;

public class HpPotion : MonoBehaviour, IItemObject
{
    public GameObject Obj { get; set; }
    public string ItemName { get; set; }
    public Sprite Icon { get; set; }
    public ItemManager Inventory { get; set; }

    void Start()
    {
        Inventory = FindFirstObjectByType<ItemManager>();

        Obj = gameObject;
        ItemName = name;
        Icon = GetComponent<SpriteRenderer>().sprite;
    }

    public void Get()
    {
        gameObject.SetActive(false);

        Inventory.GetItem(this);
    }

    public void Use()
    {
        Debug.Log("Hp포션 사용");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }
}
