using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType { Pipe, Apple, Both };
    public ColliderType colliderType;

    public GameObject pipe;
    public GameObject apple;
    public GameObject particle;

    public float moveSpeed = 5f;
    public float returnPosX = 13f;
    public float randomPosY;

    private void Start()
    {
        //randomPosY = Random.Range(-8f, -5f);
        //transform.position = new Vector3(transform.position.x, randomPosY, 1);
        SetRandomSetting(transform.position.x);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
        {
            //randomPosY = Random.Range(-8f, -5f);
            //transform.position = new Vector3(returnPosX, randomPosY, 1);
            SetRandomSetting(returnPosX);
        }
    }

    private void SetRandomSetting(float posX)
    {
        randomPosY = Random.Range(-8f, -5f);
        transform.position = new Vector3(posX, randomPosY, 1);

        pipe.SetActive(false);
        apple.SetActive(false);
        particle.SetActive(false);

        colliderType = (ColliderType) Random.Range(0, 3);

        switch(colliderType)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;
            case ColliderType.Apple:
                apple.SetActive(true); 
                break;
            case ColliderType.Both:
                pipe.SetActive(true);
                apple.SetActive(true);
                break;
        }
    }
}
