using NUnit.Framework;
using System;

namespace Hangman.Tests
{
    public class BaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IntegrationTest()
        {
            var sut = new Hangman("Developer");

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
        public void GuessedIsTrueAfterWordIsGuessed()
        {
            var sut = new Hangman("One");

            sut.Guess('o');
            Assert.That(sut.Guessed, Is.False);
            sut.Guess('n');
            Assert.That(sut.Guessed, Is.False);
            sut.Guess('e');
            Assert.That(sut.Guessed, Is.True);
        }

        [Test]
        public void CorrectGuessAfterCtor()
        {
            var sut = new Hangman("Developer");
            Assert.That(sut.Guess('e'), Is.EqualTo("-e-e---e-"));
        }

        [Test]
        public void WrongGuessAfterCtor()
        {
            var sut = new Hangman("Developer");
            Assert.That(sut.Guess('x'), Is.EqualTo("---------"));
            Assert.That(sut.Result, Is.EqualTo("---------"));
        }

        [Test]
        public void ExceptionThrownIfWordContainsHypen()
        {
            var e = Assert.Throws<ArgumentException>(() => new Hangman("-"));
            Assert.That(e.Message, Is.EqualTo("Word must not contain hyphen '-'"));
        }

        [Test]
        public void CapitalLetterAreFound()
        {
            var sut = new Hangman("dDBb");
            Assert.That(sut.Guess('d'), Is.EqualTo("dD--"));
            Assert.That(sut.Guess('b'), Is.EqualTo("dDBb"));
        }

        [Test]
        public void ResultIsCorrect()
        {
            var sut = new Hangman("result");

            sut.Guess('r');
            sut.Guess('e');
            sut.Guess('s');

            Assert.That(sut.Result, Is.EqualTo("res---"));
        }

        [Test]
        public void WordHasBeenSolved()
        {
            var sut = new Hangman("word");

            sut.Guess('w');
            sut.Guess('o');
            sut.Guess('d');
            sut.Guess('r');

            var e = Assert.Throws<ArgumentException>(() => sut.Guess('x'));
            Assert.That(e.Message, Is.EqualTo("Word has been already solved!"));
        }
    }
}