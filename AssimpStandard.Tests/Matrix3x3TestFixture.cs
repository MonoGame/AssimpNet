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

using System;
using Xunit;
using OpenToolkit.Mathematics;
using FluentAssertions;

namespace Assimp.Test
{
    public class Matrix3x3TestFixture
    {
        [Fact]
        public void TestIndexer()
        {
            float[] values = new float[] { 1.0f, 2.0f, 3.0f, 0.0f, -5.0f, .5f, .3f, .35f, .025f };

            Matrix3x3 m = Matrix3x3.Identity;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    float value = values[(i * 3) + j];
                    //Matrix indices are one-based.
                    m[i + 1, j + 1] = value;
                    TestHelper.AssertEquals(value, m[i + 1, j + 1], String.Format("Testing [{0},{1}] indexer.", i + 1, j + 1));
                }
            }
        }

        [Fact]
        public void TestEquals()
        {
            Matrix3x3 m1 = new Matrix3x3(1.0f, 2.0f, 3.0f, 0.0f, -5.0f, .5f, .3f, .35f, .025f);
            Matrix3x3 m2 = new Matrix3x3(1.0f, 2.0f, 3.0f, 0.0f, -5.0f, .5f, .3f, .35f, .025f);
            Matrix3x3 m3 = new Matrix3x3(0.0f, 2.0f, 25.0f, 1.0f, 5.0f, 5.5f, 1.25f, 8.5f, 2.25f);

            //Test IEquatable Equals
            m1.Equals(m2).Should().BeTrue();
            m1.Equals(m3).Should().BeFalse();

            //Test object equals override
            m1.Equals((object)m2).Should().BeTrue();
            m1.Equals((object)m3).Should().BeFalse();

            //Test op equals
            (m1 == m2).Should().BeTrue();
            (m1 == m2).Should().BeFalse();

            //Test op not equals
            (m1 != m3).Should().BeTrue();
            (m1 != m2).Should().BeFalse();
        }

        [Fact]
        public void TestDeterminant()
        {
            float x = MathHelper.Pi;
            float y = MathHelper.PiOver3;

            Matrix4 tkM = Matrix4.CreateRotationX(x) * Matrix4.CreateRotationY(y);
            Matrix3x3 m = Matrix3x3.FromRotationX(x) * Matrix3x3.FromRotationY(y);

            float tkDet = tkM.Determinant;
            float det = m.Determinant();
            TestHelper.AssertEquals(tkDet, det, "Testing determinant");
        }

        [Fact]
        public void TestFromAngleAxis()
        {
            Matrix4 tkM = Matrix4.CreateFromAxisAngle(Vector3.UnitY, MathHelper.Pi);
            Matrix3x3 m = Matrix3x3.FromAngleAxis(MathHelper.Pi, new Vector3D(0, 1, 0));

            TestHelper.AssertEquals(tkM, m, "Testing from angle axis");
        }

        [Fact]
        public void TestFromEulerAnglesXYZ()
        {
            float x = MathHelper.Pi;
            float y = 0.0f;
            float z = MathHelper.PiOver4;

            Matrix4 tkM = Matrix4.CreateRotationX(x) * Matrix4.CreateRotationZ(z);
            Matrix3x3 m = Matrix3x3.FromEulerAnglesXYZ(x, y, z);
            Matrix3x3 m2 = Matrix3x3.FromEulerAnglesXYZ(new Vector3D(x, y, z));

            TestHelper.AssertEquals(tkM, m, "Testing create from euler angles");
            m.Should().Be(m2);
        }

        [Fact]
        public void TestFromRotationX()
        {
            float x = MathHelper.Pi;

            Matrix4 tkM = Matrix4.CreateRotationX(x);
            Matrix3x3 m = Matrix3x3.FromRotationX(x);

            TestHelper.AssertEquals(tkM, m, "Testing from rotation x");
        }

        [Fact]
        public void TestFromRotationY()
        {
            float y = MathHelper.Pi;

            Matrix4 tkM = Matrix4.CreateRotationY(y);
            Matrix3x3 m = Matrix3x3.FromRotationY(y);

            TestHelper.AssertEquals(tkM, m, "Testing from rotation y");
        }

        [Fact]
        public void TestFromRotationZ()
        {
            float z = MathHelper.Pi;

            Matrix4 tkM = Matrix4.CreateRotationZ(z);
            Matrix3x3 m = Matrix3x3.FromRotationZ(z);

            TestHelper.AssertEquals(tkM, m, "Testing from rotation z");
        }

        [Fact]
        public void TestFromScaling()
        {
            float x = 1.0f;
            float y = 2.0f;
            float z = 3.0f;

            Matrix4 tkM = Matrix4.CreateScale(x, y, z);
            Matrix3x3 m = Matrix3x3.FromScaling(new Vector3D(x, y, z));

            TestHelper.AssertEquals(tkM, m, "Testing from scaling");
        }

        [Fact]
        public void TestFromToMatrix()
        {
            Vector3D from = new Vector3D(1, 0, 0);
            Vector3D to = new Vector3D(0, 1, 0);

            Matrix4 tkM = Matrix4.CreateRotationZ(-MathHelper.PiOver2);
            Matrix3x3 m = Matrix3x3.FromToMatrix(to, from);

            TestHelper.AssertEquals(tkM, m, "Testing From-To rotation matrix");
        }

        [Fact]
        public void TestToFromQuaternion()
        {
            Vector3D axis = new Vector3D(.25f, .5f, 0.0f);
            axis.Normalize();

            float angle = (float) Math.PI;

            Quaternion q = new Quaternion(axis, angle);
            Matrix3x3 m = q.GetMatrix();
            Quaternion q2 = new Quaternion(m);

            TestHelper.AssertEquals(q.X, q.Y, q.Z, q.W, q2, "Testing Quaternion->Matrix->Quaternion");
        }

        [Fact]
        public void TestInverse()
        {
            float x = MathHelper.PiOver6;
            float y = MathHelper.Pi;

            Matrix4 tkM = Matrix4.CreateRotationX(x) * Matrix4.CreateRotationY(y);
            Matrix3x3 m = Matrix3x3.FromRotationX(x) * Matrix3x3.FromRotationY(y);

            tkM.Invert();
            m.Inverse();

            TestHelper.AssertEquals(tkM, m, "Testing inverse");
        }

        [Fact]
        public void TestIdentity()
        {
            Matrix4 tkM = Matrix4.Identity;
            Matrix3x3 m = Matrix3x3.Identity;

            m.IsIdentity.Should().BeTrue();
            TestHelper.AssertEquals(tkM, m, "Testing is identity to baseline");
        }

        [Fact]
        public void TestTranspose()
        {
            float x = MathHelper.Pi;
            float y = MathHelper.PiOver4;

            Matrix4 tkM = Matrix4.CreateRotationX(x) * Matrix4.CreateRotationY(y);
            Matrix3x3 m = Matrix3x3.FromRotationX(x) * Matrix3x3.FromRotationY(y);

            tkM.Transpose();
            m.Transpose();
            TestHelper.AssertEquals(tkM, m, "Testing transpose");
        }

        [Fact]
        public void TestOpMultiply()
        {
            float x = MathHelper.Pi;
            float y = MathHelper.PiOver3;

            Matrix4 tkM = Matrix4.CreateRotationX(x) * Matrix4.CreateRotationY(y);
            Matrix3x3 m = Matrix3x3.FromRotationX(x) * Matrix3x3.FromRotationY(y);

            TestHelper.AssertEquals(tkM, m, "Testing Op multiply");
        }
    }
}
