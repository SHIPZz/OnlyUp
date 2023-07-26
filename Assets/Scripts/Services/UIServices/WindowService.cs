using System.Collections.Generic;
using DG.Tweening;
using Services.Providers;
using UI;
using UI.Windows;
using UnityEngine;

namespace Services.UIServices
{
    public class WindowService
    {
        private readonly Dictionary<WindowTypeId, Window> _windows = new();
        private readonly Dictionary<WindowTypeId, Window> _hudWindows = new();
        private readonly Dictionary<WindowTypeId, Window> _selectorWindows = new();

        private List<Window> _allWindows = new();

        public WindowService(WindowProvider windowProvider)
        {
            FillDictionary(_windows, windowProvider.Windows);
            FillDictionary(_hudWindows, windowProvider.HudWindows);
            FillList(_windows);
        }

        public void OpenHudWindow(WindowTypeId windowTypeId) =>
            Open(_hudWindows, windowTypeId);

        public void CloseHudWindow(WindowTypeId windowTypeId) =>
            Open(_hudWindows, windowTypeId);

        public void OpenHud() =>
            Open(_hudWindows);

        public void CloseHud() =>
            Close(_hudWindows);

        public void OpenSelectorWindow(WindowTypeId windowTypeId) =>
            Open(_selectorWindows, windowTypeId);

        public void CloseSelectorWindow(WindowTypeId windowTypeId) =>
            Close(_selectorWindows, windowTypeId);

        public void Open(WindowTypeId windowTypeId)
        {
            Window window = _windows[windowTypeId];

            window.Open();
        }

        public void Close(WindowTypeId windowTypeId)
        {
            var window = _windows[windowTypeId];
            window.Close(true);
        }

        public void CloseAll()
        {
            foreach (Window window in _allWindows)
            {
                window.Close(false);
            }
        }

        private void Open(Dictionary<WindowTypeId, Window> windows, WindowTypeId windowTypeId)
        {
            Close(windows);
            windows[windowTypeId].Open();
        }

        private void Close(Dictionary<WindowTypeId, Window> windows, WindowTypeId windowTypeId) =>
            windows[windowTypeId].Close(true);

        private void Open(Dictionary<WindowTypeId, Window> windows)
        {
            foreach (Window window in windows.Values)
            {
                window.Open();
            }
        }

        private void Close(Dictionary<WindowTypeId, Window> windows)
        {
            foreach (Window window in windows.Values)
            {
                window.Close(true);
            }
        }

        private void FillList(Dictionary<WindowTypeId, Window> windows)
        {
            foreach (var window in windows.Values)
            {
                _allWindows.Add(window);
            }
        }

        private void FillDictionary(Dictionary<WindowTypeId, Window> dictionaryWindows, List<Window> windows)
        {
            foreach (Window window in windows)
            {
                dictionaryWindows[window.WindowTypeId] = window;
            }
        }
    }
}