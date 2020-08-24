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

using FluentAssertions;
using System;
using Xunit;

namespace Assimp.Test
{
    public class Vector2DTestFixture
    {
        [Fact]
        public void TestIndexer()
        {
            float x = 1, y = 2;
            Vector2D v = new Vector2D();
            v[0] = x;
            v[1] = y;
            TestHelper.AssertEquals(x, v[0], "Test Indexer, X");
            TestHelper.AssertEquals(y, v[1], "Test Indexer, Y");
        }

        [Fact]
        public void TestSet()
        {
            float x = 10.5f, y = 109.21f;
            Vector2D v = new Vector2D();
            v.Set(x, y);

            TestHelper.AssertEquals(x, y, v, "Test v.Set()");
        }

        [Fact]
        public void TestEquals()
        {
            float x = 1, y = 2;
            float x2 = 3, y2 = 4;

            Vector2D v1 = new Vector2D(x, y);
            Vector2D v2 = new Vector2D(x, y);
            Vector2D v3 = new Vector2D(x2, y2);

            //Test IEquatable Equals
            v1.Equals(v2).Should().BeTrue();
            v1.Equals(v3).Should().BeFalse();

            //Test object equals override
            v1.Equals((object)v2).Should().BeTrue();
            v1.Equals((object)v3).Should().BeFalse();

            //Test op equals
            (v1 == v2).Should().BeTrue();
            (v1 == v2).Should().BeFalse();

            //Test op not equals
            (v1 != v3).Should().BeTrue();
            (v1 != v2).Should().BeFalse();
        }

        [Fact]
        public void TestLength()
        {
            float x = -62, y = 5;

            Vector2D v = new Vector2D(x, y);
            Math.Sqrt(x * x + y * y).Should().Be(v.Length());
        }

        [Fact]
        public void TestLengthSquared()
        {
            float x = -5, y = 25f;

            Vector2D v = new Vector2D(x, y);
            Math.Sqrt(x * x + y * y).Should().Be(v.Length());
        }

        [Fact]
        public void TestNegate()
        {
            float x = 2, y = 5;

            Vector2D v = new Vector2D(x, y);
            v.Negate();
            TestHelper.AssertEquals(-x, -y, v, "Testing v.Negate()");
        }

        [Fact]
        public void TestNormalize()
        {
            float x = 5, y = 12;
            Vector2D v = new Vector2D(x, y);
            v.Normalize();
            float invLength = 1.0f / (float) System.Math.Sqrt((x * x) + (y * y));
            x *= invLength;
            y *= invLength;

            TestHelper.AssertEquals(x, y, v, "Testing v.Normalize()");
        }

        [Fact]
        public void TestOpAdd()
        {
            float x1 = 2, y1 = 5;
            float x2 = 10, y2 = 15;
            float x = x1 + x2;
            float y = y1 + y2;

            Vector2D v1 = new Vector2D(x1, y1);
            Vector2D v2 = new Vector2D(x2, y2);

            Vector2D v = v1 + v2;

            TestHelper.AssertEquals(x, y, v, "Testing v1 + v2");
        }

        [Fact]
        public void TestOpSubtract()
        {
            float x1 = 2, y1 = 5;
            float x2 = 10, y2 = 15;
            float x = x1 - x2;
            float y = y1 - y2;

            Vector2D v1 = new Vector2D(x1, y1);
            Vector2D v2 = new Vector2D(x2, y2);

            Vector2D v = v1 - v2;

            TestHelper.AssertEquals(x, y, v, "Testing v1 - v2");
        }

        [Fact]
        public void TestOpNegate()
        {
            float x = 22, y = 75;

            Vector2D v = -(new Vector2D(x, y));

            TestHelper.AssertEquals(-x, -y, v, "Testting -v)");
        }

        [Fact]
        public void TestOpMultiply()
        {
            float x1 = 2, y1 = 5;
            float x2 = 10, y2 = 15;
            float x = x1 * x2;
            float y = y1 * y2;

            Vector2D v1 = new Vector2D(x1, y1);
            Vector2D v2 = new Vector2D(x2, y2);

            Vector2D v = v1 * v2;

            TestHelper.AssertEquals(x, y, v, "Testing v1 * v2");
        }

        [Fact]
        public void TestOpMultiplyByScalar()
        {
            float x1 = 2, y1 = 5;
            float scalar = 25;

            float x = x1 * scalar;
            float y = y1 * scalar;

            Vector2D v1 = new Vector2D(x1, y1);

            //Left to right
            Vector2D v = v1 * scalar;
            TestHelper.AssertEquals(x, y, v, "Testing v * scale");

            //Right to left
            v = scalar * v1;
            TestHelper.AssertEquals(x, y, v, "Testing scale * v");
        }

        [Fact]
        public void TestOpDivide()
        {
            float x1 = 105f, y1 = 4.5f;
            float x2 = 22f, y2 = 25.2f;

            float x = x1 / x2;
            float y = y1 / y2;

            Vector2D v1 = new Vector2D(x1, y1);
            Vector2D v2 = new Vector2D(x2, y2);

            Vector2D v = v1 / v2;

            TestHelper.AssertEquals(x, y, v, "Testing v1 / v2");
        }

        [Fact]
        public void TestOpDivideByFactor()
        {
            float x1 = 55f, y1 = 2f;
            float divisor = 5f;

            float x = x1 / divisor;
            float y = y1 / divisor;

            Vector2D v = new Vector2D(x1, y1) / divisor;

            TestHelper.AssertEquals(x, y, v, "Testing v / divisor");
        }
    }
}
