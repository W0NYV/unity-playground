using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjPoolTest
{
    public class Bullet : MonoBehaviour
    {

        private float _speed = 4f;
        private float _direction;
        private bool _isReverse;
        private Rigidbody2D _rigidBody;

        public void Initialize(float direction, bool isReverse)
        {
            _direction = direction;
            _isReverse = isReverse;
            _rigidBody = GetComponent<Rigidbody2D>();

            if(_isReverse)
            {
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.3f, 0.3f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }

            SetDirection();
        }

        private void Update() {
            if(_isReverse)
            {
                _direction = (_direction - 1) % 360;
            }
            else
            {
                _direction = (_direction + 1) % 360;
            }
            SetDirection();
        }

        private void OnBecameInvisible() {
            gameObject.SetActive(false);
            ResetPosition();
        }

        private void SetDirection()
        {
            Vector2 v;
            v.x = Mathf.Cos(Mathf.Deg2Rad * _direction) * _speed;
            v.y = Mathf.Sin(Mathf.Deg2Rad * _direction) * _speed;

            _rigidBody.velocity = v;
        }

        private void ResetPosition()
        {
            _rigidBody.velocity = Vector2.zero;
            transform.localPosition = Vector3.zero;
        }

    }
}