using System;

namespace NullableReferenceTypes
{
#nullable enable
    public class NullForgivingOperator
    {

        public NullForgivingOperator(string sampleProperty)
        {
            var Settings = new S();
            var CC = new S();
            var num = 2;
            var (msg, isCC, upd) = num switch
            {
                1 =>  ("Use this mode when you are first learning the phrases and their meanings.", Settings.Cc == CC.H, false),
                2 =>  ("Use this mode to help you memorize the phrases and their meanings.",Settings.Cc == CC.H,false),
                3 =>  ("Use this mode to run a self marked test.",Settings.Cc == CC.H,true),
               _ => default,
            };
        

        SampleProperty = sampleProperty ?? throw new ArgumentNullException(nameof(sampleProperty)); ;
        }

        public string SampleProperty { get; set; }
    }

    public class S
    {
        public bool Cc { get; set; }
        public bool H { get; set; }
    }
}
