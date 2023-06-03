using ContactoAPI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactoAPI.Services
{
	public class ContactoService : IContactoRepository
	{
		private static string _baseUrl;

		public ContactoService()
		{
			_baseUrl = "http://10.0.2.2:5291";
		}
		public async Task<bool> AddContactoAsync(Contacto contacto)
		{
			bool success = false;

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(_baseUrl);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var json = JsonConvert.SerializeObject(contacto);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await httpClient.PostAsync("api/Contactos", content);

				if (response.IsSuccessStatusCode)
				{
					success = true;
				}
			}

			return success;
		}

		public async Task<bool> DeleteContactoAsync(int ContactoId)
		{
			var success = false;

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(_baseUrl);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await httpClient.DeleteAsync($"api/Contactos/{ContactoId}");

				if (response.IsSuccessStatusCode)
				{
					success = true;
				}
			}

			return success;
		}

		public async Task<Contacto> GetContactoAsync(int ContactoId)
		{
			var contactos = new Contacto();

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(_baseUrl);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await httpClient.GetAsync($"api/Contactos/{ContactoId}");

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					contactos = JsonConvert.DeserializeObject<Contacto>(json);
				}
			}

			return contactos;
		}

		public async Task<List<Contacto>> GetContactosAsync()
		{
			var contactos = new List<Contacto>();

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(_baseUrl);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await httpClient.GetAsync("api/Contactos");

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					contactos = JsonConvert.DeserializeObject<List<Contacto>>(json);
				}
			}
			Console.WriteLine("///////////////////////////////////////////////////////");
			foreach (var contacto in contactos)
			{
				Console.WriteLine(contacto.Nombre);
			}
			Console.WriteLine("///////////////////////////////////////////////////////");
			return contactos;
		}

		public async Task<bool> UpdateContactoAsync(Contacto contacto)
		{
			var success = false;

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(_baseUrl);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var json = JsonConvert.SerializeObject(contacto);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await httpClient.PutAsync($"api/Contactos/{contacto.ContactoId}", content);

				if (response.IsSuccessStatusCode)
				{
					success = true;
				}
			}

			return success;
		}
	}
}
