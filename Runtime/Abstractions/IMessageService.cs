using System;

namespace ToastMessageService.Abstractions
{
    public interface IMessageService: IDisposable
    {
        void ShowMessage(string message);
    }
}
