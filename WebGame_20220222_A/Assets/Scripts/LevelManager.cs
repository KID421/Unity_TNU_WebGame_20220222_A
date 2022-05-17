using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 等級管理器
    /// 等級、經驗值資料界面更新
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        [SerializeField, Header("經驗值")]
        private Image imgExp;
        [SerializeField, Header("等級")]
        private Text textLv;

        [SerializeField]
        private int exp;
        private int expMax;
        private int lv = 1;

        [SerializeField]
        private int[] expNeed;

        [SerializeField, Header("要升級的武器資料")]
        private DataWeapon dataWeapon;

        /// <summary>
        /// 設定經驗值需求
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
        /// 獲得經驗值
        /// </summary>
        /// <param name="getExp">獲得的經驗值</param>
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
        /// 等級提升
        /// </summary>
        private void LevelUp()
        {
            dataWeapon.attack += 10;
            dataWeapon.interval -= 0.02f;
        }
    }
}

