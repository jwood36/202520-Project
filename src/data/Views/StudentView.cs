using System;

namespace coding_lms.data {
	public class StudentView {

		private Guid _uuid;
		public Guid UUID {
			get {
				return _uuid;
			}
			set {
				_uuid = value;
			}
		}

		private string _lastname;
		public string LastName {
			get {
				return _lastname;
			}
			set {
				_lastname = value;
			}
		}

		private string _firstname;
		public string FirstName {
			get {
				return _firstname;
			}
			set {
				_firstname = value;
			}
		}

		private string _email;
		public string Email {
			get {
				return _email;
			}
			set {
				_email = value;
			}
		}

	}
}