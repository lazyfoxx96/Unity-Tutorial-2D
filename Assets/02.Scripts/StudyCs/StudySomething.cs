using UnityEngine;

public class StudySomething : MonoBehaviour
{
    public int currentLevel = 10;

    public int maxLevel = 99;

    void Start()
    {
        bool isMax = currentLevel >= maxLevel;

        Debug.Log($"현재 레벨은 만렙이 {isMax}입니다.");

        string msg = currentLevel >= maxLevel ? "현재 만렙입니다." : "현재 만렙이 아닙니다.";

        Debug.Log(msg);
    }
}
