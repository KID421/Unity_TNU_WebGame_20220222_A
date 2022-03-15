using UnityEngine;      // �ޥ� Unity Engine �R�W�Ŷ� (API)

namespace KID
{
    // ���O (�}��) �W�٥����P���W���ɦW�����ۦP�A�]�t�j�p�g�A�ɦW���঳�Ů�ίS��r��
    /// <summary>
    /// �W�U�������ⱱ�
    /// ����ʡB�ʵe��s
    /// </summary>
    public class TopDownController : MonoBehaviour
    {
        #region ��ơG�O�s�t�λݭn����ơA�Ҧp���ʳt�סB�ʵe�ѼƦW�٩Τ��󵥸��
        // ���y�k�G�׹��� ������� ���W�� (���w �w�]��)�F
        // [] �ݩ� Attritube
        // SerializeField �ǦC����� - ���i���� (�X�{�b�ݩʭ��O Inspector)
        // Header ���D
        // Range �d��G�� �ȾA�Ω�ƭ�������ơAint�Bfloat
        [SerializeField, Header("���ʳt��"), Range(0, 500)]
        private float speed = 1.5f;
        private string parameterRun = "�}���]�B";
        private string parameterDead = "�}�����`";
        private Animator ani;
        private Rigidbody2D rig;
        #endregion

        #region �ƥ�G�{�����J�f (Unity)
        // ����ƥ�G����C���ɰ���@���A�B�z��l��
        private void Awake()
        {
            // GetComponent<�x��>() - �x���G����������
            // ��� ���w ���o����<����W��>() - ���o���w����s������
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }

        // ��s�ƥ�G�� 60 FPS (Frame per second)
        // ���o��J��ƥi�b���ƥ�B�z
        private void Update()
        {
            GetInput();
        }
        #endregion

        #region ��k�G���������欰�A�Ҧp���ʥ\��B��s�ʵe
        // ��k�y�k�G�׹��� �Ǧ^������� ��k�W�� (�Ѽ�) { �{�����e }
        /// <summary>
        /// ���o��J�G�����P����
        /// </summary>
        private void GetInput()
        {
            // �ϥ��R�A��� static
            // �y�k�G���O�W��.�R�A��k�W�� (�����޼�)
            // Horizontal �����b�V
            // ���G��V���� �P A - �Ǧ^ -1
            // �k�G��V�k�� �P D - �Ǧ^ +1
            float h = Input.GetAxis("Horizontal");
            // print() ��X�G�N () ���T����X�� Unity Console ���O (Ctrl + Shift + C)
            print("�����b�V�ȡG" + h);
        }
        #endregion
    }
}
