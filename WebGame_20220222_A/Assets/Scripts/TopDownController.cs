using UnityEngine;      // 引用 Unity Engine 命名空間 (API)

namespace KID
{
    // 類別 (腳本) 名稱必須與左上角檔名完全相同，包含大小寫，檔名不能有空格或特殊字元
    /// <summary>
    /// 上下類型角色控制器
    /// 控制移動、動畫更新
    /// </summary>
    public class TopDownController : MonoBehaviour
    {
        #region 資料：保存系統需要的資料，例如移動速度、動畫參數名稱或元件等資料
        // 欄位語法：修飾詞 資料類型 欄位名稱 (指定 預設值)；
        // [] 屬性 Attritube
        // SerializeField 序列化欄位 - 欄位可視化 (出現在屬性面板 Inspector)
        // Header 標題
        // Range 範圍：※ 僅適用於數值類型資料，int、float
        [SerializeField, Header("移動速度"), Range(0, 500)]
        private float speed = 1.5f;
        private string parameterRun = "開關跑步";
        private string parameterDead = "開關死亡";
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float v;
        #endregion

        #region 事件：程式的入口 (Unity)
        // 喚醒事件：播放遊戲時執行一次，處理初始值
        private void Awake()
        {
            // GetComponent<泛型>() - 泛型：指任何類型
            // 欄位 指定 取得元件<元件名稱>() - 取得指定元件存放於欄位
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }

        // 更新事件：約 60 FPS (Frame per second)
        // 取得輸入資料可在此事件處理
        private void Update()
        {
            GetInput();
            Move();
            Rotate();
        }
        #endregion

        #region 方法：較複雜的行為，例如移動功能、更新動畫
        // 方法語法：修飾詞 傳回資料類型 方法名稱 (參數) { 程式內容 }
        /// <summary>
        /// 取得輸入：水平與垂直
        /// </summary>
        private void GetInput()
        {
            // 使用靜態資料 static
            // 語法：類別名稱.靜態方法名稱 (對應引數)
            // Horizontal 水平軸向
            // 左：方向左鍵 與 A - 傳回 -1
            // 右：方向右鍵 與 D - 傳回 +1
            // float h = ***; - 區域變數：僅能在此結構 (大括號) 內存取
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            // print() 輸出：將 () 內訊息輸出至 Unity Console 面板 (Ctrl + Shift + C)
            // print("水平軸向值：" + h);
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            // 使用非靜態資料 non-static
            // 語法：欄位名稱.非靜態屬性名稱
            rig.velocity = new Vector2(h, v) * speed;           // 剛體.加速度 = 二維向量 * 速度
            // 水平 不等於 零 或者 垂直 不等於 零
            ani.SetBool(parameterRun, h != 0 || v != 0);        // 動畫控制器.設定布林值(參數，布林值) - h 不等於 0 - 只要水平軸向不等於零 就勾選 跑步參數
        }

        /// <summary>
        /// 旋轉
        /// 往右移動，角度 Y 0
        /// 往左移動，角度 Y 180
        /// </summary>
        private void Rotate()
        {
            // 三元運算子 ? :
            // 語法：布林值 ? 布林值為 true : 布林值為 false
            // h > 0 ? 0 : 180 - 當水平值 大於等於零 值為 0，否則 值為 180
            transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0);
        }
        #endregion
    }
}
