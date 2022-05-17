using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ĤH���ˡA�u�X�ˮ`
    /// </summary>
    // EnemyHurt : HurtSystem - �~��
    // EnemyHurt �l���O
    // HurtSystem �����O
    public class EnemyHurt : HurtSystem
    {
        [SerializeField, Header("�ĤH���")]
        private DataEnemy data;
        [SerializeField, Header("�e���ˮ`�ƭ�")]
        private GameObject goCanvasHurt;
        [SerializeField, Header("�g��ȹD��")]
        private GameObject goExp;

        private string parameterDead = "Ĳ�o���`";
        private Animator ani;
        private EnemySystem enemySystem;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            enemySystem = GetComponent<EnemySystem>();

            hp = data.hp;
        }

        // override �мg�A�мg�����O�� virtual ������

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
        /// �����g��ȹD��
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

