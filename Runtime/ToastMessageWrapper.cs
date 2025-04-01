using ToastMessageService.Abstractions;
using UnityEngine;

namespace ToastMessageService
{
    public class ToastMessageWrapper : MonoBehaviour
    {
        private IMessageService _toastService;

        private void Awake()
        {
            var instances = FindObjectsByType<ToastMessageWrapper>(FindObjectsSortMode.None);
            if (instances.Length > 1)
            {
                Debug.LogWarning(
                    $"{nameof(ToastMessageWrapper)}: Multiple ToastMessageWrapper instances found! Destroying duplicate.");
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            _toastService = new ToastService();
        }

        private void OnDestroy()
        {
            _toastService?.Dispose();
        }

        public void ShowMessage(string message)
        {
            _toastService.ShowMessage(message);
        }
    }
}