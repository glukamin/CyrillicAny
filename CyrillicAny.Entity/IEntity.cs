using System;

namespace CyrillicAny.Entity
{
	public interface IEntity
	{
		public DateTime Created { get; set; }

		public int Id { get; set; }

		public DateTime Modified { get; set; }
	}
}