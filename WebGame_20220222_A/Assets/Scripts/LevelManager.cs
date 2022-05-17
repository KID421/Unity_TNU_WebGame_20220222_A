using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// ���ź޲z��
    /// ���šB�g��ȸ�Ƭɭ���s
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        [SerializeField, Header("�g���")]
        private Image imgExp;
        [SerializeField, Header("����")]
        private Text textLv;

        [SerializeField]
        private int exp;
        private int expMax;
        private int lv = 1;

        [SerializeField]
        private int[] expNeed;

        [SerializeField, Header("�n�ɯŪ��Z�����")]
        private DataWeapon dataWeapon;

        /// <summary>
        /// �]�w�g��ȻݨD
        /// </summary>
        [ContextMenu("Setting Exp Need")]
        private void SettingExpNeed()
        {
            expNeed = new int[99];

            for (int i = 0; i < expNeed.Length; i++)
            {
                expNeed[i] = (i + 1) * 100;
            }
        }

        /// <summary>
        /// ��o�g���
        /// </summary>
        /// <param name="getExp">��o���g���</param>
        public void GetExp(int getExp)
        {
            exp += getExp;
            expMax = expNeed[lv - 1];

            while (exp >= expMax)
            {
                lv++;
                exp -= expMax;
                expMax = expNeed[lv - 1];

                LevelUp();
            }

            imgExp.fillAmount = (float)exp / (float)expMax;
            textLv.text = lv.ToString();
        }

        /// <summary>
        /// ���Ŵ���
        /// </summary>
        private void LevelUp()
        {
            dataWeapon.attack += 10;
            dataWeapon.interval -= 0.02f;
        }
    }
}

