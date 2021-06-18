using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.UnityTools;

public class TestHeaderPlusAttribute : MonoBehaviour
{
    [HeaderPlus("Assets/KayCeeTools/DemosScenes/Attributes/Icons/greencrossicon.png", "Health", (int)HeaderPlusColor.green)]
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [HeaderPlus("Assets/KayCeeTools/DemosScenes/Attributes/Icons/atk.png", "Attack", (int)HeaderPlusColor.red)]
    [SerializeField] private int _damagePoints;
}
