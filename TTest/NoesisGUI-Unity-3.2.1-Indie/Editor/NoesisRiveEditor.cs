//#define DEBUG_IMPORTER

using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Noesis;
using System.IO;
using System.Collections.Generic;

[CustomEditor(typeof(NoesisRive))]
public class NoesisRiveEditor: Editor
{
    private Noesis.View _view;
    private Noesis.View _viewIcon;
    private UnityEngine.Rendering.CommandBuffer _commands;

    private bool IsGL()
    {
        return
            SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES2 ||
            SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES3 ||
            SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLCore;
    }

    private FrameworkElement GetRoot(NoesisRive rive)
    {
        return new Border()
        {
            Child = new RiveControl()
            {
                Source = new System.Uri(rive.uri, System.UriKind.RelativeOrAbsolute),
                Stretch = Stretch.Uniform
            }
        };
    }

    private View CreateView(NoesisRive rive)
    {
        try
        {
            FrameworkElement root = GetRoot(rive);
            View view = Noesis.GUI.CreateView(root);
            view.SetFlags(IsGL() ? 0 : RenderFlags.FlipY);

            NoesisRenderer.RegisterView(view, _commands);
            Graphics.ExecuteCommandBuffer(_commands);
            _commands.Clear();

            return view;
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogException(e);
            return null;
        }
    }

    private void EnumInputs(string uri)
    {
        RiveControl control = new RiveControl()
        {
            Source = new System.Uri(uri, System.UriKind.RelativeOrAbsolute)
        };
        View view = Noesis.GUI.CreateView(control);

        _sourceInputs.Clear();
        for (uint i = 0; i < control.GetSourceInputCount(); i++)
        {
            RiveSourceInputType type;
            string name = control.GetSourceInput(i, out type);
            _sourceInputs.Add(new RiveSourceInput { Name = name, Type = type });
        }

        control.Dispose();
        view.Dispose();
    }

    private void RegisterRive(NoesisRive rive)
    {
        NoesisXamlProvider.instance.Register(rive.uri, rive);
    }

    private void UnregisterRive(NoesisRive rive)
    {
        NoesisXamlProvider.instance.Unregister(rive.uri);
    }

    public void OnEnable()
    {
        if (_commands == null)
        {
            _commands = new UnityEngine.Rendering.CommandBuffer();
        }

        NoesisRive rive = (NoesisRive)target;
        if (rive != null && rive.uri != null)
        {
            NoesisUnity.Init();
            RegisterRive(rive);
            EnumInputs(rive.uri);
        }
    }

    public void OnDisable()
    {
        if (_view != null)
        {
            NoesisRenderer.UnregisterView(_view, _commands);
            Graphics.ExecuteCommandBuffer(_commands);
            _commands.Clear();
            _view.Content?.Dispose();
            _view.Dispose();
            _view = null;
        }

        if (_viewIcon != null)
        {
            NoesisRenderer.UnregisterView(_viewIcon, _commands);
            Graphics.ExecuteCommandBuffer(_commands);
            _commands.Clear();
            _viewIcon.Content?.Dispose();
            _viewIcon.Dispose();
            _viewIcon = null;
        }

        NoesisRive rive = (NoesisRive)target;
        if (rive != null && rive.uri != null)
        {
            UnregisterRive(rive);
        }
    }

    public override void OnInspectorGUI()
    {
        bool enabled = UnityEngine.GUI.enabled;
        UnityEngine.GUI.enabled = true;
        EditorGUILayout.BeginFoldoutHeaderGroup(true,
            $"Available Inputs ({_sourceInputs.Count})", EditorStyles.label);

        if (_sourceInputs.Count > 0)
        {
            Font font = EditorStyles.label.font;
            EditorStyles.label.font = EditorStyles.boldFont;
            EditorGUILayout.LabelField("NAME", "TYPE");
            EditorStyles.label.font = font;
        }

        foreach (var input in _sourceInputs)
        {
            EditorGUILayout.LabelField(input.Name, input.Type.ToString(), EditorStyles.textField);
        }

        EditorGUILayout.EndFoldoutHeaderGroup();
        UnityEngine.GUI.enabled = enabled;
    }

    private struct RiveSourceInput
    {
        public string Name;
        public RiveSourceInputType Type;
    }

    private List<RiveSourceInput> _sourceInputs = new List<RiveSourceInput>();

    private bool CanRender()
    {
        return NoesisSettings.Get().previewEnabled;
    }

    public override bool HasPreviewGUI()
    {
        if (!CanRender())
        {
            return false;
        }

        if (_view == null)
        {
            _view = CreateView((NoesisRive)target);
        }

        if (_view == null || _view.Content == null)
        {
            return false;
        }

        return true;
    }

    public override bool RequiresConstantRepaint()
    {
        return true;
    }

    public override void OnPreviewGUI(UnityEngine.Rect r, GUIStyle background)
    {
        if (Event.current.type == EventType.Repaint)
        {
            if (CanRender())
            {
                if (r.width > 4 && r.height > 4)
                {
                    if (_view != null && _view.Content != null)
                    {
                        UnityEngine.GUI.DrawTexture(r, RenderPreview(_view, (int)r.width, (int)r.height));
                    }
                }
            }
        }
        else
        {
            if (_view != null)
            {
                int x = (int)(Event.current.mousePosition.x - r.x);
                int y = (int)(Event.current.mousePosition.y - r.y);
                Noesis.MouseButton button = (Noesis.MouseButton)Event.current.button;

                switch (Event.current.type)
                {
                    case UnityEngine.EventType.MouseDown:
                    {
                        _view.MouseButtonDown(x, y, button);
                        break;
                    }
                    case UnityEngine.EventType.MouseUp:
                    {
                        _view.MouseButtonUp(x, y, button);
                        break;
                    }
                }
            }
        }
    }

    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        if (CanRender())
        {
            if (_viewIcon == null)
            {
                _viewIcon = CreateView((NoesisRive)target);
            }

            if (_viewIcon != null && _viewIcon.Content != null)
            {
                #if DEBUG_IMPORTER
                    Debug.Log($"=> RenderStaticPreview {assetPath}");
                #endif

                RenderTexture rt = RenderPreview(_viewIcon, width, height);

                if (rt != null)
                {
                    RenderTexture prev = RenderTexture.active;
                    RenderTexture.active = rt;

                    Texture2D tex = new Texture2D(width, height);
                    tex.ReadPixels(new UnityEngine.Rect(0, 0, width, height), 0, 0);
                    tex.Apply(true);

                    RenderTexture.active = prev;
                    return tex;
                }
            }
        }

        return null;
    }

    private RenderTexture RenderPreview(Noesis.View view, int width, int height)
    {
        try
        {
            if (CanRender() && view != null && view.Content != null)
            {
                NoesisRenderer.SetRenderSettings();

                view.SetSize(width, height);
                view.Update(0.0f);

                NoesisRenderer.UpdateRenderTree(view, _commands);
                NoesisRenderer.RenderOffscreen(view, _commands, false);

                RenderTexture rt = RenderTexture.GetTemporary(width, height, 24, RenderTextureFormat.Default, RenderTextureReadWrite.Default, 8);
                _commands.SetRenderTarget(rt);
                _commands.ClearRenderTarget(true, true, UnityEngine.Color.clear, 0.0f);
                NoesisRenderer.RenderOnscreen(view, false, _commands, true);

                Graphics.ExecuteCommandBuffer(_commands);
                _commands.Clear();

                RenderTexture.ReleaseTemporary(rt);
                return rt;
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogException(e);
        }

        return null;
    }
}
