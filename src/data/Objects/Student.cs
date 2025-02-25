using System;

namespace coding_lms.data {
	public class Student {
		public Student(string srn) {
			this._srn = srn;
		}

		private void Init() {
			// Initialize DB Connection

			// Submit Query to obtian Student Information

		}

		private long _id;
		public long ID {
			get { return _id; }
			set { _id = value; }
		}

		private Guid _uuid;
		public Guid UUID {
			get { return _uuid; }
			set { _uuid = value; }
		}

		private string _email;

		public string Email {
			get { return _email; }
			set { _email = value; }
		}

		private string _srn;

		public string SRN {
			get { return _srn; }
			set { _srn = value; }
		}

		private String _fname;

		public String FirstName {
			get { return _fname; }
			set { _fname = value; }
		}

		private string _lname;

		public string LastName {
			get { return _lname; }
			set { _lname = value; }
		}

		public string FullName {
			get { return $"{this._lname}, {this._fname}"; }
		}
	}
}