using System;

namespace Travely.Services.Common.CustomExceptions
{
	public abstract class DataLayerException : Exception
	{
		public DataLayerException(string message)
		: base(message)
		{ }
	}
}