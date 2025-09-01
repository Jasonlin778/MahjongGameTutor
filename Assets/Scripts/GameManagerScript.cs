// 1 - 3 行為引用函式庫要寫的東西
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
   多行註解
*/
// 單行註解

public class GameManagerScript : MonoBehaviour
{

    // 宣告一個資料型別為GameObject的變數，命名為mahjong
    public GameObject majhong;

    // Start is called before the first frame update
    // start這個功能會在update的第一幀前被呼叫執行
    void Start()
    {
        // Instantiate(遊戲物件)：生成一個遊戲物件
        Instantiate(majhong);
        Debug.Log("執行start");
    }

    // Update is called once per frame
    // update這個功能每一幀會被呼叫執行一次
    void Update()
    {
        Debug.Log("執行update");
    }
}
