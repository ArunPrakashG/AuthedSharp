using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct UpdateField {
		public readonly bool Value;
		public readonly AppField Field;

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

		public UpdateAppRequest(string _appSecret, UpdateField _field, string _session) {
			AppSecret = _appSecret;
			FieldInfo = _field;
			ApplicationSession = _session;
		}
	}
}
