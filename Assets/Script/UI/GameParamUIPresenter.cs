﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParamUIPresenter : MonoBehaviour
{
    public CharacterHpViewer CharacterHpViewer = null;

    public void SetCharacterparamViewer (CharacterParam[] CharacterParams)
    {
        for (int i = 0; i < 3; i++)
        {
            if (CharacterParams[i] != null)
            {
                CharacterHpViewer.CharacterMaxHps[i] = CharacterParams[i].HitPoint;
                CharacterHpViewer.CharacterHps[i] = CharacterParams[i].HitPoint; 
            }
        }
    }
}