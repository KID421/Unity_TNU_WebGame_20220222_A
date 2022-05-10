using UnityEngine;
using UnityEngine.UI;
using System.Collections;   // 引用 系統.集合（資料結構、協同程序，控制時間)

namespace KID
{
    /// <summary>
    /// 受傷數值效果
    /// 淡入淡出、放大縮小、位移
    /// </summary>
    public class HurtNumberEffect : MonoBehaviour
    {
        [SerializeField, Header("淡入淡出每一次值"), Range(0, 0.3f)]
        private float valueFade = 0.1f;
        [SerializeField, Header("放大縮小每一次值"), Range(0, 0.1f)]
        private float valueScale = 0.001f;
        [SerializeField, Header("位移每一次值"), Range(0, 10)]
        private float valueOffset = 0.1f;

        private CanvasGroup group;
        private RectTransform rect;
        private Text textDamage;

        private void Awake()
        {
            textDamage = transform.Find("傷害值").GetComponent<Text>();
        }

        private void Start()
        {
            // 啟動協同程序(協同程序方法())
            // StartCoroutine(Test());

            group = GetComponent<CanvasGroup>();
            rect = GetComponent<RectTransform>();

            #region 協同程序
            StartCoroutine(Fade());
            StartCoroutine(Scale());
            StartCoroutine(Offset());

            StartCoroutine(Fade(-1, 1f));
            StartCoroutine(Scale(-1, 1f));
            StartCoroutine(Offset(-1, 1f));
            #endregion
        }

        /// <summary>
        /// 更新傷害值
        /// </summary>
        /// <param name="getDamage">取得傷害值</param>
        public void UpdateDamage(float getDamage)
        {
            textDamage.text = getDamage.ToString();
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

        /// <summary>
        /// 淡入淡出
        /// </summary>
        private IEnumerator Fade(float add = 1, float wait = 0)
        {
            yield return new WaitForSeconds(wait);

            for (int i = 0; i < 10; i++)
            {
                group.alpha += valueFade * add;
                yield return new WaitForSeconds(0.02f);
            }
        }

        /// <summary>
        /// 縮放
        /// </summary>
        private IEnumerator Scale(float add = 1, float wait = 0)
        {
            yield return new WaitForSeconds(wait);

            for (int i = 0; i < 5; i++)
            {
                rect.localScale += new Vector3(valueScale, valueScale, 0) * add;
                yield return new WaitForSeconds(0.02f);
            }
        }

        /// <summary>
        /// 位移
        /// </summary>
        private IEnumerator Offset(float add = 1, float wait = 0)
        {
            yield return new WaitForSeconds(wait);

            for (int i = 0; i < 10; i++)
            {
                rect.anchoredPosition += Vector2.up * valueOffset * add;
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}
