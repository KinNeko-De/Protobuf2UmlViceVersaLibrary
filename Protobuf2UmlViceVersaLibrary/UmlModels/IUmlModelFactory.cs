using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Protobuf2UmlViceVersaLibrary.UmlModels
{
	public interface IUmlModelFactory
	{
		public UmlPackage CreateUmlPackage(FileDescriptorProto fileDescriptorProto);

		public UmlPackage CreateUmlPackage(FileDescriptor fileDescriptor);
	}
}
