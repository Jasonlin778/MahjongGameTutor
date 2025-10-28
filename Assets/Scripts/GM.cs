// 6 - 8 行為引用函式庫要寫的東西，不要碰
// 讓腳本運行需要一些功能，而這些功能不是憑空而生
// 我們需要引用功能庫才可以使用這些功能，讓系統知道你要用的功能有哪些、在哪裡
// 這是最基本的部分，我們把這些事稱為引用函式庫
// 寫法：using [你要引用的函式庫];
using System.Collections; // System：系統，跟背景系統有關的東西，但平常比較不會用到，可能是在檔案讀取跟寫入才會用到
using System.Collections.Generic;
using UnityEngine; // UnityEngine：遊戲引擎，跟Unity本身的基礎功能有關，最常用到
using UnityEngine.UI; // UnityEngine.UI：遊戲引擎，跟Unity的使用者介面有關
using TMPro; // 跟TextMeshPro文字顯示有關，也很常用到

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
    //如果宣告的變數要給本腳本所有功能、函式、函數使用的話，要宣告在這裡，宣告物件的大括號當中

    // 宣告一個資料型別為GameObject(遊戲物件)的變數，命名為mahjong
    public GameObject mahjong;
    public GameObject mahjongUI;
    public Vector3 secret = new Vector3(60.85f, 72.4f, 83.7f);
    public Transform mountain;
    public Transform playerHandTransform;
    public int[] order = new int[136]; // 宣告一個長度為136的整數陣列
    public int[] playerHand = new int[20]; // 數字設置20只是為了保留一點空間
    // 0 - 3 : 1m
    // 4 - 7 : 2m
    // 陣列宣告方式
    // (public) [資料型別][] [變數名稱] = new [資料型別][陣列大小];

    // Start is called before the first frame update
    // start這個功能會在update的第一幀的畫面前被呼叫執行，也就是一開始會執行一次
    // 遊戲開始時或是這個物件剛生成時會執行一次
    // Start()這個功能是由UnityEngine這個函式庫提供的，因此沒有寫"using UnityEngine"的話就不會在第一幀的畫面前被呼叫執行
    void Start()
    {
        // != 就是不等於
        // i != 136
        // i < 136
        // !(i == 136)

        //當i = 0的時候，就讓order的第0個變數存入0
        //當i = 1的時候，就讓order的第1個變數存入1
        //當i = 2的時候，就讓order的第2個變數存入2
        //...
        //公式(迴圈規則)當i = n的時候，就讓order的第n個變數存入n
        //迴圈的遞增寫法
        for (int i = 0; i != 136; i = i + 1)
        {
            // 取得陣列當中的特定變數
            // 變數名稱[索引值] = [算式(i+3)/常數(3)/變數(i)]
            order[i] = i;
            Debug.Log("order[" + i + "]=" + order[i]);
        }
        // 平均洗牌的簡單方式：有一串數列，長度為n。從最後一個數開始隨機跟一個在它之前或自己的數交換，
        // 有可能因為選中要交換的數是最後一個而不交換，從最後一個順序一路執行到第一個順序，如此一來此序列會被洗均勻
        // 迴圈的遞減寫法
        for (int i = 135; i >= 0; i--)
        {
            int j = Random.Range(0, i + 1);
            // 我們抽好要跟order[i]交換的順序了
            // order[i(從尾到頭)] 會跟 order[j(隨機)]
            int tmp = order[i]; // tmp : temporary (暫時的)
            order[i] = order[j];
            order[j] = tmp;
        }
        // minimum inclusive 包含最小值
        // maximum exclusive 不含最大值

        /* A = B 代表把右邊的東西計算完後儲存在左邊的東西裡

           B = 5
           A = 0
           A = B
           結果：
           A = 5 , B =5 
         */
        // 交換兩個變數的值？
        int a = 3;
        int b = 1;
        int c;
        c = a; // a = 3, b = 1, c = 3
        a = b; // a = 1, b = 1, c = 3
        b = c; // b = 3, a = 1, c = 3
        Debug.Log("a是" + a + "，b是" + b);
        //a = 1, b = 3

        // 排序完之後每個玩家要抓13張牌，不過需要建立一個轉換表
        // 讓玩家知道他摸到順序3的牌是1萬、順序6的牌是2萬，以此類推......
        // 呼叫函式：函式名稱(參數)
        // for 迴圈內容只有一行時也能縮約
        for (int i = 0; i < 13; i++)
        {
            Debug.Log("第" + i + "張牌的順序是：" + order[i] +
                "，牌面的字是：" + OrderToWord(order[i]));
            playerHand[i] = order[i];
            /*
            Vector3 pos = new Vector3(-870 + 130 * i, -400, 0);
            GameObject mah = Instantiate(mahjongUI, playerHandTransform);
            mah.transform.localPosition = pos;
            mah.transform.localScale = new Vector3(200 , 200 ,200);
            mah.transform.GetChild(2).GetComponent<TextMeshPro>().text = OrderToWord(order[i]);
            */
            // Instantiate也是一個函式，而函式可能會有回傳值(例如我們之前自訂的函式OrderToWord()會回傳字串)
            // 所以Instantiate有一個GameObject回傳值，我們可以用變數去儲存他
            // 只要知道遊戲物件，就可以取得他的transform
            // 只要取得遊戲物件的transform，就能更改他的transform的數值了(例如座標、旋轉角度等)
            // 遊戲物件名稱.transform 取得指定遊戲物件的transform component
            // 遊戲物件名稱.transform.rotation 代表指定遊戲物件的當前旋轉角度

            // 我們可以對transform做的更改：
            // transform.position = Vector3，更改以世界座標作為座標系的座標(不一定是螢幕上顯示的數值)
            // transform.rotation = Quaternion.Euler(Vector3)，更改旋轉角度

            // transform.localPosition = Vector3，更改以父物件作為標系的座標(也就是螢幕上顯示的數值)
            // transform.localRotation = Quaternion.Euler(Vector3)，更改旋轉角度
            // transform.localScale = 更改尺寸

            // mah.transform.GetChild(整數i) = 取得此物件的第i個子物件，以0開始編號
            // transform.GetComponent<資料型別>() = 取得此物件當中的某個資料型別的component
        }

        // 巢狀迴圈練習：99乘法表
        Debug.Log("99乘法表練習");
        for(int i = 1; i <= 9; i++)
        {
            for(int j = 1;j <= 9; j++)
            {
                Debug.Log(i + "*" + j + "=" + (i * j));
            }
        }

        // 巢狀迴圈練習：印出奇數金字塔星星
        // Debug.Log(s)不能放在以下註解的地方 //
        for(int i = 1; i <= 5; i++)
        {
            // s還沒有被宣告就使用了，編譯錯誤
            string s = "";
            // s只是空字串，連星星都還沒加，所以每次都會印出""
            for(int j = 1; j <= 2 * i - 1; j++)
            {
                s = s + "*";
                
                // 每次s加上一個星星時，就印出來，這樣會印出1+3+5+7+9=25行星星
            }
            Debug.Log(s);// 正確選擇。字串被宣告後，星星也加完了，就能正常輸出

            // 每次迴圈執行完時，在迴圈中宣告的所有變數的紀錄會遺失
        }
        // 希望你們學會回圈當中的終止條件、起始條件的變動，並非每次都固定值
        // 順序問題，一段程式到底該放在迴圈中的什麼位置，不同位置都可能會有差異很大的結果
        // 無論裡面的程式怎麼寫，執行結果如何，我希望你們都能用回圈一次次分析的方式告訴我為何執行結果會長那樣

        // 作業，詢問AI後跟我解釋這段程式碼在做什麼
        // 選擇排序
        // 固定要交換的最大值的位置
        for (int i = 12; i >= 0; i--)
        {
            // 對於還沒有排序好的數字當中挑選最大值
            int max = -1; // max：當前尋找範圍中的最大值
            int index = -1; // index：當前尋找範圍中的最大值之索引值
            // 尋找最大值的範圍會隨著i改變範圍
            for (int j = 0; j <= i; j++)
            {
                // if(選擇條件){}：如果選擇條件的結果是正確的，就執行大括號裡面的內容，否則就不執行
                if (playerHand[j] > max)
                {
                    max = playerHand[j];
                    index = j;
                }
            }
            // playerHand[index], playerHand[i] 交換位置
            // 請仔細思考為什麼只要寫兩行就好，我在交換過程中的暫存變數是誰？max
            playerHand[index] = playerHand[i];
            playerHand[i] = max;
        }

        for(int i = 0; i < 13; i++)
        {
            Vector3 pos = new Vector3(-870 + 130 * i, -400, 0);
            GameObject mah = Instantiate(mahjongUI, playerHandTransform);
            mah.transform.localPosition = pos;
            mah.transform.localScale = new Vector3(200, 200, 200);
            mah.transform.GetChild(2).GetComponent<TextMeshPro>().text = OrderToWord(playerHand[i]);
        }
        // Debug.Log("字串")：輸出指定的訊息至Unity的Console主控台中，可以用來除錯使用
        //這個功能可以傳一個字串進去
        //字串可以做加法，沒有減法
        Debug.Log("執行start");
    }

    // Update is called once per frame
    // update這個功能每一幀的畫面會被呼叫執行一次，也就是一秒大概執行大約60次
    void Update()
    {

        //Debug.Log("執行update");
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
            Instantiate(mahjong, new Vector3(-2.4f + (i * 0.3f), -0.95f, -2.8f), Quaternion.Euler(270, 0, 0), mountain);
            Instantiate(mahjong, new Vector3(-2.4f + (i * 0.3f), -0.75f, -2.8f), Quaternion.Euler(270, 0, 0), mountain);

            //上家
            Instantiate(mahjong, new Vector3(-2.8f, -0.95f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0), mountain);
            Instantiate(mahjong, new Vector3(-2.8f, -0.75f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0), mountain);

            //對家
            Instantiate(mahjong, new Vector3(-2.4f + (i * 0.3f), -0.95f, 2.8f), Quaternion.Euler(270, 0, 0), mountain);
            Instantiate(mahjong, new Vector3(-2.4f + (i * 0.3f), -0.75f, 2.8f), Quaternion.Euler(270, 0, 0), mountain);

            //下家
            Instantiate(mahjong, new Vector3(2.8f, -0.95f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0), mountain);
            Instantiate(mahjong, new Vector3(2.8f, -0.75f, -2.4f + (i * 0.3f)), Quaternion.Euler(270, 0, 0), mountain);
            Debug.Log("第" + i + "次迴圈");
        }
        mountain.rotation = Quaternion.Euler(0, 20, 0);
    }

    // 宣告並建構一個自訂函式，給定順序這個參數，便能回傳他對應的牌面的字
    // 例如：傳入0，回傳"1m"
    public string OrderToWord(int order)
    {
        // 萬1m ... 9m
        // 餅1p ... 9p
        // 索1s ... 9s
        // 字1w ... 7w

        // 1 ... 3 有3個數，也就是說有3 - 1 + 1 = 3個數，+1是必要的
        // 4 ... 10 有7個數，也就是說有10 - 4 + 1 = 7個數，+1是必要的
        // 舉例：如果我的輸入是0或1或2或3，這個函式要回傳"1m"
        // 舉例：如果我的輸入是4或5或6或7，這個函式要回傳"2m"
        // ... 萬共36張牌 從0到35 (35 - 0 + 1 = 36張牌=>正確
        // 舉例：如果我的輸入是36或37或38或39，這個函式要回傳"1p"
        // ... 餅共36張牌 從36到71 (72 - 36 + 1 = 37張牌=>????
        // ... 索共36張牌 從72到107 (107 - 72 + 1 = 37張牌=>????
        // ... 字共28張牌 從108到135 (135 - 110 + 1 = 26張牌=>????

        // 給定一個數order
        // 0 ≤ order ≤ 35，萬m
        // 36 ≤ order ≤ 71，餅p
        // 72 ≤ order ≤ 107，索s
        // 108 ≤ order ≤ 135，字w

        // 那數字呢？
        //  0 ≤ order ≤ 35
        //  m(x) = x/4+1
        //  除法規則：餘數捨棄。(1(整數) / 4(整數) = 0 ... 1 = 0(程式運算的結果) ≠ 0.25)
        //  x = 0 ... 3 , f(x) = 1
        //  x = 4 ... 7 , f(x) = 2
        //  ...
        //  x = 32 ... 35 , f(x) = 9
        

        // p(x) = (x - 36)/4 + 1
        // x = 36 ... 39 , f(x) = x - 9 + 1 = x - 8
        // 括號規則：被最多括號包含的優先運算，只有小括號

        // s(x) = (x - 72)/4 + 1
        // w(x) = (x - 108)/4 + 1

        // if else (if)選擇結構
        // 用處：當你的程式碼需要在符合特定條件下才執行時才使用
        // * else 代表條件不符合時執行的內容
        /* 寫法：
         * 
         * example 1:
         * if( 條件 ) {
         *      條件成真時，執行的內容...
         * }
         * 
         * example 2:
         * if( 條件 ) {
         *      條件成真時，執行的內容...
         * }else{
         *      條件不符合時，執行的內容...
         * }
         * 
         * example 3:
         * if( 條件1 ) {
         *      條件1成真時，執行的內容...
         * }else if( 條件2 ){
         *      條件1不符合且條件2成真時，執行的內容...
         * }else{
         *      條件1不符合且條件2不符合時，執行的內容...
         * }
         */
        // ==：相等
        // !=：不相等
        // >=：大於等於
        // <=：小於等於
        // >：大於
        // <：小於

        // 如果想節省空間，當選擇條件內容只有一行時，不需大括號
        // 正常寫法時選一種縮排方式，不要全部都用，比邪教還邪教
        if (order <= 35)
            // return [參數]
            // 回傳這個函式的答案，然後函式執行到此強制結束
            return (order / 4 + 1) + "\nm";
        else if( order <= 71) return ((order - 36) / 4 + 1) + "\np";
        else if (order <= 107)
            return ((order - 72) / 4 + 1) + "\ns";
        else
        {
            return ((order - 108) / 4 + 1) + "\nw";
        }

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
