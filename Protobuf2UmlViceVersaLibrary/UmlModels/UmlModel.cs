using System;
using System.Collections.Generic;
using System.Text;

namespace Protobuf2UmlViceVersaLibrary.UmlModels
{
	public class UmlModel
	{
		public IList<UmlClass> UmlClasses { get; } = new List<UmlClass>();
	}
}
