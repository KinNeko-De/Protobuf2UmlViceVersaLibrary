using Protobuf2UmlViceVersaLibrary.UmlModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Protobuf2UmlViceVersaLibrary.Exporters
{
	public interface IUmlExporter
	{
		public void Export(UmlPackage umlPackage);
	}
}
