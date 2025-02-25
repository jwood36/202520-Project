using System.ComponentModel;

namespace coding_lms.data {

	[DefaultValue(value: UNKNOWN)]
	public enum QuestionEnum {
		TF = 1
		, MCL = 2
		, MCN = 3
		, MAL = 4
		, MAN = 5

		// DEFAULT
		, UNKNOWN = -1
	}
}