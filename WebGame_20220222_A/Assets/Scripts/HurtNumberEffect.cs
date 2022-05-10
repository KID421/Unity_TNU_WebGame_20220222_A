using UnityEngine;
using UnityEngine.UI;
using System.Collections;   // �ޥ� �t��.���X�]��Ƶ��c�B��P�{�ǡA����ɶ�)

namespace KID
{
    /// <summary>
    /// ���˼ƭȮĪG
    /// �H�J�H�X�B��j�Y�p�B�첾
    /// </summary>
    public class HurtNumberEffect : MonoBehaviour
    {
        [SerializeField, Header("�H�J�H�X�C�@����"), Range(0, 0.3f)]
        private float valueFade = 0.1f;
        [SerializeField, Header("��j�Y�p�C�@����"), Range(0, 0.1f)]
        private float valueScale = 0.001f;
        [SerializeField, Header("�첾�C�@����"), Range(0, 10)]
        private float valueOffset = 0.1f;

        private CanvasGroup group;
        private RectTransform rect;
        private Text textDamage;

        private void Awake()
        {
            textDamage = transform.Find("�ˮ`��").GetComponent<Text>();
        }

        private void Start()
        {
            // �Ұʨ�P�{��(��P�{�Ǥ�k())
            // StartCoroutine(Test());

            group = GetComponent<CanvasGroup>();
            rect = GetComponent<RectTransform>();

            #region ��P�{��
            StartCoroutine(Fade());
            StartCoroutine(Scale());
            StartCoroutine(Offset());

            StartCoroutine(Fade(-1, 1f));
            StartCoroutine(Scale(-1, 1f));
            StartCoroutine(Offset(-1, 1f));
            #endregion
        }

        /// <summary>
        /// ��s�ˮ`��
        /// </summary>
        /// <param name="getDamage">���o�ˮ`��</param>
        public void UpdateDamage(float getDamage)
        {
            textDamage.text = getDamage.ToString();
        }

        // ��P�{�Ǥ�k
        // �Ǧ^���������O IEnumerator
        private IEnumerator Test()
        {
            print("�ڬO�Ĥ@��");

            // ���B �Ǧ^ ���ݬ��
            yield return new WaitForSeconds(2);

            print("�@���A�ڬO�ĤG��");
        }

        /// <summary>
        /// �H�J�H�X
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
        /// �Y��
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
        /// �첾
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
