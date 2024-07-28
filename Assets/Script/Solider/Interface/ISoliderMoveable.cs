using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoliderMoveable 
{
    Rigidbody2D RB { get; set; }
    bool IsFacingRight { get; set; }
    void MoveSolider(Vector2 velocity);
    void CheckForLeftOrRightFacing(Vector2 velocity);
}
