﻿/*
 * Copyright 2019 Douglas Kaip
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Linq;
using NUnit.Framework;
using com.CIMthetics.CSharpSECSTools.SECSItems;

namespace SECSItemTests
{
	[TestFixture()]
	public class F8ArraySECSItemTests
	{
		[Test()]
		public void test01()
		{
			byte[] input = {0x00};

			var exception = Assert.Catch(() => new F8ArraySECSItem(input, 0));

			Assert.IsInstanceOf<ArgumentOutOfRangeException>(exception);
		}

		[Test()]
		public void test02()
		{
			byte[] input = {};

			var exception = Assert.Catch(() => new F8ArraySECSItem(input, 0));

			Assert.IsInstanceOf<ArgumentOutOfRangeException>(exception);
		}

		[Test()]
		public void test03()
		{
			byte[] input = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.F8 ) << 2) | 0x01), 40, 
				127, 0xEF, 255, 255, 255, 255, 255, 255,
				255, 0XEF, 255, 255, 255, 255, 255, 255,
				255, 0xF0, 0, 0, 0, 0, 0, 0,
				127, 0xF0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0 };
			F8ArraySECSItem secsItem = new F8ArraySECSItem(input, 0);
			Assert.IsTrue(secsItem.getValue()[0] == Double.MaxValue);
			Assert.IsTrue(secsItem.getValue()[1] == Double.MinValue);
			Assert.IsTrue(secsItem.getValue()[2] == Double.NegativeInfinity);
			Assert.IsTrue(secsItem.getValue()[3] == Double.PositiveInfinity);
			Assert.IsTrue(secsItem.getValue()[4] == 0.0D);
		}

		[Test()]
		public void test04()
		{
			byte[] input = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.F8 ) << 2) | 0x01), 40, 
				127, 0xEF, 255, 255, 255, 255, 255, 255,
				255, 0XEF, 255, 255, 255, 255, 255, 255,
				255, 0xF0, 0, 0, 0, 0, 0, 0,
				127, 0xF0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0 };
			F8ArraySECSItem secsItem = new F8ArraySECSItem(input, 0);
			Assert.IsTrue(secsItem.getSECSItemFormatCode() == SECSItemFormatCode.F8);
		}

		[Test()]
		public void test05()
		{
			double[] input = {Double.MaxValue, Double.MinValue, Double.NegativeInfinity, Double.PositiveInfinity, 0.0D};
			byte[] expectedResult = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.F8 ) << 2) | 0x01), 40, 
				127, 0xEF, 255, 255, 255, 255, 255, 255,
				255, 0XEF, 255, 255, 255, 255, 255, 255,
				255, 0xF0, 0, 0, 0, 0, 0, 0,
				127, 0xF0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0 };

			F8ArraySECSItem secsItem = new F8ArraySECSItem(input);
			Assert.IsTrue(secsItem.ToRawSECSItem().SequenceEqual(expectedResult));
		}

		[Test()]
		public void test06()
		{
			double[] input = {Double.MaxValue, Double.MinValue, Double.NegativeInfinity, Double.PositiveInfinity, 0.0D};
			byte[] expectedResult = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.F8 ) << 2) | 0x02), 0, 40, 
				127, 0xEF, 255, 255, 255, 255, 255, 255,
				255, 0XEF, 255, 255, 255, 255, 255, 255,
				255, 0xF0, 0, 0, 0, 0, 0, 0,
				127, 0xF0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0 };

			F8ArraySECSItem secsItem = new F8ArraySECSItem(input, 2);
			Assert.IsTrue(secsItem.ToRawSECSItem().SequenceEqual(expectedResult));
		}

		[Test()]
		public void test07()
		{
			double[] input = {Double.MaxValue, Double.MinValue, Double.NegativeInfinity, Double.PositiveInfinity, 0.0D};
			byte[] expectedResult = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.F8 ) << 2) | 0x03), 0, 0, 40, 
				127, 0xEF, 255, 255, 255, 255, 255, 255,
				255, 0XEF, 255, 255, 255, 255, 255, 255,
				255, 0xF0, 0, 0, 0, 0, 0, 0,
				127, 0xF0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0 };

			F8ArraySECSItem secsItem = new F8ArraySECSItem(input, 3);
			Assert.IsTrue(secsItem.ToRawSECSItem().SequenceEqual(expectedResult));
		}

	}
}

