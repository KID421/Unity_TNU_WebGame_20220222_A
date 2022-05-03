using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ĤH�t��
    /// 1. �l�ܪ��a
    /// 2. ����
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("�ĤH���")]
        private DataEnemy data;
        [SerializeField, Header("���a����W��")]
        private string namePlayer = "�M�h";
        [SerializeField, Header("�����ʵe�Ѽ�")]
        private string parameterAttack = "Ĳ�o����";

        private Transform traPlayer;
        /// <summary>
        /// �����p�ɾ�
        /// </summary>
        private float timerAttack;
        private Animator ani;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            // ���a�����ܧ� = �C������.�M��(���a����W��).�ܧ�
            traPlayer = GameObject.Find(namePlayer).transform;

            /** // �{�Ѵ��� Lerp
            float result = Mathf.Lerp(0, 10, 0.5f);
            float result7 = Mathf.Lerp(0, 10, 0.7f);
            print("0 �P 10 �� 0.5 ���ȡG" + result);
            print("0 �P 10 �� 0.7 ���ȡG" + result7);
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
        /// ���ؼЪ��a���󲾰�
        /// </summary>
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;
            Vector3 posPlayer = traPlayer.position;

            // �Z�� = �T���V�q.�Z��(A �I�AB �I)
            float dis = Vector3.Distance(posEnemy, posPlayer);
            // print("<color=yellow>�Z���G" + dis + "</color>");

            // �p�G �Z�� �p�� ����Z�� �N�B�z ����
            if (dis < data.stopDistance)
            {
                Attack();
            }
            // �_�h �Z�� �j�� ����Z�� �N�B�z �l��
            else
            {
                transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * data.speed * Time.deltaTime);

                // y �ھڼĤH�P���a X �y�нվ�
                // �ĤH X �j�� ���a�AY 180 �_�h 0
                float y = transform.position.x > traPlayer.position.x ? 180 : 0;
                transform.eulerAngles = new Vector3(0, y, 0);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        private void Attack()
        {
            if (timerAttack < data.cd)
            {
                timerAttack += Time.deltaTime;
                // print("<color=red>�����p�ɾ��G" + timerAttack + "</color>");
            }
            else
            {
                ani.SetTrigger(parameterAttack);
                timerAttack = 0;
            }
        }
    }
}

