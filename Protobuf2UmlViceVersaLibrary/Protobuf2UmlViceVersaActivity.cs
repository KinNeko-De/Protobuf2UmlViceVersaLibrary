using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using Protobuf2UmlViceVersaLibrary.Exporters;
using Protobuf2UmlViceVersaLibrary.UmlModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Protobuf2UmlViceVersaLibrary
{
	public class Protobuf2UmlViceVersaActivity
	{
		private readonly IUmlModelFactory umlModelFactory;
		private readonly IUmlExporter umlExporter;

		public Protobuf2UmlViceVersaActivity(IUmlModelFactory umlModelFactory, IUmlExporter umlExporter)
		{
			this.umlModelFactory = umlModelFactory;
			this.umlExporter = umlExporter;
		}

		public void Protobuf2Uml(string pathToCompileProtobufModel)
		{
			IReadOnlyCollection<FileDescriptorProto> fileDescriptorProtos = ReadCompiledProtobufModel(pathToCompileProtobufModel);
			foreach (var fileDescriptorProto in fileDescriptorProtos)
			{
				// TODO support multiple files better ;)
				if (fileDescriptorProto != null)
				{
					var umlPackage = umlModelFactory.CreateUmlPackage(fileDescriptorProto);
					umlExporter.Export(umlPackage);
				}
			}
		
		}

		public void Protobuf2Uml2(string pathToCompileProtobufModel)
		{
			IReadOnlyCollection<FileDescriptor> fileDescriptors = ReadCompiledProtobufModel2(pathToCompileProtobufModel);
			foreach (var fileDescriptor in fileDescriptors)
			{
				// TODO support multiple files better ;)
				if (fileDescriptor != null)
				{
					var umlPackage = umlModelFactory.CreateUmlPackage(fileDescriptor);
					umlExporter.Export(umlPackage);
				}
			}

		}

		private IReadOnlyCollection<FileDescriptorProto> ReadCompiledProtobufModel(string pathToCompileProtobufModel)
		{
			using (var stream = File.OpenRead(pathToCompileProtobufModel))
			{
				FileDescriptorSet descriptorSet = FileDescriptorSet.Parser.ParseFrom(stream);
				RepeatedField<FileDescriptorProto> descriptorsProto = descriptorSet.File;
				var result = new FileDescriptorProto[descriptorsProto.Capacity];
				descriptorsProto.CopyTo(result, 0);
				return result;
			}
		}

		private IReadOnlyCollection<FileDescriptor> ReadCompiledProtobufModel2(string pathToCompileProtobufModel)
		{
			using (var stream = File.OpenRead(pathToCompileProtobufModel))
			{
				FileDescriptorSet descriptorSet = FileDescriptorSet.Parser.ParseFrom(stream);
				var byteStrings = descriptorSet.File.Select(f => f.ToByteString()).ToList();
				var descriptors = FileDescriptor.BuildFromByteStrings(byteStrings);
				return descriptors;
			}
		}
	}

	
}
