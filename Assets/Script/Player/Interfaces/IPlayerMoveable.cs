using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMoveable
{
    float MoveSpeed { get; set;}
    Rigidbody2D RB { get; set; }
    bool IsFacingRight { get; set; }
    void CheckForLeftOrRightFacing(Vector2 velocity);
}
