// Copyright (c) 2010-2011 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

namespace SharpDX.Direct3D9
{
    public partial class DeviceEx
    {
        /// <summary>	
        /// Creates a device to represent the display adapter.	
        /// </summary>	
        /// <remarks>	
        ///  This method returns a fully working device interface, set to the required display mode (or windowed), and allocated with the appropriate back buffers. To begin rendering, the application needs only to create and set a depth buffer (assuming EnableAutoDepthStencil is FALSE in <see cref="SharpDX.Direct3D9.PresentParameters"/>). When you create a Direct3D device, you supply two different window parameters: a focus window (hFocusWindow) and a device window (the hDeviceWindow in <see cref="SharpDX.Direct3D9.PresentParameters"/>). The purpose of each window is:  The focus window alerts Direct3D when an application switches from foreground mode to background mode (via Alt-Tab, a mouse click, or some other method). A single focus window is shared by each device created by an application. The device window determines the location and size of the back buffer on screen. This is used by Direct3D when the back buffer contents are copied to the front buffer during {{Present}}.  This method should not be run during the handling of WM_CREATE. An application should never pass a window handle to Direct3D while handling WM_CREATE.  Any call to create, release, or reset the device must be done using the same thread as the window procedure of the focus window. Note that D3DCREATE_HARDWARE_VERTEXPROCESSING, D3DCREATE_MIXED_VERTEXPROCESSING, and D3DCREATE_SOFTWARE_VERTEXPROCESSING are mutually exclusive flags, and at least one of these vertex processing flags must be specified when calling this method. Back buffers created as part of the device are only lockable if D3DPRESENTFLAG_LOCKABLE_BACKBUFFER is specified in the presentation parameters. (Multisampled back buffers and depth surfaces are never lockable.) The methods {{Reset}}, <see cref="SharpDX.ComObject"/>, and {{TestCooperativeLevel}} must be called from the same thread that used this method to create a device. D3DFMT_UNKNOWN can be specified for the windowed mode back buffer format when calling CreateDevice, {{Reset}}, and {{CreateAdditionalSwapChain}}. This means the application does not have to query the current desktop format before calling CreateDevice for windowed mode. For full-screen mode, the back buffer format must be specified. If you attempt to create a device on a 0x0 sized window, CreateDevice will fail. 	
        /// </remarks>
        /// <param name="direct3D">an instance of <see cref = "SharpDX.Direct3D9.Direct3D" /></param> 
        /// <param name="adapter"> Ordinal number that denotes the display adapter. {{D3DADAPTER_DEFAULT}} is always the primary display adapter.  </param>
        /// <param name="deviceType"> Member of the <see cref="SharpDX.Direct3D9.DeviceType"/> enumerated type that denotes the desired device type. If the desired device type is not available, the method will fail.  </param>
        /// <param name="hFocusWindow"> The focus window alerts Direct3D when an application switches from foreground mode to background mode. See Remarks. 	   For full-screen mode, the window specified must be a top-level window. For windowed mode, this parameter may be NULL only if the hDeviceWindow member of pPresentationParameters is set to a valid, non-NULL value.  </param>
        /// <param name="behaviorFlags"> Combination of one or more options that control device creation. For more information, see {{D3DCREATE}}. </param>
        /// <param name="resentationParametersRef"> Pointer to a <see cref="SharpDX.Direct3D9.PresentParameters"/> structure, describing the presentation parameters for the device to be created. If BehaviorFlags specifies {{D3DCREATE_ADAPTERGROUP_DEVICE}}, pPresentationParameters is an array. Regardless of the number of heads that exist, only one depth/stencil surface is automatically created. For Windows 2000 and Windows XP, the full-screen device display refresh rate is set in the following order:   User-specified nonzero ForcedRefreshRate registry key, if supported by the device. Application-specified nonzero refresh rate value in the presentation parameter. Refresh rate of the latest desktop mode, if supported by the device. 75 hertz if supported by the device. 60 hertz if supported by the device. Device default.  An unsupported refresh rate will default to the closest supported refresh rate below it.  For example, if the application specifies 63 hertz, 60 hertz will be used. There are no supported refresh rates below 57 hertz. pPresentationParameters is both an input and an output parameter. Calling this method may change several members including:  If BackBufferCount, BackBufferWidth, and BackBufferHeight  are 0 before the method is called, they will be changed when the method returns. If BackBufferFormat equals <see cref="SharpDX.Direct3D9.Format.Unknown"/> before the method is called, it will be changed when the method returns.  </param>
        /// <param name="returnedDeviceInterfaceRef"> Address of a pointer to the returned <see cref="SharpDX.Direct3D9.Device"/> interface, which represents the created device.  </param>
        /// <returns>  <see cref="int"/>  If the method succeeds, the return value is D3D_OK. If the method fails, the return value can be one of the following: D3DERR_DEVICELOST, D3DERR_INVALIDCALL, D3DERR_NOTAVAILABLE, D3DERR_OUTOFVIDEOMEMORY. </returns>
        /// <unmanaged>HRESULT CreateDevice([None] UINT Adapter,[None] D3DDEVTYPE DeviceType,[None] HWND hFocusWindow,[None] int BehaviorFlags,[None] D3DPRESENT_PARAMETERS* pPresentationParameters,[None] IDirect3DDevice9** ppReturnedDeviceInterface)</unmanaged>
        public DeviceEx(Direct3DEx direct3D, int adapter, SharpDX.Direct3D9.DeviceType deviceType, IntPtr hFocusWindow, CreateFlags behaviorFlags, params SharpDX.Direct3D9.PresentParameters[] presentationParametersRef) : base(IntPtr.Zero)
        {
            direct3D.CreateDeviceEx(adapter, deviceType, hFocusWindow, (int)behaviorFlags, presentationParametersRef, null, this);
        }
    }
}