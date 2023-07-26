using System.Collections.Generic;
using UI;
using UI.Windows;
using UnityEngine;

namespace Services.Providers
{
    public class WindowProvider : MonoBehaviour
    {
        [field: SerializeField] public List<Window> Windows { get; private set; }
        [field: SerializeField] public List<Window> HudWindows { get; private set; }
    }
}