using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClassTest
{
    public class GameManager : MonoBehaviour
    {

        private Character _character;

        private void Start()
        {
            _character = new Brave("W0NYV");
            _character.Attack();
            _character.SpecialAttack();
        }
    }
}
