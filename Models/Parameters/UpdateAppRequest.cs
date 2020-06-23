namespace AuthedSharp.Models.Parameters {
	public struct UpdateField {
		public readonly bool Value;
		public readonly AppField Field;

		/// <summary>
		/// Updates a field defined in <see cref="AppField"/>.
		/// </summary>
		/// <param name="_value">The update value of <see cref="AppField"/> field.</param>
		/// <param name="_field">The field.</param>
		public UpdateField(bool _value, AppField _field) {
			Value = _value;
			Field = _field;
		}

		public enum AppField {
			isFree,
			isLocked
		}
	}

	public struct UpdateAppRequest {
		public readonly string AppSecret;
		public readonly UpdateField FieldInfo;
		public readonly string ApplicationSession;

		/// <summary>
		/// Request to update an app field.
		/// </summary>
		/// <param name="_appSecret">The application secret.</param>
		/// <param name="_field">The field to update.</param>
		/// <param name="_appSession">The application session.</param>
		public UpdateAppRequest(string _appSecret, UpdateField _field, string _appSession) {
			AppSecret = _appSecret;
			FieldInfo = _field;
			ApplicationSession = _appSession;
		}
	}
}
