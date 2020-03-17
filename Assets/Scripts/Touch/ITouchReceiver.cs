using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchReceiver
{
    void OnTouched(Vector2 touchPos);
    void OnReleased(Vector2 touchPos);
}
