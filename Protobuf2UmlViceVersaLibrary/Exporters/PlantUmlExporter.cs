using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Protobuf2UmlViceVersaLibrary.UmlModels;

namespace Protobuf2UmlViceVersaLibrary.Exporters
{
	public class PlantUmlExporter : IUmlExporter
	{
		private readonly ILogger<PlantUmlExporter> logger;

		public PlantUmlExporter(ILogger<PlantUmlExporter> logger)
		{
			this.logger = logger;
		}

		public void Export(UmlPackage umlPackage)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("skinparam monochrome true");
			stringBuilder.AppendLine($"package {umlPackage.Name}");
			stringBuilder.AppendLine("{");
			foreach (var umlClass in umlPackage.UmlModel.UmlClasses)
			{
				BuildClass(stringBuilder, umlClass);
			}
			stringBuilder.AppendLine("}");
			Console.WriteLine(stringBuilder.ToString());
		}

		private void BuildClass(StringBuilder stringBuilder, UmlClass umlClass)
		{
			string stereotype = umlClass.HasStereotype? $" << {umlClass.Stereotype} >>" : string.Empty;
			stringBuilder.AppendLine($"class {umlClass.Name}{stereotype}");
			stringBuilder.AppendLine("{");
			foreach (var umlField in umlClass.UmlFields)
			{
				BuildField(stringBuilder, umlField);
			}
			foreach (var umlMethod in umlClass.UmlMethods)
			{
				BuildMethod(stringBuilder, umlMethod);
			}
			stringBuilder.AppendLine("}");
		}

		private void BuildField(StringBuilder stringBuilder, UmlField umlField)
		{
			stringBuilder.AppendLine($"   {umlField.Name} : {umlField.Type}");
		}

		private void BuildMethod(StringBuilder stringBuilder, UmlMethod umlMethod)
		{
			stringBuilder.AppendLine($"   {umlMethod.OutputType} {umlMethod.Name}({umlMethod.InputType})");
		}
	}
}
