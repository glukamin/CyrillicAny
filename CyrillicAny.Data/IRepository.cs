using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CyrillicAny.Entity;

namespace CyrillicAny.Data
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<T> Add(T entity);
	}
}