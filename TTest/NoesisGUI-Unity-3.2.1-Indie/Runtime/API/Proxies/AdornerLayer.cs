//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class AdornerLayer : FrameworkElement {
  internal new static AdornerLayer CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new AdornerLayer(cPtr, cMemoryOwn);
  }

  internal AdornerLayer(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(AdornerLayer obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public AdornerLayer() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_AdornerLayer();
  }

  public static AdornerLayer GetAdornerLayer(Visual visual) {
    if (visual == null) throw new ArgumentNullException("visual");
    {
      IntPtr cPtr = NoesisGUI_PINVOKE.AdornerLayer_GetAdornerLayer(Visual.getCPtr(visual));
      return (AdornerLayer)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public void Add(Adorner adorner) {
    if (adorner == null) throw new ArgumentNullException("adorner");
    {
      NoesisGUI_PINVOKE.AdornerLayer_Add(swigCPtr, Adorner.getCPtr(adorner));
    }
  }

  public void Remove(Adorner adorner) {
    if (adorner == null) throw new ArgumentNullException("adorner");
    {
      NoesisGUI_PINVOKE.AdornerLayer_Remove(swigCPtr, Adorner.getCPtr(adorner));
    }
  }

  public void Update() {
    NoesisGUI_PINVOKE.AdornerLayer_Update__SWIG_0(swigCPtr);
  }

  public void Update(UIElement element) {
    NoesisGUI_PINVOKE.AdornerLayer_Update__SWIG_1(swigCPtr, UIElement.getCPtr(element));
  }

}

}
