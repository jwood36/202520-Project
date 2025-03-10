namespace coding_lms.data {
	public class Term {

		private int _id;
		public int ID {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}

		private int _yr;
		public int SchoolYear {
			get {
				return _yr;
			}
			set {
				_yr = value;
			}
		}

		private TermEnum _nm;
		public TermEnum Name {
			get {
				return _nm;
			}
			set {
				_nm = value;
			}
		}

	}
}