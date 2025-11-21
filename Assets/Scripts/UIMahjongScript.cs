using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMahjongScript : MonoBehaviour
{
    public float dy = 50;
    private float choosey = -350;
    public float originaly = -400;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 只有物件在設置collider後，才能對這些onmouse ... 的函式有反應
    private void OnMouseDown()
    {
        // 測試用，只要我在console中看到這一行，就知道這個函式被觸發了
        Debug.Log("OnMouseDown，滑鼠在此點擊");
    }

    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag，滑鼠拖曳");

    }

    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter，滑鼠進入");

    }

    private void OnMouseExit()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, originaly, 0);
        Debug.Log("OnMouseExit，滑鼠離開");

        BoxCollider collider = GetComponent<BoxCollider>();
        collider.center = new Vector3(0f, 0f, 0.1f);
        collider.size = new Vector3(0.6f, 0.8f, 0.4f);
    }

    private void OnMouseOver()
    {
        // 錯誤寫法，請思考為什麼是錯的
        // transform.localPosition = transform.localPosition + new Vector3(0, dy, 0);
        transform.localPosition = new Vector3(transform.localPosition.x, choosey, 0);
        Debug.Log("OnMouseOver，滑鼠在上");


        BoxCollider collider = GetComponent<BoxCollider>();
        collider.center = new Vector3(0f, -0.1625f, 0.1f);
        collider.size = new Vector3(0.6f, 1.05f, 0.4f);
    }

    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp，滑鼠在此放開");
        // 錯誤寫法，請思考為什麼是錯的
        // transform.localPosition = new Vector3(transform.localPosition.x, originaly, 0);
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("OnMouseUpAsButton，滑鼠在此點擊後放開");
    }
}
