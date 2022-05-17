using UnityEngine;

namespace KID
{
    /// <summary>
    /// �g��ȹD��
    /// </summary>
    public class Exp : MonoBehaviour
    {
        [HideInInspector]
        public TypeExp typeExp;
        [HideInInspector]
        public int exp;

        private SpriteRenderer spr;
        private Color colorSmall = new Color(0.2f, 0.1f, 1);
        private Color colorMiddle = new Color(0.1f, 1, 0.1f);
        private Color colorBig = new Color(1, 0.2f, 0.1f);

        private float rangeToPlayer = 3;
        private LayerMask layerPlayer = 1 << 3;
        private Transform traPlayer;
        private float speedToPlayer = 7.5f;
        private LevelManager lvManager;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.2f, 0.1f, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeToPlayer);
        }

        private void Awake()
        {
            spr = GetComponent<SpriteRenderer>();
            traPlayer = GameObject.Find("�M�h").transform;
            lvManager = GameObject.Find("���ź޲z��").GetComponent<LevelManager>();
        }

        private void Start()
        {
            SettingType();
        }

        private void Update()
        {
            CheckPlayerInRange();
        }

        /// <summary>
        /// �]�w����
        /// </summary>
        private void SettingType()
        {
            switch (typeExp)
            {
                case TypeExp.small:
                    spr.color = colorSmall;
                    exp = 20;
                    break;
                case TypeExp.middle:
                    spr.color = colorMiddle;
                    exp = 80;
                    break;
                case TypeExp.big:
                    spr.color = colorBig;
                    exp = 150;
                    break;
            }
        }

        /// <summary>
        /// �ˬd���a�O�_�b�d��
        /// </summary>
        private void CheckPlayerInRange()
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, rangeToPlayer, layerPlayer);

            if (hit)
            {
                Vector3 posExp = transform.position;
                Vector3 posPlayer = traPlayer.position;

                posExp = Vector3.Lerp(posExp, posPlayer, speedToPlayer * Time.deltaTime);

                transform.position = posExp;

                // �p�G �g��� �P ���a ���Z�� �p�� 0.4 �N
                if (Vector3.Distance(posExp, posPlayer) < 0.4f)
                {
                    lvManager.GetExp(exp);
                    // �R��
                    Destroy(gameObject);
                }
            }
        }
    }
}

