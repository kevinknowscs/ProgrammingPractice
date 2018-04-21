
namespace App.Problems.BoggleWords
{
  class BoggleDice
  {
    public BoggleDice(string firstChars, string secondChars)
    {
      FirstChars = firstChars;
      SecondChars = secondChars;
    }

    public string FirstChars { get; private set; }

    public string SecondChars { get; private set; }
  }
}
