using UnityEngine;

namespace KID
{
    /// <summary>
    /// �Z���t��
    /// 1. �x�s���a�֦����Z�����
    /// 2. �ھڪZ����ƥͦ��Z��
    /// 3. �ᤩ�Z��������ơA����t�סB�����O
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("�Z�����")]
        private DataWeapon dataWeapon;

        /// <summary>
        /// �p�ɾ�
        /// </summary>
        private float timer;

        /// <summary>
        /// ø�s�ϥ�
        /// �@�ΡG�b�s�边�� (Unity) ø�s�U�عϧλ��U�}�o
        /// ���|�b�����ɤ��X�{��
        /// </summary>
        private void OnDrawGizmos()
        {
            // 1. �ϥ��C��
            // new Color(���A��A�šA�z����) �� 0 - 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            // 2. ø�s�ϥ�
            // �ϥ� �� ø�s���(�����I�A�b�|)
            // transform.position + dataWeapon.v2SpawnPoint[0] ����y�� + �ͦ���m
            // �ت��G�ͦ���m�|�ھڨ����m���۹ﲾ��

            // for �j��
            // (��l�ȡF����F�C�@���j�鵲������϶�)
            for (int i = 0; i < dataWeapon.v2SpawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(transform.position + dataWeapon.v2SpawnPoint[i], 0.1f);
            }
        }

        private void Update()
        {
            SpawnWeapon();
        }

        /// <summary>
        /// �ͦ��Z��
        /// �C�j�Z�����j�ɶ��N�ͦ��Z���b�ͦ���m�W
        /// </summary>
        private void SpawnWeapon()
        {
            print("�g�L�ɶ��G" + timer);

            // �p�G �p�ɾ� �j�󵥩� ���j�ɶ�
            if (timer >= dataWeapon.interval)
            {
                // �ͦ�(����)
                Instantiate(dataWeapon.goWeapon);
                // �p�ɾ� �k�s
                timer = 0;
            }
            // �_�h
            else
            {
                // �p�ɾ� �֥[ �@�Ӽv�檺�ɶ�
                timer += Time.deltaTime;
            }
        }
    }
}

