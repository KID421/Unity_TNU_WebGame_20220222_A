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
        [SerializeField, Header("攻擊動畫參數")]
        private string parameterAttack = "觸發攻擊";

        private Transform traPlayer;
        /// <summary>
        /// 攻擊計時器
        /// </summary>
        private float timerAttack;
        private Animator ani;

        private void Awake()
        {
            ani = GetComponent<Animator>();
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

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.5f, 0, 0.5f);
            Gizmos.DrawSphere(transform.position, data.stopDistance);
        }

        /// <summary>
        /// 往目標玩家物件移動
        /// </summary>
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;
            Vector3 posPlayer = traPlayer.position;

            // 距離 = 三維向量.距離(A 點，B 點)
            float dis = Vector3.Distance(posEnemy, posPlayer);
            // print("<color=yellow>距離：" + dis + "</color>");

            // 如果 距離 小於 停止距離 就處理 攻擊
            if (dis < data.stopDistance)
            {
                Attack();
            }
            // 否則 距離 大於 停止距離 就處理 追蹤
            else
            {
                transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * data.speed * Time.deltaTime);

                // y 根據敵人與玩家 X 座標調整
                // 敵人 X 大於 玩家，Y 180 否則 0
                float y = transform.position.x > traPlayer.position.x ? 180 : 0;
                transform.eulerAngles = new Vector3(0, y, 0);
            }
        }

        /// <summary>
        /// 攻擊
        /// </summary>
        private void Attack()
        {
            if (timerAttack < data.cd)
            {
                timerAttack += Time.deltaTime;
                // print("<color=red>攻擊計時器：" + timerAttack + "</color>");
            }
            else
            {
                ani.SetTrigger(parameterAttack);
                timerAttack = 0;
            }
        }
    }
}

