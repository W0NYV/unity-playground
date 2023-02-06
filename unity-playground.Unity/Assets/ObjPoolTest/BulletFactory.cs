using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjPoolTest
{

    [RequireComponent(typeof(ObjectPool))]
    public class BulletFactory : MonoBehaviour
    {

        [SerializeField] private GameObject _bulletPrefab;
        private const int BULLET_MAX = 50;
        private int _state = 0;
        private float _originDirection = 0f;
        private bool _isReverse = false;
        private ObjectPool _pool;

        private void Awake() {
            TryGetComponent<ObjectPool>(out _pool);
            _pool.CreatePool(_bulletPrefab, BULLET_MAX);
        }

        private void Update() {
            if(_state % 6000 == 0)
            {
                var way = 16;
                for(int i = 0; i < way; i++)
                {
                    var bullet = _pool.GetObject();
                    if(bullet != null)
                    {
                        bullet.GetComponent<Bullet>().Initialize(_originDirection + i * (360f / way), _isReverse);
                    }
                }

                _originDirection = (_originDirection + 10) % 360;
                _isReverse = !_isReverse;
            }

            _state++;
        }
    }
}
