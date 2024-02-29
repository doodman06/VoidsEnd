using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    Transform transform { get; }

    Rigidbody2D rigidbody { get; }

    Collider2D collider { get; }
}

