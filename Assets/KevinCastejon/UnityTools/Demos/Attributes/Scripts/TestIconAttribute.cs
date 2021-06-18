using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.UnityTools;

public class TestIconAttribute : MonoBehaviour
{
    [Icon("Assets/KayCeeTools/DemosScenes/Attributes/Icons/greencrossicon.png")]
    [SerializeField] private int _healthPoints;
    [Icon("Assets/KayCeeTools/DemosScenes/Attributes/Icons/atk.png")]
    [SerializeField] private int _damages;
}
