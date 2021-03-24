using System;

namespace Travely.Services.Common.CustomExceptions
{
	public class BadRequestException : BusinessLayerException
	{
		public BadRequestException(string message)
			: base(message)
		{
		}
	}
}