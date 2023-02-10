using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClassTest
{
    public class Brave : Character
    {
        //中身が空でもコンストラクタを書かないといけないっぽい
        public Brave(string name):base(name, Job.BRAVE) {}

        public override void Attack()
        {
            Debug.Log(Name + "の攻撃！");
            Debug.Log("剣で攻撃！");
        }

        public override void SpecialAttack()
        {
            Debug.Log(Name + "によるスペシャル攻撃!!!");
            Debug.Log("ｱﾁｮｰｰｰｰｰｰｰｰｰｰｰｰｰｰ!!!");
        }

        public void Guard()
        {
            Debug.Log(Name + "はガードした！");
        }
    }
}
