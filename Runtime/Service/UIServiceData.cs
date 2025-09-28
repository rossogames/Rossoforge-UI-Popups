using UnityEngine;

namespace Rossoforge.UI.Service
{
    [CreateAssetMenu(fileName = nameof(UIServiceData), menuName = "Rossoforge/UI/Service Data")]
    public class UIServiceData : ScriptableObject
    {
        [field: SerializeField]
        public int BaseSortingOrder { get; private set; } = 30000;
    }
}
