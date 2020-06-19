using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct GetUserRequest {
		public readonly string Session;
		public readonly string UserSession;

		public GetUserRequest(string _session, string _userSession) {
			Session = _session;
			UserSession = _userSession;
		}
	}
}
