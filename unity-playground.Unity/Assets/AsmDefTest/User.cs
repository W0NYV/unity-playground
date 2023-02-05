using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsmDefTest
{
    public class User : MonoBehaviour
    {
        public int num = 0;
        private HogeDepender _hogeDepender;

        void Start()
        {
            _hogeDepender = new HogeDepender();

            Debug.Log(_hogeDepender.HogeHuga());
        }

    }
}