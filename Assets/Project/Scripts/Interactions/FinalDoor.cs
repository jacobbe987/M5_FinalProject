using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public void FinalDoorClosed()
    {
        GameManager.Instance.GameCompleted();
    }
}
