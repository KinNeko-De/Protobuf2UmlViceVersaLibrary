using System;
using System.Collections.Generic;
using System.Text;

namespace Protobuf2UmlViceVersaLibrary.UmlModels
{
	public class UmlClass
	{
		public IList<UmlMethod> UmlMethods { get; } = new List<UmlMethod>();
		public IList<UmlField> UmlFields { get; } = new List<UmlField>();


		public UmlClass(string name)
		{
			Name = name;
		}

		public string Name { get; }

		public bool HasStereotype { get; private set; }

		private string stereotype;
		public string Stereotype { get { return stereotype; } set { HasStereotype = true; stereotype = value; } }
	}
}
