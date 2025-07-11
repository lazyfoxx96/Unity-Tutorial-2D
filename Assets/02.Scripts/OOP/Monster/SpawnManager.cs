using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //이미 정해진 개수가 있는 경우
    [SerializeField] private GameObject[] monsters;

    private List<Monster> monsterList = new List<Monster>();

    [SerializeField] private GameObject[] items;

    //[SerializeField] private GameObject coinPrefab;

    //n초마다 몬스터를 랜덤으로 생성하는 기능
    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);

            var randomIndex = Random.Range(0, monsters.Length);
            var randomX = Random.Range(-8f, 8f);
            var randomY = Random.Range(-3f, 5f);

            var createPos = new Vector3(randomX, randomY, 0);

            //몬스터를 생성하는 기능
            GameObject monster = Instantiate(monsters[randomIndex], createPos, Quaternion.identity);

            //monsterList.Add(monster.GetComponent<Monster>());
            //Debug.Log($"현재 몬스터 수 : {monsterList.Count}");

            //int ranDir = Random.Range(0,2) > 0 ? 1 : -1;

            //monster.GetComponent<Monster>().Dir = ranDir;
            //Debug.Log($"ㅇㅅㅇ{ranDir}");
            //monster.GetComponent<Monster>().SetFlip(ranDir);
            //Debug.Log("ㅇㅅㅇ4");
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);

        //item을 랜덤으로 생성하는 기능
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }
}
