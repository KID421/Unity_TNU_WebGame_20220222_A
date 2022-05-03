using UnityEngine;

namespace KID
{
    /// <summary>
    /// �Z���G���[�b�Z���W
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        [HideInInspector]
        public float attack;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // �p�G �I�쪫�󪺼��� ���� �ĤH �N �y���ˮ`
            if (collision.gameObject.tag == "�ĤH")
            {
                collision.gameObject.GetComponent<HurtSystem>().GetHurt(attack);
            }
        }
    }
}

