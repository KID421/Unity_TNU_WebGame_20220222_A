using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人系統
    /// 1. 追蹤玩家
    /// 2. 攻擊
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;
        [SerializeField, Header("玩家物件名稱")]
        private string namePlayer = "騎士";

        private Transform traPlayer;

        private void Awake()
        {
            // 玩家物件變形 = 遊戲物件.尋找(玩家物件名稱).變形
            traPlayer = GameObject.Find(namePlayer).transform;

            /** // 認識插值 Lerp
            float result = Mathf.Lerp(0, 10, 0.5f);
            float result7 = Mathf.Lerp(0, 10, 0.7f);
            print("0 與 10 的 0.5 插值：" + result);
            print("0 與 10 的 0.7 插值：" + result7);
            */
        }

        private void Update()
        {
            MoveToPlayer();
        }

        /// <summary>
        /// 往目標玩家物件移動
        /// </summary>
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;
            Vector3 posPlayer = traPlayer.position;

            transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * data.speed * Time.deltaTime);

            // y 根據敵人與玩家 X 座標調整
            // 敵人 X 大於 玩家，Y 180 否則 0
            float y = transform.position.x > traPlayer.position.x ? 180 : 0;
            transform.eulerAngles = new Vector3(0, y, 0);
        }
    }
}

