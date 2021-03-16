using System;
using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Sample.Models
{
	public sealed class SectionModel
	{
		public SectionModel(Type type, string title, string description)
			: this(type, title, Color.Default, description, null)
		{
		}

		public SectionModel(Type type, string title, Color color, string description)
			: this(type, title, color, description, null)
		{
		}

		public SectionModel(Type type, string title, string description, object[] args)
			: this(type, title, Color.Default, description, args)
		{
		}

		public SectionModel(Type type, string title, Color color, string description, object[] args)
		{
			Type = type;
			Title = title;
			Description = description;
			Color = color;
			Args = args;
		}

		public Type Type { get; }

		public string Title { get; }

		public string Description { get; }

		public Color Color { get; }

		public bool UseArgs => Args != null;

		public object[] Args { get; }
	}
}