using System;
using singleton.process;
using singleton.thread;
using builder;

namespace creational
{
    class Program
    {
        static void Main(string[] args)
        {
            TagBuilder tag = new TagBuilder();
            tag.IsIndnted = true;
            tag.Indentation = 4;

            tag.StartTag( "parent" )
                .AddAttribute( "parentproperty1", "true" )
                .AddAttribute( "parentproperty2", "5" )
                    .StartTag( "child1")
                    .AddAttribute( "childproperty1", "c" )
                    .AddContent( "childbody" )
                    .EndTag()
                    .StartTag( "child2" )
                    .AddAttribute( "childproperty2", "c" )
                    .AddContent( "child2body" )
                    .EndTag()
                .EndTag()
                .StartTag( "script" )
                .AddContent( "$.scriptbody();")
                .EndTag();

            Console.WriteLine(tag.ToString());

        }
    }
}
