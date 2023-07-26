using System;
using Invector.vCharacterController;
using Services.Providers;
using UI.Windows;
using Zenject;

public class ShowerCursorOn : IInitializable, IDisposable
{
    private PlayerProvider _playerProvider;
    private vThirdPersonInput _thirdPersonInput;
    private Window _window;

    public ShowerCursorOn(PlayerProvider playerProvider, WindowProvider windowProvider)
    {
        _playerProvider = playerProvider;
        _playerProvider.PlayerInstalled += SetPlayer;
        _window = windowProvider.Windows.Find(x => x.WindowTypeId == WindowTypeId.SettingWindow);
    }

    public void Initialize()
    {
        _window.Opened += ShowCursor;
        _window.Closed += DisableCursor;
    }

    public void Dispose()
    {
        _window.Opened -= ShowCursor;
        _window.Closed -= DisableCursor;
        _playerProvider.PlayerInstalled -= SetPlayer;
    }

    private void SetPlayer(vThirdPersonController obj) => 
        _thirdPersonInput = obj.GetComponent<vThirdPersonInput>();

    private void DisableCursor() => 
        _thirdPersonInput.ShowCursor(false);

    private void ShowCursor() => 
        _thirdPersonInput.ShowCursor(true);
}
