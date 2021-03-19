using System;

namespace Travely.Services.Common.CustomExceptions
{
	public class NotFoundException : BusinessLayerException
	{
		public NotFoundException(string name, object key)
		: base($"Entity \"{name}\" ({key}) was not found.")
		{ }
	}
}