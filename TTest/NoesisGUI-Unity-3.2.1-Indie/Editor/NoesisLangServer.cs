using System;
using System.Runtime.InteropServices;
using System.Text;
using Noesis;
using UnityEditor;

[InitializeOnLoad]
public class NoesisLangServer
{
    static NoesisLangServer()
    {
        EditorApplication.update += () =>
        {
            NoesisUnity.Init();

            if (!_isDisabled)
            {
                if (!_isInitialized)
                {
                    _isInitialized = true;

                    try
                    {
                        SetLangServerDetails("Unity", 1000);
                        Noesis_RunLangServer();
                    }
                    catch (EntryPointNotFoundException)
                    {
                        _isDisabled = true;
                        return;
                    }

                    System.AppDomain.CurrentDomain.DomainUnload += (sender, e) =>
                    {
                        Noesis_ShutdownLangServer();
                    };

                    return;
                }

                Noesis_UpdateLangServer();
            }
        };
    }
    
    private static bool _isInitialized = false;
    private static bool _isDisabled = false;

    internal static void SetLangServerDetails(string serverName, int priority)
    {
        IntPtr namePtr = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(serverName);
        Noesis_SetLangServerDetails(namePtr, priority);
        System.Runtime.InteropServices.Marshal.FreeHGlobal(namePtr);
    }

    #region Imports
    [DllImport(Library.Name)]
    static extern void Noesis_RunLangServer();

    [DllImport(Library.Name)]
    static extern void Noesis_UpdateLangServer();

    [DllImport(Library.Name)]
    static extern void Noesis_ShutdownLangServer();

    [DllImport(Library.Name)]
    static extern void Noesis_SetLangServerDetails(IntPtr serverName, int serverPriority);
    #endregion
}