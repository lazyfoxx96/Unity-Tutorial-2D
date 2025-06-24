using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] turretPrefabs;

    private void OnMouseDown()
    {
        ///            생성할 대상          생성 위치        생성했을 때 회전 상태
        Instantiate(turretPrefabs[SetTile.turretIndex], transform.position, Quaternion.identity);
    }
}
