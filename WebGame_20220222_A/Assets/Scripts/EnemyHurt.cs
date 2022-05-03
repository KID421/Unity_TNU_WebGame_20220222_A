using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人受傷，彈出傷害
    /// </summary>
    // EnemyHurt : HurtSystem - 繼承
    // EnemyHurt 子類別
    // HurtSystem 父類別
    public class EnemyHurt : HurtSystem
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;

        private void Awake()
        {
            hp = data.hp;
        }
    }
}

