using System.Collections.Generic;

namespace coding_lms.data {
	public class QuizPool {
		public QuizPool() { }

		public IEnumerable<Question> Questions { get; set; }

	}
}