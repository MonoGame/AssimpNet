/*
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

using FluentAssertions;
using System;
using System.IO;
using Xunit;

namespace Assimp.Test
{
    public class ExportDataBlobTestFixture
    {
        [Fact]
        public void TestToStream()
        {
            String path = Path.Combine(TestHelper.RootPath, "TestFiles/duck.dae");

            AssimpContext importer = new AssimpContext();
            ExportDataBlob blob = importer.ConvertFromFileToBlob(path, "obj");

            blob.Should().NotBeNull();

            MemoryStream stream = new MemoryStream();
            blob.ToStream(stream);

            stream.Length.Should().NotBe(0);
            stream.Position = 0;

            ExportDataBlob blob2 = ExportDataBlob.FromStream(stream);

            blob2.Should().NotBeNull();

            if(blob.NextBlob != null)
            {
                blob2.NextBlob.Should().NotBeNull();
                blob2.NextBlob.Name.Should().Be(blob.NextBlob.Name);
                blob2.NextBlob.Data.Length.Should().Be(blob.NextBlob.Data.Length);
            }
        }
    }
}
