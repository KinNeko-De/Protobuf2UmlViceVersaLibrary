using System;
using System.Collections.Generic;
using System.Text;
using Google.Protobuf.Reflection;

namespace Protobuf2UmlViceVersaLibrary.UmlModels
{
	public class UmlModelFactory : IUmlModelFactory
	{
		public virtual UmlPackage CreateUmlPackage(FileDescriptorProto fileDescriptorProto)
		{
			/*
			UmlPackage umlPackage = new UmlPackage(fileDescriptorProto.Package);
			UmlModel umlModel = CreateUmlModel(fileDescriptorProto);
			umlPackage.UmlModel = umlModel;
			return umlPackage;
			*/
			return null;
		}

		public virtual UmlPackage CreateUmlPackage(FileDescriptor fileDescriptor)
		{
			UmlPackage umlPackage = new UmlPackage(fileDescriptor.Package);
			UmlModel umlModel = CreateUmlModel(fileDescriptor);
			umlPackage.UmlModel = umlModel;
			return umlPackage;
		}

		private UmlModel CreateUmlModel(FileDescriptor fileDescriptor)
		{
			UmlModel umlModel = new UmlModel();
			CreateMessageTypes(fileDescriptor, umlModel);
			CreateServices(fileDescriptor, umlModel);
			return umlModel;
		}

		private void CreateServices(FileDescriptor fileDescriptor, UmlModel umlModel)
		{
			foreach (ServiceDescriptor protobufService in fileDescriptor.Services)
			{
				var umlService = CreateProfobufService(protobufService);
	
				umlModel.UmlClasses.Add(umlService);
			}
		}

		private void CreateMessageTypes(FileDescriptor fileDescriptor, UmlModel umlModel)
		{
			foreach (MessageDescriptor protobufMessageType in fileDescriptor.MessageTypes)
			{
				var messageType = CreateProfobufMessageType(protobufMessageType);
				umlModel.UmlClasses.Add(messageType);
			}
		}

		protected virtual UmlClass CreateProfobufService(ServiceDescriptor serviceDescriptor)
		{
			UmlClass umlClass = new UmlClass(serviceDescriptor.Name);
			umlClass.Stereotype = "ProtobufService";
			foreach (MethodDescriptor method in serviceDescriptor.Methods)
			{
				var umlMethod = CreateProtobufMethod(method);
				umlClass.UmlMethods.Add(umlMethod);
			}
			return umlClass;
		}

		protected virtual UmlClass CreateProfobufMessageType(MessageDescriptor messageDescriptor)
		{
			UmlClass umlClass = new UmlClass(messageDescriptor.Name);
			foreach (var field in messageDescriptor.Fields.InDeclarationOrder())
			{
				var umlField = CreateProtobufField(field);
				umlClass.UmlFields.Add(umlField);
			}
			return umlClass;
		}

		protected virtual UmlMethod CreateProtobufMethod(MethodDescriptor method)
		{
			
			UmlMethod umlMethod = new UmlMethod(method.Name);
			//if(method.HasInputType)
			//{
				umlMethod.InputType = method.InputType.Name;
			//}
			//if(method.HasOutputType)
			//{
				umlMethod.OutputType = method.OutputType.Name;
			//}
			return umlMethod;
		}

		protected virtual UmlField CreateProtobufField(FieldDescriptor field)
		{
			UmlField umlField = new UmlField(field.Name);
			//if (field.HasType)
			//{
				umlField.Type = field.FieldType.ToString();
			//}
			return umlField;
		}
	}
}
