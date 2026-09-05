using Rossoforge.Events.Service;
using Rossoforge.Pool.Service;
using Rossoforge.Popups.Service;
using Rossoforge.Services.Locator;
using UnityEngine;

namespace Rossoforge.Popups.Samples.PopupDemo
{
    public class Boot : MonoBehaviour
    {
        [SerializeField]
        private PopupDataService _popupServiceData;

        private void Awake()
        {
            // Setup
            ServiceLocator.SetLocator(new DefaultServiceLocator());

            var eventService = new EventService();
            var poolService = new PoolService();
            var popupService = new PopupService(_popupServiceData);

            ServiceLocator.Register<IEventService>(eventService);
            ServiceLocator.Register<IPoolService>(poolService);
            ServiceLocator.Register<IPopupService>(popupService);

            ServiceLocator.Initialize();
        }
    }
}