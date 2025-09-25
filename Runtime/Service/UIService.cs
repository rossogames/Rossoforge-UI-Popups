using Rossoforge.UI.Popups.PopupBase;
using UnityEngine;

namespace Rossoforge.UI.Service
{
    public interface IUIService
    {

    }
    public class UIService: IUIService
    {
        public T OpenPopup<T>(T popupView) where T : MonoBehaviour, IPopupView
        {
            if (popupView.CanBeOpened())
            {
                popupView.Open();
                return popupView;
            }

            Debug.LogWarning($"[UIService] Popup {popupView.name} cannot be opened. Current state: {popupView.State}");
            return null;
        }
    }
    //[CreateAssetMenu(fileName = nameof(PooledGameobjectData), menuName = "Rossoforge/Pool/Pooled Gameobject Data")]
    //public class PooledGameobjectData : ScriptableObject, IPooledGameobjectData
    //{
    //    [field: SerializeField]
    //    public GameObject AssetReference { get; private set; }
    //
    //    [field: SerializeField]
    //    public int MaxSize { get; private set; } = 1;
    //
    //    private void OnValidate()
    //    {
    //        MaxSize = Mathf.Max(1, MaxSize);
    //    }
    //}
}
