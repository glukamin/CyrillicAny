using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyrillicAny.Entity
{
	public class BaseEntity : IEntity
	{
		public DateTime Created { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }

		public DateTime Modified { get; set; }
	}
}