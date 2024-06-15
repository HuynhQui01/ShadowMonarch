using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


    public interface IEnemy
    {
        public float Health{get; set; }
        public float Damage {get; set; }
        public float Armor {get; set; }
        public float MoveSpeed {get; set; }

        public void TakeDamage(float damage);
        public void TakeDamage(float damage, Vector2 knockback);
        public void Attack();
        public void Dead();

    }