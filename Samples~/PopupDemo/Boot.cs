using Rossoforge.Core.Events;
using Rossoforge.Core.Pool;
using Rossoforge.Core.UI;
using Rossoforge.Events.Service;
using Rossoforge.Pool.Service;
using Rossoforge.Services;
using Rossoforge.UI.Service;
using UnityEngine;

namespace Rossoforge.UI.Popups.PopupDemo
{
    public class Boot : MonoBehaviour
    {
        [SerializeField]
        private UIServiceData _uiServiceData;

        private void Awake()
        {
            // Setup
            ServiceLocator.SetLocator(new DefaultServiceLocator());

            var eventService = new EventService();
            var poolService = new PoolService();
            var uiService = new UIService(eventService, poolService, _uiServiceData);

            ServiceLocator.Register<IEventService>(eventService);
            ServiceLocator.Register<IPoolService>(poolService);
            ServiceLocator.Register<IUIService>(uiService);

            ServiceLocator.Initialize();
        }

    }
}