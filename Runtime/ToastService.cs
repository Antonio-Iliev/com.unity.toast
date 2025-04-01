using ToastMessageService.Abstractions;
using UnityEngine;

namespace ToastMessageService
{
    public class ToastService : IMessageService
    {
        private readonly AndroidJavaObject _activity;
        private readonly AndroidJavaObject _context;

        public ToastService()
        {
            var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _activity = player.GetStatic<AndroidJavaObject>("currentActivity");
            _context = _activity.Call<AndroidJavaObject>("getApplicationContext");
        }

        public void Dispose()
        {
            _context?.Dispose();
            _activity?.Dispose();
        }

        public void ShowMessage(string message)
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return;
            }

            _activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                var javaStringMessage = new AndroidJavaObject("java.lang.String", message);
                var toastClass = new AndroidJavaClass("android.widget.Toast");
                var handel = toastClass.CallStatic<AndroidJavaObject>("makeText", _context, javaStringMessage,
                    toastClass.GetStatic<int>("LENGTH_LONG"));
                handel.Call("show");
            }));
        }
    }
}