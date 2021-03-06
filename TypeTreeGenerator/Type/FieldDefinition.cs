﻿namespace TypeTreeGenerator
{
	public sealed class FieldDefinition
	{
		public override string ToString()
		{
			if(Type == null)
			{
				return base.ToString();
			}
			return $"{Type} {Name}";
		}



		private string GetPropertyName(string name)
		{
			if (name.StartsWith("m_"))
			{
				name = name.Substring(2);
			}

			if (char.IsUpper(name[0]))
			{
				return name;
			}
			else
			{
				char firstLetter = char.ToUpper(name[0]);
				string part = name.Substring(1);
				return $"{firstLetter}{part}";
			}
		}

		private string GetFieldName(string name)
		{
			if (char.IsUpper(name[0]))
			{
				char firstLetter = char.ToLower(name[0]);
				string part = name.Substring(1);
				return $"m_{firstLetter}{part}";
			}

			if (name.StartsWith("m_"))
			{
				if (char.IsLower(name[2]))
				{
					return name;
				}

				char firstLetter = char.ToLower(name[2]);
				string part = name.Substring(3);
				return $"m_{firstLetter}{part}";
			}

			return $"m_{name}";
		}

		public TypeDefinition Type { get; set; }
		public string Name { get; set; }
		public bool IsArray { get; set; }
		public bool IsAlign { get; set; }

		public string TypeExportName
		{
			get
			{
				if(IsArray)
				{
					return Type.Fields[0].TypeExportName;
				}
				return Type.ExportName;
			}
		}
		public string ExportFieldName => GetFieldName(Name);
		public string ExportPropertyName => GetPropertyName(Name);
	}
}
