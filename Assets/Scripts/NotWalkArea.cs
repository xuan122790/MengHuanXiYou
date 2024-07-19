using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotWalkArea : MonoBehaviour
{
    public CharacterAI characterAI;

    private void OnMouseDown()
    {
        characterAI.willStoping = true;
    }

}
