using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public interface IWeapon
{
    public float Name { get; set; }
    public float Damage { get; set; }
    public float moveSpeed { get; set; }

    
}
