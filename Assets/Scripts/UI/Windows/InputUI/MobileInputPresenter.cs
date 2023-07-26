using Agava.WebUtility;
using Services.UIServices;
using Zenject;

namespace UI.Windows.InputUI
{
    public class MobileInputPresenter : IInitializable
    {
        private readonly WindowService _windowService;

        public MobileInputPresenter(WindowService windowService)
        {
            _windowService = windowService;
        }

        public void Initialize()
        {
            // if(Device.IsMobile)
                _windowService.Open(WindowTypeId.MobileInputWindow);
        }
    }
}