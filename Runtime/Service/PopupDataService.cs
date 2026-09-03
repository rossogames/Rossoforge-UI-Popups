using UnityEngine;

namespace Rossoforge.UI.Popups.Service
{
    [CreateAssetMenu(fileName = nameof(PopupDataService), menuName = "Rossoforge/Data Service/Popups")]
    public class PopupDataService : ScriptableObject
    {
        [field: SerializeField]
        public int BaseSortingOrder { get; private set; } = 30000;
    }
}
