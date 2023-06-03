using ContactoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactoAPI.Services
{
    public interface IContactoRepository
    {
		public Task<List<Contacto>> GetContactosAsync();
		public Task<Contacto> GetContactoAsync(int ContactoId);
		public Task<bool> AddContactoAsync(Contacto contacto);
		public Task<bool> UpdateContactoAsync(Contacto contacto);
		public Task<bool> DeleteContactoAsync(int ContactoId);

	}
}
