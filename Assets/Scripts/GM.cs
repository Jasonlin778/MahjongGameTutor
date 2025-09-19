// 6 - 8 行為引用函式庫要寫的東西，不要碰
// 讓腳本運行需要一些功能，而這些功能不是憑空而生
// 我們需要引用功能庫才可以使用這些功能，讓系統知道你要用的功能有哪些、在哪裡
// 這是最基本的部分，我們把這些事稱為引用函式庫
// 寫法：using [你要引用的函式庫];
using System.Collections; // System：系統，跟背景系統有關的東西，但平常比較不會用到，可能是在檔案讀取跟寫入才會用到
using System.Collections.Generic;
using UnityEngine; // UnityEngine：遊戲引擎，跟Unity本身的基礎功能有關，最常用到
/*
   多行註解 (僅作為說明用)
   第一行
   第二行
   多行註解不能內嵌，例如/* *-/
*/
// 單行註解 (僅作為說明用)
// 程式需要編譯器編譯成執行檔後，才能執行。因為我們現在寫的程式是我們比較好看得懂的語言，而電腦機器只看得懂0和1，
// 所以我們需要一個媒人幫我們把看得懂的程式語言轉換成機器看得懂的語言，這就是為什麼我們需要編譯器
// 當編譯器看到兩條斜線(//)或是斜線星號(/*)時，編譯器會跳過，因此可以拿來寫註解，就不會有錯誤

// 一個類別，他就是一個物件
public class GM : MonoBehaviour
{

    // 宣告一個資料型別為GameObject(遊戲物件)的變數，命名為mahjong
    public GameObject majhong;
    public Vector3 secret = new Vector3(60.85f, 72.4f, 83.7f);
    public Transform mountain;

    // Start is called before the first frame update
    // start這個功能會在update的第一幀的畫面前被呼叫執行，也就是一開始會執行一次
    // 遊戲開始時或是這個物件剛生成時會執行一次
    // Start()這個功能是由UnityEngine這個函式庫提供的，因此沒有寫"using UnityEngine"的話就不會在第一幀的畫面前被呼叫執行
    void Start()
    {
        
        // Debug.Log("字串")：輸出指定的訊息至Unity的Console主控台中，可以用來除錯使用
        //這個功能可以傳一個字串進去
        //字串可以做加法，沒有減法
        Debug.Log("執行start");
    }

    // Update is called once per frame
    // update這個功能每一幀的畫面會被呼叫執行一次，也就是一秒大概執行大約60次
    void Update()
    {
        Debug.Log("執行update");
    }

    public void StartGame()
    {
        // function函式小括號內的東西叫做parameters參數
        // Instantiate(遊戲物件)：是一個函式，給他一個遊戲物件(GameObject)後，能生成一個遊戲物件
        // Instantiate(遊戲物件, 向量, 角度)：除了生成遊戲物件外，還能指定他的座標與旋轉角度
        // Instantiate(majhong);


        // 生出一排麻將
        // 中心位置的座標為(0 , -0.95, -3.8)   8中8 = 17
        // 最左的麻將座標為(0 - (0.3 * 8) , -0.95, -3.8) = ( -2.4 , -0.95 , -3.8)
        // 最左數來第二個麻將座標為 (-2.1 , -0.95 , -3.8 )
        // 最左數來第三個麻將座標為 (-1.8 , -0.95 , -3.8 )
        // 最右邊的麻將座標為 (2.4 , -0.95 , -3.8 )

        // 數值為小數時，需要在數字的結尾加入後綴詞'f'，才能告訴系統說你宣告的數字是小數
        // 程式的運算只有小括號()，沒有中括號跟大括號，要換成小括號；乘號x跟除號÷要換成星星*跟斜線/
        // 數學寫法：[(2+3)x8-5]÷7、程式寫法：((2+3)*8-5)/7
        // new Vector3(x, y, z) 為宣告座標的方式，x,y,z都各填一個小數或整數就好
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

        // 把secret變數的z值輸出
        Debug.Log(secret.z);

        for (int i = 0; i < 17; i++)
        {
            // Instantiate(遊戲物件, 向量, 角度)：複製生成，除了生成遊戲物件外，還能指定他的座標與旋轉角度
            // 向量 Vector3：是一種資料型別，可以儲存3個float，依序為x,y,z

            //自己
            Instantiate(majhong, new Vector3(-2.4f + (i * 0.3f), -0.95f, -2.8f), Quaternion.Euler(270, 0, 0), mountain);
            Instantiate(majhong, new Vector3(-2.4f + (i * 0.3f), -0.75f, -2.8f), Quaternion.Euler(270, 0, 0), mountain);

            //上家
            Instantiate(majhong, new Vector3(-2.8f, -0.95f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0), mountain);
            Instantiate(majhong, new Vector3(-2.8f, -0.75f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0), mountain);

            //對家
            Instantiate(majhong, new Vector3(-2.4f + (i * 0.3f), -0.95f, 2.8f), Quaternion.Euler(270, 0, 0), mountain);
            Instantiate(majhong, new Vector3(-2.4f + (i * 0.3f), -0.75f, 2.8f), Quaternion.Euler(270, 0, 0), mountain);

            //下家
            Instantiate(majhong, new Vector3(2.8f, -0.95f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0), mountain);
            Instantiate(majhong, new Vector3(2.8f, -0.75f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0), mountain);
            Debug.Log("第" + i + "次迴圈");
        }
        mountain.rotation = Quaternion.Euler(0, 20, 0);
    }
}

// 我建立一個物件叫做老師

// 格式 (public 的意思是所有人可見的)
/*
public class [物品名稱] : MonoBehavior
{
    // 敘述的結尾都要加分號";"，有些是例外

    // 一個物品有很多功能，也有資料可以儲存

    // 儲存資料的方式：宣告變數：跟編譯器說我想創建一個變數使用
    // 我想要有一個可以儲存資料的抽屜，就這樣寫：
    (public) [資料型別] [變數名稱] (= [初始值]);
    // 複習 A = B：把右邊的值儲存在左邊的變數中(抽屜)
    // 不給予初始值也沒關係，可以在腳本中或是Unity中再給初始值
    // 如果變數沒有數值就直接用的話可能會有執行錯誤
    // 資料型別的種類(代表儲存的物件種類)
        // 1. GameObject：遊戲物件
        // 2. int：整數(原本的英文為integer 存12345678 ... )
        // 3. string：字串，可以儲存一段文字，可以是中文 (記得文字外面要用引號""夾住，例如 "Hello world")
        // 4. float：浮點數，小數 (記得數值後面要加f表示他是小數，例如、4是整數，4f、4.0f、4.222f是小數)
        // 5. Vector3：向量，可以儲存3個小數，分別為x,y,z
        // 6. Transform：一個物件在空間中的資訊，包含座標、旋轉角度、尺寸大小、親parent子child物件關係
                                                  父物件：parent object，子物件：child object
    // 變數的命名規則：
        // 1. 第一個字只能是大小寫英文A-Z a-z或是底線_
        // 2. 第二個字以後只能是大小寫英文A-Z a-z、數字0-9、底線_

    // 使用功能的方式：宣告函數：跟編譯器說我想為這個物件創建一個功能
    // 例如水壺這個物件可以提供喝水的功能；飲水機有三種功能，分別是提供冷溫熱水
    // 「簡易版」的功能寫法：
    (public) [回傳值，若無則填void] [函數名稱]( [參數，若無則不填] ){
        函式的功能
        return [回傳值，若無則不填];
    }
    // 你要知道的：
    (public/private) void [函數名字](){
        
    }
    // void：空白、無東西的
}

 */

// 舉例
/*
    // 我儲存的資料有這些：
 public class teacher : MonoBehavior
{
    學校：台大
    身高：179.9
    年齡：20
    學生：Eason
    三圍：60.85 , 72.4 , 83.7
    一個物品有很多功能，也有資料可以儲存

    // 把上述資料轉換成變數儲存
    public string school = "台大";
    public float height = 179.9f;
    public int age = 20;
    public string student = "Eason";
    public Vector3 secret = new Vector3( 60.85f, 72.4f , 83.7f);
    // new Vector3( 60.85f, 72.4f , 83.7f)代表建立一個新的向量物件儲存於變數secret中
    // 老師有兩個功能可以做，第一個：催促作業；第二個：計算學費
    // 函數命名習慣，每個單字的第一個字為大寫
    // 程式的寫法
    // 第一個：催促作業
    void Homework(){
        Debug.Log("記得要寫作業，不會的要問，不要壓死線喔！");
    }

    // 第二個：計算學費
    void Money(){
        Debug.Log("學費為：" + (800 * 2));
        //輸出內容：學費為：1600
    }

    以下的部分跟數學有關，數學的寫法
    f代表一個功能(函數)的名字
    f(x) = x + 3;
    f(1代表傳入的參數) = 4代表回傳值
}
 */
