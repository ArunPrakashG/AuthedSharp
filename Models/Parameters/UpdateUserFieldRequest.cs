using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct UpdateUserFieldRequest {
		public readonly string Session;
		public readonly UserField Field;
		public readonly string FieldValue;
		public readonly string UserSession;

		public UpdateUserFieldRequest(string _session, UserField _field, string _fieldValue, string _userSession) {
			Session = _session;
			Field = _field;
			FieldValue = _fieldValue;
			UserSession = _userSession;
		}

		public enum UserField {
			password,
			email,
			identifier,
			isBanned,
			membershipId
		}
	}
}
