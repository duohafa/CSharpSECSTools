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
	public class I8SECSItemTests
	{
		[Test()]
		public void test01()
		{
			byte[] input = {0x00};

			var exception = Assert.Catch(() => new I8SECSItem(input, 0));

			Assert.IsInstanceOf<ArgumentOutOfRangeException>(exception);
		}

		[Test()]
		public void test02()
		{
			byte[] input = {};

			var exception = Assert.Catch(() => new I8SECSItem(input, 0));

			Assert.IsInstanceOf<ArgumentOutOfRangeException>(exception);
		}

		[Test()]
		public void test03()
		{
			byte[] input = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.I8 ) << 2) | 0x01), 0x08, 255, 255, 255, 255, 255, 255, 255, 255 };
			Int64 expectedOutput = -1;
			I8SECSItem secsItem = new I8SECSItem(input, 0);
			Assert.IsTrue(secsItem.getValue() == expectedOutput);
		}

		[Test()]
		public void test04()
		{
			byte[] input = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.I8 ) << 2) | 0x01), 0x08, 128, 0, 0, 0, 0, 0, 0, 0 };
			Int64 expectedOutput = -9223372036854775808L;
			I8SECSItem secsItem = new I8SECSItem(input, 0);
			Assert.IsTrue(secsItem.getValue() == expectedOutput);
		}

		[Test()]
		public void test05()
		{
			byte[] input = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.I8 ) << 2) | 0x01), 0x08, 0, 0, 0, 0, 0, 0, 0, 0 };
			Int64 expectedOutput = 0;
			I8SECSItem secsItem = new I8SECSItem(input, 0);
			Assert.IsTrue(secsItem.getValue() == expectedOutput);
		}

		[Test()]
		public void test06()
		{
			byte[] input = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.I8 ) << 2) | 0x01), 0x08, 0, 0, 0, 0, 0, 0, 0, 1 };
			Int64 expectedOutput = 1;
			I8SECSItem secsItem = new I8SECSItem(input, 0);
			Assert.IsTrue(secsItem.getValue() == expectedOutput);
		}

		[Test()]
		public void test07()
		{
			byte[] input = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.I8 ) << 2) | 0x01), 0x08, 127, 255, 255, 255, 255, 255, 255, 255 };
			Int64 expectedOutput = 9223372036854775807L;
			I8SECSItem secsItem = new I8SECSItem(input, 0);
			Assert.IsTrue(secsItem.getValue() == expectedOutput);
		}

		[Test()]
		public void test08()
		{
			Int64 expectedOutput = 9223372036854775807L;
			I8SECSItem secsItem = new I8SECSItem(expectedOutput);
			Assert.IsTrue(secsItem.getValue() == expectedOutput);
		}

		[Test()]
		public void test09()
		{
			byte[] input = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.I8 ) << 2) | 0x01), 0x08, 255, 255, 255, 255, 255, 255, 255, 255 };
			I8SECSItem secsItem = new I8SECSItem(input, 0);
			Assert.IsTrue(secsItem.getSECSItemFormatCode() == SECSItemFormatCode.I8);
		}

		[Test()]
		public void test10()
		{
			Int64 expectedOutput = 9223372036854775807L;
			I8SECSItem secsItem = new I8SECSItem(expectedOutput);
			Assert.IsTrue(secsItem.getSECSItemFormatCode() == SECSItemFormatCode.I8);
		}

		[Test()]
		public void test11()
		{
			byte[] expectedResult = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.I8 ) << 2) | 0x01), 0x08, 127, 255, 255, 255, 255, 255, 255, 255 };

			I8SECSItem secsItem = new I8SECSItem(9223372036854775807L);
			Assert.IsTrue(secsItem.ToRawSECSItem().SequenceEqual(expectedResult));
		}

		[Test()]
		public void test12()
		{
			byte[] expectedResult = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.I8 ) << 2) | 0x02), 0, 0x08, 127, 255, 255, 255, 255, 255, 255, 255 };

			I8SECSItem secsItem = new I8SECSItem(9223372036854775807L, 2);
			Assert.IsTrue(secsItem.ToRawSECSItem().SequenceEqual(expectedResult));
		}

		[Test()]
		public void test13()
		{
			byte[] expectedResult = { (byte)((SECSItemFormatCodeFunctions.getNumberFromSECSItemFormatCode(SECSItemFormatCode.I8 ) << 2) | 0x03), 0, 0, 0x08, 127, 255, 255, 255, 255, 255, 255, 255 };

			I8SECSItem secsItem = new I8SECSItem(9223372036854775807L, 3);
			Assert.IsTrue(secsItem.ToRawSECSItem().SequenceEqual(expectedResult));
		}

	}
}

