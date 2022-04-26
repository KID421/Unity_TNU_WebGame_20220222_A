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
        [SerializeField, Header("�Z���R���ɶ�"), Range(0, 5)]
        private float weaponDestoryTime = 3.5f;

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

        private void Start()
        {
            // 2D ���z.�����ϼh�I���]�ϼh 1�A�ϼh 2�^
            Physics2D.IgnoreLayerCollision(3, 6);       // ���a �P �Z�� ���I��
            Physics2D.IgnoreLayerCollision(6, 6);       // �Z�� �P �Z�� ���I��
            Physics2D.IgnoreLayerCollision(6, 7);       // �Z�� �P �Ů��� ���I��
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
            // print("�g�L�ɶ��G" + timer);

            // �p�G �p�ɾ� �j�󵥩� ���j�ɶ�
            if (timer >= dataWeapon.interval)
            {
                // �H���� = �H��.�d��]�̤p�ȡA�̤j�ȡ^�� ��Ƥ��]�t�̤j��
                int random = Random.Range(0, dataWeapon.v2SpawnPoint.Length);
                // �y��
                Vector3 pos = transform.position + dataWeapon.v2SpawnPoint[random];
                // Quaternion �|�줸 - �������׸�T
                // Quaternion.identity �s���ס]0�A0�A0�^
                // �Ȧs�Z�� = �ͦ�(����)
                GameObject temp = Instantiate(dataWeapon.goWeapon, pos, Quaternion.identity);
                // �Ȧs�Z��.���o����<����>().�K�[���O�]��V * �t�ס^
                temp.GetComponent<Rigidbody2D>().AddForce(dataWeapon.v3Direction * dataWeapon.speedFly);
                // �p�ɾ� �k�s
                timer = 0;
                // �R������(�C������A����ɶ�)
                Destroy(temp, weaponDestoryTime);
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

