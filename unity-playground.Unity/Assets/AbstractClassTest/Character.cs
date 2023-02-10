using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClassTest
{

    public enum Job
    {
        BRAVE,
        MAGE,
        MONK,
        WARRIOR
    }

    public abstract class Character
    {
        private string _name;
        public string Name { get => _name; }

        private Job _job;
        public Job Job { get => _job; }

        private int _hp;
        private int _mp;

        //コンストラクタ
        public Character(string name, Job job)
        {
            _name = name;
            _job = job;

            switch (job)
            {
                case Job.BRAVE:
                    _hp = 100;
                    _mp = 100;
                    break;

                case Job.MAGE:
                    _hp = 80;
                    _mp = 120;
                    break;
                
                case Job.MONK:
                    _hp = 90;
                    _mp = 110;
                    break;

                case Job.WARRIOR:
                    _hp = 120;
                    _mp = 80;
                    break;

                default:
                    Debug.Log("その職業は存在しません");
                    break;
            }
        }

        //職業に応じて攻撃方法を変更
        //インターフェースみたい
        public abstract void Attack();

        public virtual void SpecialAttack()
        {
            Debug.Log(_name + "によるスペシャル攻撃！！");
            Debug.Log("おりゃあああああ");
        }

        public void ShowProf()
        {
            Debug.Log("名は" + _name);
            Debug.Log("職業は" + _job);
        }
    }
}
