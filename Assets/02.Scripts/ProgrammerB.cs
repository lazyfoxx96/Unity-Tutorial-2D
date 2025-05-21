using DevA;
using UnityEngine;

public class ProgrammerB : MonoBehaviour
{
    public ProgrammerA pA;
    //유니티에서는 이렇게 만들지않음.
    //유니티 하이라키에 이미 오브젝트가 만들어져있기때문에
    // new 를 통해 새로 생성해주지 않아도됨


    void Start()
    {
        //pA.number1 = 10;
        
        //public
        pA.number2 = 20;

        //pA.number3 = 30;

        //pA.number4 = 40;

        //pA.number5 = 50;
    }
}
