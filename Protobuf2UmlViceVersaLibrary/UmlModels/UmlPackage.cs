using System;
using System.Collections.Generic;
using System.Text;

namespace Protobuf2UmlViceVersaLibrary.UmlModels
{
	public class UmlPackage
	{
		public UmlModel UmlModel { get; set; }
		public string Name { get; }

		public UmlPackage(string name)
		{
			Name = name;
		}
	}
}
