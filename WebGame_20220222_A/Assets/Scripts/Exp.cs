using UnityEngine;

namespace KID
{
    /// <summary>
    /// 經驗值道具
    /// </summary>
    public class Exp : MonoBehaviour
    {
        [HideInInspector]
        public TypeExp typeExp;
        [HideInInspector]
        public int exp;

        private SpriteRenderer spr;
        private Color colorSmall = new Color(0.2f, 0.1f, 1);
        private Color colorMiddle = new Color(0.1f, 1, 0.1f);
        private Color colorBig = new Color(1, 0.2f, 0.1f);

        private float rangeToPlayer = 3;
        private LayerMask layerPlayer = 1 << 3;
        private Transform traPlayer;
        private float speedToPlayer = 7.5f;
        private LevelManager lvManager;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.2f, 0.1f, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeToPlayer);
        }

        private void Awake()
        {
            spr = GetComponent<SpriteRenderer>();
            traPlayer = GameObject.Find("騎士").transform;
            lvManager = GameObject.Find("等級管理器").GetComponent<LevelManager>();
        }

        private void Start()
        {
            SettingType();
        }

        private void Update()
        {
            CheckPlayerInRange();
        }

        /// <summary>
        /// 設定類型
        /// </summary>
        private void SettingType()
        {
            switch (typeExp)
            {
                case TypeExp.small:
                    spr.color = colorSmall;
                    exp = 20;
                    break;
                case TypeExp.middle:
                    spr.color = colorMiddle;
                    exp = 80;
                    break;
                case TypeExp.big:
                    spr.color = colorBig;
                    exp = 150;
                    break;
            }
        }

        /// <summary>
        /// 檢查玩家是否在範圍內
        /// </summary>
        private void CheckPlayerInRange()
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, rangeToPlayer, layerPlayer);

            if (hit)
            {
                Vector3 posExp = transform.position;
                Vector3 posPlayer = traPlayer.position;

                posExp = Vector3.Lerp(posExp, posPlayer, speedToPlayer * Time.deltaTime);

                transform.position = posExp;

                // 如果 經驗持 與 玩家 的距離 小於 0.4 就
                if (Vector3.Distance(posExp, posPlayer) < 0.4f)
                {
                    lvManager.GetExp(exp);
                    // 刪除
                    Destroy(gameObject);
                }
            }
        }
    }
}

