using System;
using System.Collections.Generic;
using System.Text;

namespace Protobuf2UmlViceVersaLibrary.UmlModels
{
	public class UmlMethod
	{
		public UmlMethod(string name)
		{
			Name = name;
		}

		public string Name { get; }

		public string InputType { get; set; }
		public string OutputType { get; set; }
	}
}
