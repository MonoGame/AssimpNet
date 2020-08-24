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

using NUnit.Framework;
using OpenToolkit.Mathematics;

namespace Assimp.Test
{
    using Quaternion = OpenToolkit.Mathematics.Quaternion;

    [TestFixture]
    public class QuaternionTestFixture
    {
        [Test]
        public void TestEquals()
        {
            Quaternion q1 = new Quaternion(.25f, .75f, .5f, 1.0f);
            Quaternion q2 = new Quaternion(.25f, .75f, .5f, 1.0f);
            Quaternion q3 = new Quaternion(.55f, .17f, 1.0f, .15f);

            //Test IEquatable Equals
            Assert.IsTrue(q1.Equals(q2), "Test IEquatable equals");
            Assert.IsFalse(q1.Equals(q3), "Test IEquatable equals");

            //Test object equals override
            Assert.IsTrue(q1.Equals((object) q2), "Tests object equals");
            Assert.IsFalse(q1.Equals((object) q3), "Tests object equals");

            //Test op equals
            Assert.IsTrue(q1 == q2, "Testing OpEquals");
            Assert.IsFalse(q1 == q3, "Testing OpEquals");

            //Test op not equals
            Assert.IsTrue(q1 != q3, "Testing OpNotEquals");
            Assert.IsFalse(q1 != q2, "Testing OpNotEquals");
        }

        [Test]
        public void TestConjugate()
        {
            Quaternion tkQ = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.PiOver2);
            Assimp.Quaternion q = new Assimp.Quaternion(tkQ.W, tkQ.X, tkQ.Y, tkQ.Z);

            tkQ.Conjugate();
            q.Conjugate();

            TestHelper.AssertEquals(tkQ.X, tkQ.Y, tkQ.Z, tkQ.W, q, "Testing conjugate");
        }

        [Test]
        public void TestGetMatrix()
        {
            Quaternion tkQ = Quaternion.FromAxisAngle(new Vector3(.25f, .5f, 0.0f), MathHelper.PiOver2);
            Assimp.Quaternion q = new Assimp.Quaternion(tkQ.W, tkQ.X, tkQ.Y, tkQ.Z);

            Matrix4 tkM = Matrix4.CreateFromAxisAngle(new Vector3(.25f, .5f, 0.0f), MathHelper.PiOver2);
            Matrix4x4 m = q.GetMatrix();

            TestHelper.AssertEquals(tkM, m, "Testing GetMatrix");
        }

        [Test]
        public void TestNormalize()
        {
            Quaternion tkQ = Quaternion.FromAxisAngle(new Vector3(.25f, .5f, 0.0f), MathHelper.PiOver2);
            Assimp.Quaternion q = new Assimp.Quaternion(tkQ.W, tkQ.X, tkQ.Y, tkQ.Z);

            tkQ.Normalize();
            q.Normalize();

            TestHelper.AssertEquals(tkQ.X, tkQ.Y, tkQ.Z, tkQ.W, q, "Testing normalize");
        }

        [Test]
        public void TestRotate()
        {
            Vector3 tkV1 = new Vector3(0, 5, 10);
            Vector3D v1 = new Vector3D(0, 5, 10);

            Quaternion tkQ = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.PiOver2);
            Assimp.Quaternion q = new Assimp.Quaternion(tkQ.W, tkQ.X, tkQ.Y, tkQ.Z);

            Vector3 tkV2 = Vector3.Transform(tkV1, tkQ);
            Vector3D v2 = Assimp.Quaternion.Rotate(v1, q);

            TestHelper.AssertEquals(tkV2.X, tkV2.Y, tkV2.Z, v2, "Testing rotate");
        }

        [Test]
        public void TestSlerp()
        {
            Quaternion tkQ1 = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.PiOver2);
            Assimp.Quaternion q1 = new Assimp.Quaternion(tkQ1.W, tkQ1.X, tkQ1.Y, tkQ1.Z);

            Quaternion tkQ2 = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.Pi);
            Assimp.Quaternion q2 = new Assimp.Quaternion(tkQ2.W, tkQ2.X, tkQ2.Y, tkQ2.Z);

            Assimp.Quaternion q = Assimp.Quaternion.Slerp(q1, q2, .5f);

            Quaternion tkQ = Quaternion.Slerp(tkQ1, tkQ2, .5f);

            TestHelper.AssertEquals(tkQ.X, tkQ.Y, tkQ.Z, tkQ.W, q, "Testing slerp");
        }

        [Test]
        public void TestOpMultiply()
        {
            Quaternion tkQ1 = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.PiOver2);
            Assimp.Quaternion q1 = new Assimp.Quaternion(tkQ1.W, tkQ1.X, tkQ1.Y, tkQ1.Z);

            Quaternion tkQ2 = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.Pi);
            Assimp.Quaternion q2 = new Assimp.Quaternion(tkQ2.W, tkQ2.X, tkQ2.Y, tkQ2.Z);

            Assimp.Quaternion q = q1 * q2;

            Quaternion tkQ = tkQ1 * tkQ2;

            TestHelper.AssertEquals(tkQ.X, tkQ.Y, tkQ.Z, tkQ.W, q, "Testing Op multiply");
        }
    }
}
