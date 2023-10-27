using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : CreatureController
{
    public int hp = 100;

    CapsuleCollider capsulCol;

    public override void Init()
    {
        capsulCol = new CapsuleCollider();
    }
}
