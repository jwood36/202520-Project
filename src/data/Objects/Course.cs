namespace coding_lms.data {
	public class Course {
		public Course(string dept, string num) : this() {
			this._dept = dept;
			this._num = num;
		}
		internal Course(string id) { this._id = id; }
		public Course() { }

		private string _id;
		public string ID {
			get { return _id; }
			set { _id = value; }
		}

		private string _dept;
		public string Department {
			get { return _dept; }
			set { _dept = value; }
		}

		private string _num;
		public string Number {
			get { return _num; }
			set { _num = value; }
		}

	}
}