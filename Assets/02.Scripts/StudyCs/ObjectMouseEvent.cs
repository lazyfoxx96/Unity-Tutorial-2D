using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    //마우스가 오브젝트에 닿는순간
    private void OnMouseEnter()
    {
        Debug.Log("Mouse enter");
    }

    //마우스가 콜라이더 위 영역을 돌아다니고있으면 over
    private void OnMouseOver()
    {
        Debug.Log("Mouse Over");
    }

    //마우스를 클릭하면
    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
    }

    //클릭을 유지하면
    private void OnMouseDrag()
    {
        Debug.Log(Input.mousePosition);

        Debug.Log("Mouse Drag");
    }

    //마우스를 땠을때
    private void OnMouseUp()
    {
        Debug.Log("Mouse up");
    }

    //마우스를 콜라이더 안에서 땟을때
    private void OnMouseUpAsButton()
    {
        Debug.Log("Mouse UpAsButton");
    }

    //마우스가 오브젝트를 나가면
    private void OnMouseExit()
    {
        Debug.Log("Mouse exit");
    }
}
