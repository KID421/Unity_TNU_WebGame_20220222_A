using UnityEngine;
using System.Collections;   // �ޥ� �t��.���X�]��Ƶ��c�B��P�{�ǡA����ɶ�)

namespace KID
{
    /// <summary>
    /// ���˼ƭȮĪG
    /// �H�J�H�X�B��j�Y�p�B�첾
    /// </summary>
    public class HurtNumberEffect : MonoBehaviour
    {
        private CanvasGroup group;

        private void Start()
        {
            // �Ұʨ�P�{��(��P�{�Ǥ�k())
            StartCoroutine(Test());
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
    }
}

