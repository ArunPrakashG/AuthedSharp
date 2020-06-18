using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct VerifyRequest {
		public readonly string ApplicationID;
		public readonly string AccessToken;

		public VerifyRequest(string _applicationID, string _accessToken) {
			ApplicationID = _applicationID ?? throw new ArgumentNullException(nameof(_applicationID));
			AccessToken = _accessToken ?? throw new ArgumentNullException(nameof(_applicationID));
		}
	}
}
