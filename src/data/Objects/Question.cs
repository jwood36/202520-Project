namespace coding_lms.data {
	public class Question {
		public Question(Guid id) : this() { }
		public Question(long id) : this() { }
		private Question() {
			this._answ = new List<Answer>();
		}

		private IEnumerable<Answer> _answ;
		public IEnumerable<Answer> Answers { get; set; }

	}
}