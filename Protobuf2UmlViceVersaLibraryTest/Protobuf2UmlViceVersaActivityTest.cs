using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Protobuf2UmlViceVersaLibraryTest
{
	internal partial class Protobuf2UmlViceVersaActivityTest
	{
		[Test]
		public void Test()
		{
			var testCaseData = fixture.TestCaseData.ExtractProtobufModel(fixture.TestCaseData.SimpleProtobufModel);
			var test = fixture.CreateSystemUnderTest();
			test.Protobuf2Uml(testCaseData);
		}

		[Test]
		public void PlantUmlTest()
		{
			var testCaseData = fixture.TestCaseData.ExtractProtobufModel(fixture.TestCaseData.ChatProtobufModel);
			var test = fixture.CreateSystemUnderTestWithPlantUml();
			test.Protobuf2Uml2(testCaseData);
		}
	}
}
