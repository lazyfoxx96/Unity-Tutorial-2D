using System.Collections;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    public enum InteractionType { SIGN, DOOR, NPC }
    public InteractionType type;

    public SoundController soundController;

    public GameObject popUp;

    public HouseFadeRoutine fade;

    public GameObject map;
    public GameObject house;

    public Vector3 inDoorPos;
    public Vector3 outDoorPos;
    public bool isHouse;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interaction(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUp.SetActive(false);
        }
    }

    void Interaction(Transform player)
    {
        switch (type)
        {
            case InteractionType.SIGN:
                popUp.SetActive(true);
                break;
            case InteractionType.DOOR:
                StartCoroutine(DoorRoutine(player));
                break;
            case InteractionType.NPC:
                popUp.SetActive(true);
                break;
        }
    }

    IEnumerator DoorRoutine(Transform player)
    {
        soundController.EventSoundPlay("Open Door");

        if(!isHouse)
            soundController.BgmSoundPlay("House BGM");
        else
            soundController.BgmSoundPlay("Town BGM");

        yield return StartCoroutine(fade.Fade(3f, Color.black, true));

        map.SetActive(isHouse);
        house.SetActive(!isHouse);

        var pos = isHouse ? outDoorPos : inDoorPos;
        player.transform.position = pos;

        isHouse = !isHouse;

        soundController.EventSoundPlay("Close Door");
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(fade.Fade(3f, Color.black, false));
    }
}
