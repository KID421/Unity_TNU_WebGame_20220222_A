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
        [SerializeField, Header("畫布傷害數值")]
        private GameObject goCanvasHurt;
        [SerializeField, Header("經驗值道具")]
        private GameObject goExp;

        private string parameterDead = "觸發死亡";
        private Animator ani;
        private EnemySystem enemySystem;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            enemySystem = GetComponent<EnemySystem>();

            hp = data.hp;
        }

        // override 覆寫，覆寫覆類別有 virtual 的成員

        public override void GetHurt(float damage)
        {
            base.GetHurt(damage);

            GameObject temp = Instantiate(goCanvasHurt, transform.position, Quaternion.identity);
            temp.GetComponent<HurtNumberEffect>().UpdateDamage(damage);
        }

        protected override void Dead()
        {
            base.Dead();

            ani.SetTrigger(parameterDead);

            enemySystem.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 1.5f);

            DropExp();
        }

        /// <summary>
        /// 掉落經驗值道具
        /// </summary>
        private void DropExp()
        {
            float random = Random.value;

            if (random <= data.expDropProbability)
            {
                GameObject tempExp = Instantiate(goExp, transform.position, Quaternion.identity);
                tempExp.AddComponent<Exp>().typeExp = data.typeExp;
            }
        }
    }
}

