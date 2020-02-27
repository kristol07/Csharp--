using System;

namespace CsharpTest
{
    [Flags]
    enum CardDeckSettings : uint
    {
        SingleDeck = 0x01,
        LargePictures = 0x02,
        FancyNumbers = 0x04,
        Animation = 0x08
    }

    class FlagsEnum
    {

        public bool UseAnimationAndFancyNumbers(CardDeckSettings ops)
        {
            CardDeckSettings testFlags =  CardDeckSettings.Animation 
                                        | CardDeckSettings.FancyNumbers;
            return ops.HasFlag(testFlags);
        }

        static public void PrintEnumNames()
        {
            CardDeckSettings ops;

            ops = CardDeckSettings.FancyNumbers;
            Console.WriteLine(ops.ToString());

            ops = CardDeckSettings.FancyNumbers | CardDeckSettings.Animation;
            Console.WriteLine(ops.ToString());

            Console.WriteLine("Second member of CardDeckSettings is {0}", 
                        Enum.GetName(typeof(CardDeckSettings), 1));

            foreach (var name in Enum.GetNames(typeof(CardDeckSettings)))
            {
                Console.WriteLine(name);
            }
        }
    }
}