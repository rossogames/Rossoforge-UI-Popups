using UnityEngine;

namespace Rossoforge.UI.Popups.Service
{
    [CreateAssetMenu(fileName = nameof(PopupServiceData), menuName = "Rossoforge/UI/Popups/Service Data")]
    public class PopupServiceData : ScriptableObject
    {
        [field: SerializeField]
        public int BaseSortingOrder { get; private set; } = 30000;
    }
}
