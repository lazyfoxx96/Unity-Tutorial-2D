using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{
    private MeshRenderer renderer;
    public float offsetSpeed = 0.1f;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        //변경된 offset값
        Vector2 offset = Vector2.right * offsetSpeed * Time.deltaTime;

        //Texture의 Offset을 적용하겠다.      Base Map
        renderer.material.SetTextureOffset("_MainTex", renderer.material.mainTextureOffset + offset);
    }
}
