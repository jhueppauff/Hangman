using NUnit.Framework;


namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IntegrationTest()
        {
            var sut = new Hangman.Hangman("Developer");

            Assert.That(sut.Guess('u'), Is.EqualTo("---------"));
            Assert.That(sut.Guess('e'), Is.EqualTo("-e-e---e-"));
            Assert.That(sut.Guess('n'), Is.EqualTo("-e-e---e-"));
            Assert.That(sut.Guess('o'), Is.EqualTo("-e-e-o-e-"));
            Assert.That(sut.Guess('r'), Is.EqualTo("-e-e-o-er"));
            Assert.That(sut.Guess('a'), Is.EqualTo("-e-e-o-er"));
            Assert.That(sut.Guess('d'), Is.EqualTo("De-e-o-er"));
            Assert.That(sut.Guess('l'), Is.EqualTo("De-elo-er"));
            Assert.That(sut.Guess('p'), Is.EqualTo("De-eloper"));
            Assert.That(sut.Guess('v'), Is.EqualTo("Developer"));
            Assert.That(sut.Guessed, Is.True);
        }

        [Test]
        public void CorrectGuessAfterCtor()
        {
            var sut = new Hangman.Hangman("Developer");
            Assert.That(sut.Guess('e'), Is.EqualTo("-e-e---e-"));
        }
    }
}