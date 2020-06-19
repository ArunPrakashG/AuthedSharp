using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct RenewUserSessionRequest {
		public readonly string Session;
		public readonly string UserSession;

		public RenewUserSessionRequest(string _session, string _userSession) {
			Session = _session;
			UserSession = _userSession;
		}
	}
}
