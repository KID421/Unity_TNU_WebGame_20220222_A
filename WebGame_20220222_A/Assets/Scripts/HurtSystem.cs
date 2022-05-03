using UnityEngine;

namespace KID
{
    /// <summary>
    /// 受傷系統
    /// </summary>
    public class HurtSystem : MonoBehaviour
    {
        // public 公開：所有類別可以存取
        // private 私人：僅限此類別可以存取
        // protected 保護：僅限此類別與子類別可存取

        [SerializeField, Header("血量"), Range(0, 10000)]
        protected float hp;

        /// <summary>
        /// 受到傷害
        /// </summary>
        /// <param name="damage">傷害值</param>
        public void GetHurt(float damage)
        {
            hp -= damage;
            print("<color=red>收到的傷害：" + damage + "</color>");

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {
            hp = 0;
            print("<color=red>角色死亡：" + gameObject + "</color>");
        }
    }
}

