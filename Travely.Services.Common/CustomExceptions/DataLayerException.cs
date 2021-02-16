using System;

namespace Travely.Services.Common.CustomExceptions
{
	public class DataLayerException : Exception
	{
		public DataLayerException(string message)
		: base(message)
		{ }
	}
}