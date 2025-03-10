namespace coding_lms.data {
	public class QuestionView {

		private string _title;
		public string Title {
			get {
				return _title;
			}
			set {
				_title = value;
			}
		}

		private string _body;
		public string Body {
			get {
				return _body;
			}
			set {
				_body = value;
			}
		}

		private bool _active;
		public bool IsActive {
			get {
				return _active;
			}
			set {
				_active = value;
			}
		}

	}
}