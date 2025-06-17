using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    public StudyProperty studyProperty;

    private void Start()
    {
        //int num1 = studyProperty.number1;
        int num1 = studyProperty.Number1;
        studyProperty.Number1 = 100;

        int num2 = studyProperty.Number2;
        studyProperty.Number2 = 200;

        int num3 = studyProperty.Number3;
        //studyProperty.Number3 = 300;
    }
}
