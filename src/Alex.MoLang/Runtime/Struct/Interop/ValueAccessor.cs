using System;
using Alex.MoLang.Runtime.Value;

namespace Alex.MoLang.Runtime.Struct.Interop
{
	public abstract class ValueAccessor
	{
		public event EventHandler ValueChanged; 
		public bool Observable { get; internal set; }

		public abstract bool CanRead { get; }
		public abstract bool CanWrite { get; }

		public abstract IMoValue Get(object instance);
		public abstract void Set(object instance, IMoValue value);

		protected void InvokeChanged()
		{
			ValueChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}