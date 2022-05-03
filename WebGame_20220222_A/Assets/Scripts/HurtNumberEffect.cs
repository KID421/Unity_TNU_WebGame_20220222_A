using UnityEngine;
using System.Collections;   // 引用 系統.集合（資料結構、協同程序，控制時間)

namespace KID
{
    /// <summary>
    /// 受傷數值效果
    /// 淡入淡出、放大縮小、位移
    /// </summary>
    public class HurtNumberEffect : MonoBehaviour
    {
        private CanvasGroup group;

        private void Start()
        {
            // 啟動協同程序(協同程序方法())
            StartCoroutine(Test());
        }

        // 協同程序方法
        // 傳回類型必須是 IEnumerator
        private IEnumerator Test()
        {
            print("我是第一行");

            // 讓步 傳回 等待秒數
            yield return new WaitForSeconds(2);

            print("一秒後，我是第二行");
        }
    }
}

