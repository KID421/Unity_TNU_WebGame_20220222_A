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

        private void Awake()
        {
            hp = data.hp;
        }
    }
}

