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

using Assimp.Configs;
using System.Collections.Generic;
using System.IO;

namespace Assimp
{
    public interface IAssimpContext
    {
        bool IsDisposed { get; }
        Dictionary<string, PropertyConfig> PropertyConfigurations { get; }
        float Scale { get; set; }
        bool UsingCustomIOSystem { get; }
        float XAxisRotation { get; set; }
        float YAxisRotation { get; set; }
        float ZAxisRotation { get; set; }

        bool ContainsConfig(string configName);
        ExportDataBlob ConvertFromFileToBlob(string inputFilename, PostProcessSteps importProcessSteps, string exportFormatId, PostProcessSteps exportProcessSteps);
        ExportDataBlob ConvertFromFileToBlob(string inputFilename, string exportFormatId);
        ExportDataBlob ConvertFromFileToBlob(string inputFilename, string exportFormatId, PostProcessSteps exportProcessSteps);
        bool ConvertFromFileToFile(string inputFilename, PostProcessSteps importProcessSteps, string outputFilename, string exportFormatId, PostProcessSteps exportProcessSteps);
        bool ConvertFromFileToFile(string inputFilename, string outputFilename, string exportFormatId);
        bool ConvertFromFileToFile(string inputFilename, string outputFilename, string exportFormatId, PostProcessSteps exportProcessSteps);
        ExportDataBlob ConvertFromStreamToBlob(Stream inputStream, string importFormatHint, PostProcessSteps importProcessSteps, string exportFormatId, PostProcessSteps exportProcessSteps);
        ExportDataBlob ConvertFromStreamToBlob(Stream inputStream, string importFormatHint, string exportFormatId);
        ExportDataBlob ConvertFromStreamToBlob(Stream inputStream, string importFormatHint, string exportFormatId, PostProcessSteps exportProcessSteps);
        bool ConvertFromStreamToFile(Stream inputStream, string importFormatHint, PostProcessSteps importProcessSteps, string outputFilename, string exportFormatId, PostProcessSteps exportProcessSteps);
        bool ConvertFromStreamToFile(Stream inputStream, string importFormatHint, string outputFilename, string exportFormatId);
        bool ConvertFromStreamToFile(Stream inputStream, string importFormatHint, string outputFilename, string exportFormatId, PostProcessSteps exportProcessSteps);
        void Dispose();
        bool ExportFile(Scene scene, string fileName, string exportFormatId);
        bool ExportFile(Scene scene, string fileName, string exportFormatId, PostProcessSteps preProcessing);
        ExportDataBlob ExportToBlob(Scene scene, string exportFormatId);
        ExportDataBlob ExportToBlob(Scene scene, string exportFormatId, PostProcessSteps preProcessing);
        ExportFormatDescription[] GetSupportedExportFormats();
        string[] GetSupportedImportFormats();
        Scene ImportFile(string file);
        Scene ImportFile(string file, PostProcessSteps postProcessFlags);
        Scene ImportFileFromStream(Stream stream, string formatHint = null);
        Scene ImportFileFromStream(Stream stream, PostProcessSteps postProcessFlags, string formatHint = null);
        bool IsExportFormatSupported(string format);
        bool IsImportFormatSupported(string format);
        void RemoveConfig(string configName);
        void RemoveConfigs();
        void RemoveIOSystem();
        void SetConfig(PropertyConfig config);
        void SetIOSystem(IOSystem ioSystem);
    }
}