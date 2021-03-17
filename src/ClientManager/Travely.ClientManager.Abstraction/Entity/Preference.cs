using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.ClientManager.Abstraction.Entity
{
	[Table("Preference")]
	public class Preference : BaseEntity
	{
		public string Note { get; set; }
	}
}
