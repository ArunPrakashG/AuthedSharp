using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Responses.UserResponses {
	public class LoginResponse : BaseResponse {
		[JsonProperty("userSession")]
		public string UserSession { get; set; }
	}
}
