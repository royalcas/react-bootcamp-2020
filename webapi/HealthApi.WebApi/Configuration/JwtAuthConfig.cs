using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthApi.WebApi.Configuration
{
	public class JwtAuthConfig
	{
		public string Key { get; set; }
		public string Issuer { get; set; }

		public int ExpireDays { get; set; }
	}
}
