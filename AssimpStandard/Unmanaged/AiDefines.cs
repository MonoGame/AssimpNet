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

namespace Assimp.Unmanaged
{
    /// <summary>
    /// Static class that has a number of constants that are found in Assimp. These can be limits to configuration property default values. The constants
    /// are grouped according to their usage or where they're found in the Assimp include files.
    /// </summary>
    public static class AiDefines
    {

        #region Config Defaults

        /// <summary>
        /// Default value for <see cref="AiConfigs.AI_CONFIG_PP_SLM_TRIANGLE_LIMIT"/>.
        /// </summary>
        public const int AI_SLM_DEFAULT_MAX_TRIANGLES = 1000000;

        /// <summary>
        /// Default value for <see cref="AiConfigs.AI_CONFIG_PP_SLM_VERTEX_LIMIT"/>.
        /// </summary>
        public const int AI_SLM_DEFAULT_MAX_VERTICES = 1000000;

        /// <summary>
        /// Default value for <see cref="AiConfigs.AI_CONFIG_PP_LBW_MAX_WEIGHTS"/>.
        /// </summary>
        public const int AI_LBW_MAX_WEIGHTS = 0x4;

        /// <summary>
        /// Default value for <see cref="AiConfigs.AI_CONFIG_PP_ICL_PTCACHE_SIZE"/>.
        /// </summary>
        public const int PP_ICL_PTCACHE_SIZE = 12;

        /// <summary>
        /// Default value for <see cref="AiConfigs.AI_CONFIG_PP_TUV_EVALUATE"/>
        /// </summary>
        public const int AI_UVTRAFO_ALL = (int) (UVTransformFlags.Rotation | UVTransformFlags.Scaling | UVTransformFlags.Translation);

        #endregion

        #region Mesh Limits

        /// <summary>
        /// Defines the maximum number of indices per face (polygon).
        /// </summary>
        public const int AI_MAX_FACE_INDICES = 0x7fff;

        /// <summary>
        /// Defines the maximum number of bone weights.
        /// </summary>
        public const int AI_MAX_BONE_WEIGHTS = 0x7fffffff;

        /// <summary>
        /// Defines the maximum number of vertices per mesh.
        /// </summary>
        public const int AI_MAX_VERTICES = 0x7fffffff;

        /// <summary>
        /// Defines the maximum number of faces per mesh.
        /// </summary>
        public const int AI_MAX_FACES = 0x7fffffff;

        /// <summary>
        /// Defines the maximum number of vertex color sets per mesh.
        /// </summary>
        public const int AI_MAX_NUMBER_OF_COLOR_SETS = 0x8;

        /// <summary>
        /// Defines the maximum number of texture coordinate sets (UV(W) channels) per mesh.
        /// </summary>
        public const int AI_MAX_NUMBER_OF_TEXTURECOORDS = 0x8;

        /// <summary>
        /// Defines the default bone count limit.
        /// </summary>
        public const int AI_SBBC_DEFAULT_MAX_BONES = 60;

        /// <summary>
        /// Defines the deboning threshold.
        /// </summary>
        public const float AI_DEBONE_THRESHOLD = 1.0f;

        #endregion

        #region Types limits

        /// <summary>
        /// Defines the maximum length of a string used in AiString.
        /// </summary>
        public const int MAX_LENGTH = 1024;

        #endregion

        #region Material limits

        /// <summary>
        /// Defines the default color material.
        /// </summary>
        public const String AI_DEFAULT_MATERIAL_NAME = "DefaultMaterial";

        /// <summary>
        /// Defines the default textured material (if the meshes have UV coords).
        /// </summary>
        public const String AI_DEFAULT_TEXTURED_MATERIAL_NAME = "TexturedDefaultMaterial";

        #endregion
    }
}
