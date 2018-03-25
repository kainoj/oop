using NUnit.Framework;
using builder;
using System.IO;
using System;

namespace Tests {

    class TagBuilderTest {

        [Test]
        public void tagBuilderTest() {
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
                    .AddContent( "childbody" )
                    .EndTag()
                .EndTag()
            .StartTag( "script" )
            .AddContent( "$.scriptbody();")
            .EndTag();


            string ans ="<parent parentproperty1='true' parentproperty2='5'>\n" + 
                            "    <child1 childproperty1='c'>\n" +
                                "        childbody\n" +
                            "    </child1>\n" +
                            "    <child2 childproperty2='c'>\n" +
                                "        childbody\n" +
                            "    </child2>\n" +
                        "</parent>\n" +
                        "<script>\n" +
                            "    $.scriptbody();\n" +
                        "</script>\n";
            
            Assert.AreEqual(ans, tag.ToString());
            // System.Console.WriteLine(tag.ToString());
            // throw new Exception(tag.ToString());
            
        }

    }

}