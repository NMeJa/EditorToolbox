using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.UnityTools;

public class TestIconAttribute : MonoBehaviour
{
    [Icon("Assets/KevinCastejon/UnityTools/Demos/Attributes/Icon/Icons/greencrossicon.png")]
    [SerializeField] private int _healthPoints;
    [Icon("Assets/KevinCastejon/UnityTools/Demos/Attributes/Icon/Icons/atk.png")]
    [SerializeField] private int _damages;
}
