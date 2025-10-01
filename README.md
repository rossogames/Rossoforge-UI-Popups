# Rosso Games

<table>
  <tr>
    <td><img src="https://github.com/rossogames/Rossoforge-UI-Popups/blob/main/logo.png?raw=true" alt="Rossoforge" width="64"/></td>
    <td><h2>Rossoforge - UI - Popups</h2></td>
  </tr>
</table>

**Rossoforge-UI-Popups** Is a modular UI service for Unity that manages popups with pooling, async/await support, and event-driven lifecycle handling. Provides easy-to-use methods to open, await, and cancel popups, with automatic sorting order.

The following dependencies must be installed
* [[Rossoforge-Core]](https://github.com/rossogames/Rossoforge-Core.git)
* [[Rossoforge-Services]](https://github.com/rossogames/Rossoforge-Services.git)
* [[Rossoforge-Pool]](https://github.com/rossogames/Rossoforge-Pool.git)
* [[Rossoforge-UI-Controls]](https://github.com/rossogames/Rossoforge-UI-Controls.git)

**Version**: Unity 6 or higher

**Tutorial**: [Pending..]
#
```csharp
// Setup (requires Rossoforge-Services)
ServiceLocator.SetLocator(new DefaultServiceLocator());

var eventService = new EventService();
var poolService = new PoolService();
var uiService = new UIService(eventService, poolService);

ServiceLocator.Register<IEventService>(eventService);
ServiceLocator.Register<IPoolService>(poolService);
ServiceLocator.Register<IUIService>(uiService);
ServiceLocator.Initialize();

// 1. Using without addressables
[SerializeField]
private PooledGameobjectData popupReference;

_uiService.OpenPopup<PopupTemplateView>(popupReference);
await _uiService.OpenPopupUntilClosed<PopupTemplateView>(popupReference);

// 2. Using with addressables
[SerializeField]
private PooledObjectAsyncData popupReference;

await _uiService.OpenPopup<PopupTemplateView>(popupReference);
await _uiService.OpenPopupUntilClosed<PopupTemplateView>(popupReference);
```
#
This package is part of the **Rossoforge** suite, designed to streamline and enhance Unity development workflows.

Developed by Agustin Rosso
https://www.linkedin.com/in/rossoagustin/
