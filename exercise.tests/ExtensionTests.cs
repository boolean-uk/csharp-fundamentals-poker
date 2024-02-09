using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
	class ExtensionTest
	{

		//{("K","5","8"),("3","7","8")} => false out ("","","")
		[Test]
		public void ScenarioE1()
		{


			Extension extension = new Extension();

			List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
		{
			new Tuple<string, string, string>("K", "5", "8"),
			new Tuple<string, string, string>("3","7", "8"),
			new Tuple<string, string, string>("2","8", "8")
		};
			Tuple<string, string, string> winner;

			bool result = extension.winningThree(hand, out winner);

			Assert.That(result, Is.False);
			Assert.That(winner.Item1, Is.EqualTo(String.Empty));
			Assert.That(winner.Item2, Is.EqualTo(String.Empty));
			Assert.That(winner.Item3, Is.EqualTo(String.Empty));

		}

		//{("K","5","J"), ("J","A","J"),("2","2", "2")} => true out ("2","2","2")
		[Test]
		public void ScenarioEb()
		{

			Extension extension = new Extension();

			List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>

		 {
			new Tuple<string, string, string>("K", "5","J"),
			new Tuple<string, string, string>("J","A","J"),
			new Tuple<string, string, string>("2","2","2")
		};

			Tuple<string, string, string> winner;

			bool result = extension.winningThree(hand, out winner);

			Assert.That(result, Is.True);
			Assert.That(winner.Item1, Is.EqualTo("2"));
			Assert.That(winner.Item2, Is.EqualTo("2"));
			Assert.That(winner.Item3, Is.EqualTo("2"));
		}

		//("J","J","J"), ("K","K","K"), ("A","A","A")} => true out ("A","A","A")
		[Test]
		public void ScenarioE2()
		{
			Extension extension = new Extension();

			List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>

		{
			new Tuple<string, string, string>("J","J","J"),
			new Tuple<string, string, string>("K","K","K"),
			new Tuple<string, string, string>("A","A","A")
		};

			Tuple<string, string, string> winner;
			bool result = extension.winningThree(hand, out winner);

			Assert.That(result, Is.True);

			Assert.IsTrue(winner.Item1 == "A" && winner.Item2 == "A" && winner.Item3 == "A");

		}

		//{("4","3","2"),("6","6","6"),("7","7","7"),("3","3","3")}  => true ("7","7","7")
		[Test]
		public void ScenarioE3()
		{
			Extension extension = new Extension();

			List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>

		{
			new Tuple< string, string, string >("4", "3", "2"),
			new Tuple< string, string, string >("6", "6", "6"),
			new Tuple< string, string, string >("7", "7", "7"),
			new Tuple< string, string, string >("3","3", "3")
		};
			Tuple<string, string, string> winner;
			bool result = extension.winningThree(hand, out winner);

			Assert.That(result, Is.True);

			Assert.IsTrue(winner.Item1 == "7" && winner.Item2 == "7" && winner.Item3 == "7");

		}
	}
}
