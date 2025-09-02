// 2 - 4 行為引用函式庫要寫的東西
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
   多行註解 (僅作為說明用)
*/
// 單行註解 (僅作為說明用)

// 一個類別，他就是一個物件
public class GameManagerScript : MonoBehaviour
{

    // 宣告一個資料型別為GameObject的變數，命名為mahjong
    public GameObject majhong;

    // Start is called before the first frame update
    // start這個功能會在update的第一幀的畫面前被呼叫執行
    void Start()
    {

        // Instantiate(遊戲物件)：是一個函式，給他一個遊戲物件(GameObject)後，能生成一個遊戲物件
        // Instantiate(majhong);


        // 生出一排麻將
        // 中心位置的座標為(0 , -0.95, -3.8)   8中8 = 17
        // 最左的麻將座標為(0 - (0.3 * 8) , -0.95, -3.8) = ( -2.4 , -0.95 , -3.8)
        // 最左數來第二個麻將座標為 (-2.1 , -0.95 , -3.8 )
        // 最左數來第三個麻將座標為 (-1.8 , -0.95 , -3.8 )
        // 最右邊的麻將座標為 (2.4 , -0.95 , -3.8 )

        // 數值為小數時，需要在數字的結尾加入後綴詞'f'，才能告訴系統說你宣告的數字是小數
        // new Vector3(x, y, z) 為宣告座標的方式
        // Quaternion.Euler(x, y, z) 或是 Quaternion.Euler(new Vector3(x, y, z))
        // 例如 Instantiate(majhong, new Vector3(-2.4f, -0.95f, -3.8f), Quaternion.Euler(270, 0 , 0));
        /* for 迴圈寫法
         
          for( 初始條件 ; 結束條件 ; 遞進內容) {
            }
        */
        // 資料型別整數：int
        /* A = B 代表把右邊的東西計算完後儲存在左邊的東西裡
         * 例如 i = i + 1
         * 當i = 0時，先計算右邊的東西 i + 1 = 1
         * 接下來，把右邊的東西儲存在左邊，i = 1
         * 因此，i 在執行完 i = i + 1後，i = 1
        */

        // i++的意思：i加1

        for (int i = 0; i < 17; i++)
        {
            //這個功能可以傳一個字串進去
            //字串可以做加法，沒有減法

            //自己
            Instantiate(majhong, new Vector3(-2.4f + (i * 0.3f), -0.95f, -3.8f), Quaternion.Euler(270, 0, 0));
            Instantiate(majhong, new Vector3(-2.4f + (i * 0.3f), -0.75f, -3.8f), Quaternion.Euler(270, 0, 0));

            //上家
            Instantiate(majhong, new Vector3(-3.8f, -0.95f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0));
            Instantiate(majhong, new Vector3(-3.8f, -0.75f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0));

            //對家
            Instantiate(majhong, new Vector3(-2.4f + (i * 0.3f), -0.95f, 3.8f), Quaternion.Euler(270, 0, 0));
            Instantiate(majhong, new Vector3(-2.4f + (i * 0.3f), -0.75f, 3.8f), Quaternion.Euler(270, 0, 0));

            //下家
            Instantiate(majhong, new Vector3(3.8f, -0.95f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0));
            Instantiate(majhong, new Vector3(3.8f, -0.75f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0));
            Debug.Log("第" + i + "次迴圈");
        }

        Debug.Log("執行start");
    }

    // Update is called once per frame
    // update這個功能每一幀的畫面會被呼叫執行一次
    void Update()
    {
        Debug.Log("執行update");
    }
}
