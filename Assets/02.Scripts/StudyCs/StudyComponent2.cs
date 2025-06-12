using UnityEngine;

public class StudyComponent2 : MonoBehaviour
{
    public GameObject obj;

    public Mesh mesh;
    public Material mat;

    void Start()
    {
        //   빈게임오브젝트 생성 -> 이름 변경
        //obj = new GameObject();
        //obj.name = "Cube";

        // CreateCube();

        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

        CreateCube("Hello World");
        CreateCube();
    }

    public void CreateCube(string name = "Cube")
    {
        obj = new GameObject(name);

        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = mesh;

        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;

        obj.AddComponent<BoxCollider>();
    }
}
