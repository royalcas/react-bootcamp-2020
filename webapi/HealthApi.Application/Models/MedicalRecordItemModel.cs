using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApi.Application.Models
{
	public class MedicalRecordItemModel: Model
	{
		public DateTime Date { get; set; }
		public string Details { get; set; }
		public string Treatment { get; set; }
		public string UserId { get; set; }
	}
}
