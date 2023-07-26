using System;
using Services.UIServices;
using Zenject;

namespace UI.Windows.Settings
{
    public class SettingWindowPresenter : IInitializable, IDisposable
    {
        private readonly WindowService _windowService;
        private readonly SettingView _settingView;

        public SettingWindowPresenter(WindowService windowService, SettingView settingView)
        {
            _windowService = windowService;
            _settingView = settingView;
        }

        public void Initialize()
        {
            _settingView.OpenClicked += OpenWindow;
            _settingView.CloseClicked += CloseWindow;
        }

        public void Dispose()
        {
            _settingView.OpenClicked -= OpenWindow;
            _settingView.CloseClicked -= CloseWindow;
        }

        private void OpenWindow()
        {
            _windowService.CloseAll();
            _windowService.Open(WindowTypeId.SettingWindow);
        }

        private void CloseWindow()
        {
            _windowService.OpenHud();
            _windowService.Close(WindowTypeId.SettingWindow);
        }
    }
}