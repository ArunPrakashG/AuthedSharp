namespace AuthedSharp.Models.Parameters {
	public struct UpdateUserFieldRequest {
		public readonly string ApplicationSession;
		public readonly UserField Field;
		public readonly string FieldValue;
		public readonly string UserSession;

		/// <summary>
		/// Updates a user field.
		/// </summary>
		/// <param name="_appSession"></param>
		/// <param name="_field">The field to update.</param>
		/// <param name="_fieldValue">The value to update on the field.</param>
		/// <param name="_userSession">The user session.</param>
		public UpdateUserFieldRequest(string _appSession, UserField _field, string _fieldValue, string _userSession) {
			ApplicationSession = _appSession;
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
