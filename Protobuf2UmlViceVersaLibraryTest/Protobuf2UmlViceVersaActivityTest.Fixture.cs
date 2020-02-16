using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using Protobuf2UmlViceVersaLibrary;
using Protobuf2UmlViceVersaLibrary.Exporters;
using Protobuf2UmlViceVersaLibrary.UmlModels;
using Protobuf2UmlViceVersaLibraryTest.TestCaseData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Protobuf2UmlViceVersaLibraryTest
{
	[TestFixture]
	internal partial class Protobuf2UmlViceVersaActivityTest
	{
		Fixture fixture;
		OneTimeFixture oneTimeFixture;

		[SetUp]
		public void SetUp()
		{
			fixture = new Fixture();
		}

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			oneTimeFixture = new OneTimeFixture();
		}

		[TearDown]
		public void TearDown()
		{
			fixture.Dispose();
			fixture = null;
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			oneTimeFixture.Dispose();
			oneTimeFixture = null;
		}

		internal class OneTimeFixture : IDisposable
		{	
			public void Dispose()
			{
			}
		}

		private class Fixture : IDisposable
		{
			internal TestCaseData TestCaseData { get; } = new TestCaseData();
			internal Mocks Mocks { get; } = new Mocks();

			public Protobuf2UmlViceVersaActivity CreateSystemUnderTest()
			{
				return new Protobuf2UmlViceVersaActivity(new UmlModelFactory(), Mocks.UmlExporterMock);
			}

			public Protobuf2UmlViceVersaActivity CreateSystemUnderTestWithPlantUml()
			{
				return new Protobuf2UmlViceVersaActivity(new UmlModelFactory(), new PlantUmlExporter(new NullLogger<PlantUmlExporter>()));
			}

			public void Dispose()
			{
				TestCaseData.Dispose();
			}
		}

		private class TestCaseData : IDisposable
		{
			private readonly string namespaceForEmbbededResources = typeof(Protobuf2UmlViceVersaActivityTest).Namespace + ".TestCaseData";

			public string SimpleProtobufModel { get; } = "mymodel";
			public string ChatProtobufModel { get; } = "example.chat";

			public string testCaseDataPath;

			public string ExtractProtobufModel(string embeddedResourceName)
			{
				CreateTestCaseDataPath();
				EmbeddedResourceExtensions.CopyEmbeddedResource(namespaceForEmbbededResources, embeddedResourceName, testCaseDataPath);
				return Path.Combine(testCaseDataPath, embeddedResourceName);
			}

			private void CreateTestCaseDataPath()
			{
				if (testCaseDataPath == null)
				{
					testCaseDataPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
					Directory.CreateDirectory(testCaseDataPath);
				}
			}

			public void Dispose()
			{
				if(testCaseDataPath != null)
				{
					Directory.Delete(testCaseDataPath, true);
				}
			}
		}

		private class Mocks
		{
			public IUmlExporter UmlExporterMock { get; } = NSubstitute.Substitute.For<IUmlExporter>();
		}
	}
}
