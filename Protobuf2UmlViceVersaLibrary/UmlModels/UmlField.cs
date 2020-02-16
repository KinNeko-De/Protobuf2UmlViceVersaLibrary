using System;
using System.Collections.Generic;
using System.Text;

namespace Protobuf2UmlViceVersaLibrary.UmlModels
{
	public class UmlField
	{
		public UmlField(string name)
		{
			Name = name;
		}

		public string Name { get; }

		public string Type { get; set; }
	}
}
