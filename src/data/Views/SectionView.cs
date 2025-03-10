namespace coding_lms.data {
	public class SectionView {


		private int _term;
		public int Term {
			get { return _term; }
			set { _term = value; }
		}

		private string _course;
		public string Course {
			get { return _course; }
			set { _course = value; }
		}

		public string ID {
			get { return $"{Term}-{CRN}"; }
		}

		private int _crn;
		public int CRN {
			get { return _crn; }
			set { _crn = value; }
		}

		private int _cnt;
		public int StudentCount {
			get { return _cnt; }
			set { _cnt = value; }
		}

	}
}