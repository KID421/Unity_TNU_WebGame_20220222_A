using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���˨t��
    /// </summary>
    public class HurtSystem : MonoBehaviour
    {
        // public ���}�G�Ҧ����O�i�H�s��
        // private �p�H�G�ȭ������O�i�H�s��
        // protected �O�@�G�ȭ������O�P�l���O�i�s��

        [SerializeField, Header("��q"), Range(0, 10000)]
        protected float hp;

        /// <summary>
        /// ����ˮ`
        /// </summary>
        /// <param name="damage">�ˮ`��</param>
        public void GetHurt(float damage)
        {
            hp -= damage;
            print("<color=red>���쪺�ˮ`�G" + damage + "</color>");

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// ���`
        /// </summary>
        private void Dead()
        {
            hp = 0;
            print("<color=red>���⦺�`�G" + gameObject + "</color>");
        }
    }
}

