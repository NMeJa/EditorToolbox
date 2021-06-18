using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.UnityTools;

public class TestLabelPlusAttribute : MonoBehaviour
{
    [LabelPlus("Assets/KayCeeTools/DemosScenes/Attributes/Icons/greencrossicon.png", "Health Points", (int)LabelPlusColor.green)]
    [SerializeField] private int _healthPoints;
    [LabelPlus("Assets/KayCeeTools/DemosScenes/Attributes/Icons/atk.png", "Damages", (int)LabelPlusColor.red)]
    [SerializeField] private int _damages;
}
