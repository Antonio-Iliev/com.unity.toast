# Unity Android Toast Package

## Overview
This Unity package provides a simple and effective way to use the native Android Toast UI for displaying messages on Android devices. It allows developers to invoke the Android Toast API directly from Unity, making it easy to integrate native Android notifications into Unity applications.

## Version
**0.0.1**

## Installation
This package is available on GitHub for easy import via the **Unity Package Manager (UPM)**.

### Importing via Unity Package Manager
1. Open Unity and navigate to **Window > Package Manager**.
2. Click on the **+** button and select **Add package from git URL...**.
3. Enter the following GitHub repository URL:
   ```
   https://github.com/Antonio-Iliev/com.unity.toast.git
   ```
4. Click **Add** and wait for Unity to import the package.

## Package Contents
The package includes the following C# classes:

### `ToastService.cs`
- Contains the core logic for invoking the Android Toast API.
- Recommended usage: Inject `ToastService` as a dependency.
- Provides a method to display Toast messages directly from code.

### `ToastMessageWrapper.cs`
- A `MonoBehaviour` wrapper for using the Toast API in a Unity scene.
- Allows users to attach it to a GameObject for easy access.

## Usage
### Recommended Usage (Dependency Injection)
```csharp
public class ExampleClass
{
    private readonly IMessageService _messageService;

    public ExampleClass(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void ShowToast()
    {
        _messageService.ShowMessage("Hello from Android Toast!");
    }
}
```

### Alternative Usage (MonoBehaviour Wrapper)
1. Create an **empty GameObject** in the Unity scene.
2. Attach the `ToastMessageWrapper` component to the GameObject.
3. Access it using one of the following methods:
   ```csharp
   // Find the wrapper in the scene
   var toastWrapper = FindObjectByType<ToastMessageWrapper>();
   
   // Show a toast message
   toastWrapper.ShowMessage("Hello from Android Toast!");
   ```
   **OR**
   
   Manually assign a reference to `ToastMessageWrapper` in your component and call `ShowMessage()`.

## License
This package is licensed under the **MIT License**.

## Contact
For any questions or feature requests, please create an issue on GitHub.

