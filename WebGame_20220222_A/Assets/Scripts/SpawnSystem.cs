using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ͦ��t��
    /// </summary>
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField, Header("�n�ͦ����ĤH����")]
        private GameObject goEnemy;
        [SerializeField, Header("�ĤH�ͦ��I")]
        private Transform[] traSpawn;
        [SerializeField, Header("�ͦ�����"), Range(0, 5)]
        private float delay = 1;
        [SerializeField, Header("�ͦ����j"), Range(0, 5)]
        private float interval = 2.5f;

        private void Awake()
        {
            InvokeRepeating("Spawn", delay, interval);
        }

        /// <summary>
        /// �ͦ�
        /// </summary>
        private void Spawn()
        {
            int ran = Random.Range(0, traSpawn.Length);
            Instantiate(goEnemy, traSpawn[ran].position, Quaternion.identity);
        }
    }
}

