using Rossoforge.Core.Events;
using Rossoforge.Core.Pool;
using Rossoforge.Core.UI.Popups;
using Rossoforge.Events.Service;
using Rossoforge.Pool.Service;
using Rossoforge.Services;
using Rossoforge.UI.Popups.Service;
using UnityEngine;

namespace Rossoforge.UI.Popups.PopupDemo
{
    public class Boot : MonoBehaviour
    {
        [SerializeField]
        private PopupServiceData _popupServiceData;

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