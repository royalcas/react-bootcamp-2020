using System.Net;

namespace HealthApi.WebApi.Exception
{
	public class HttpResponseException : System.Exception
	{
		public HttpStatusCode Status { get; set; } = HttpStatusCode.BadRequest;
		public object Value { get; set; }
	}
}
