using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    private Inventory inventory;

    public enum CoinType { Gold, Green, Blue }
    public CoinType coinType;

    public float price;

    public GameObject Obj { get; set; }

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        Obj = gameObject;
    }

    void OnMouseDown()
    {
        Get();
    }

    public void Get()
    {
        Debug.Log($"{this.name}을 획득했습니다.");
        inventory.AddItem( this );
        gameObject.SetActive( false );
    }
}
