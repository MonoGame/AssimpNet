﻿/*
* Copyright (c) 2012-2017 AssimpNet - Nicholas Woodfield
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using System;

namespace Assimp
{
    /// <summary>
    /// Internal usage only for fast-interop - used to find where we need to patch up code and is removed after the patching process.
    /// </summary>
    internal static class InternalInterop
    {
        public static unsafe void WriteArray<T>(IntPtr pDest, T[] data, int startIndex, int count) where T : struct
        {
            throw new NotImplementedException();
        }

        public static unsafe void ReadArray<T>(IntPtr pSrc, T[] data, int startIndex, int count) where T : struct
        {
            throw new NotImplementedException();
        }

        public static unsafe void WriteInline<T>(void* pDest, ref T srcData) where T : struct
        {
            throw new NotImplementedException();
        }

        public static unsafe T ReadInline<T>(void* pSrc) where T : struct
        {
            throw new NotImplementedException();
        }

        public static unsafe int SizeOfInline<T>()
        {
            throw new NotImplementedException();
        }

        public static unsafe void MemCopyInline(void* pDest, void* pSrc, int count)
        {
            throw new NotImplementedException();
        }

        public static unsafe void MemSetInline(void* pDest, byte value, int count)
        {
            throw new NotImplementedException();
        }
    }
}
