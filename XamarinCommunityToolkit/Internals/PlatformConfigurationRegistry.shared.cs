using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms
{
	class PlatformConfigurationRegistry<TElement> : IElementConfiguration<TElement>
		where TElement : Element
	{
		readonly TElement element;
		readonly Dictionary<Type, object> platformSpecifics = new Dictionary<Type, object>();

		internal PlatformConfigurationRegistry(TElement element)
		{
			this.element = element;
		}

		public IPlatformElementConfiguration<T, TElement> On<T>() where T : IConfigPlatform
		{
			if (platformSpecifics.ContainsKey(typeof(T)))
			{
				return (IPlatformElementConfiguration<T, TElement>)platformSpecifics[typeof(T)];
			}

			var emptyConfig = Configuration<T, TElement>.Create(element);

			platformSpecifics.Add(typeof(T), emptyConfig);

			return emptyConfig;
		}
	}
}
