using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UnityEngine.UI：遊戲引擎，跟Unity的使用者介面有關
using TMPro; // 跟TextMeshPro文字顯示有關，也很常用到

public class UIMahjongScript : MonoBehaviour
{
    public float dy = 50;
    private float choosey = -350;
    public float originaly = -400;
    public GameObject mahjong;
    public GameObject gameManager;
    // 任何腳本的名稱也可以作為資料型別使用，用來存取腳本
    public GM GMScript;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject GameObject.Find(string name)：參數傳入想搜尋的名字，便會回傳該物件，但沒找到會回傳NULL

        // 好好想一下為什麼，不會就問AI
        // 以下這兩段程式的gameManagerScript都會得到一樣的結果，因為gameManger可以拆開包裝
        gameManager = GameObject.Find("GameManager");
        GMScript = gameManager.GetComponent<GM>();

        GMScript = GameObject.Find("GameManager").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        // 不是不行，但是Find這個行為會遍歷所有的物件，若每一幀都遍歷的話會很卡很花時間
        //gameManager = GameObject.Find("GameManager");
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

        // 應該要把這段程式放在GM中執行
        Debug.Log("OnMouseUpAsButton，滑鼠在此點擊後放開");
        // GameObject, Transform 為資料型別
        // this.gameObject == gameObject：此遊戲物件
        // this.transform == transform：此物件的空間狀態(transform component)
        int n = GMScript.playTime;
        Debug.Log("這是我打出的第 "+ n + " 張牌");
        Vector3 pos = new Vector3(-0.75f + n % 6 * 0.3f, -0.85f, -1.2f - n / 6* 0.4f);
        GameObject mah = Instantiate(mahjong, pos, Quaternion.Euler(90, 0, 0));

        n++; // 沒有意義，因為n是局部變數，沒辦法影響到GMScript當中的playTime
        GMScript.playTime++;
        //把字複製貼上
        mah.transform.GetChild(2).GetComponent<TextMeshPro>().text = transform.GetChild(2).GetComponent<TextMeshPro>().text;

        Destroy(gameObject);
        // 以下的敘述與 Destroy(gameObject) 相同，供參考
        // Destroy(this.gameObject);
        // Destroy(this.transform.gameObject.transform.gameObject.transform.gameObject)
        // 意義：我們取得了transform的變數時，就可以取得其相對應的gameObject
        // 意義：我們取得了gameObject的變數時，就可以取得其相對應的transform
    }
}
