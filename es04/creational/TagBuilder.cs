using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace builder {

    public class TagBuilder {

        public TagBuilder() { }
    
        public TagBuilder(string TagName, TagBuilder Parent) {
            this.tagName = TagName;
            this.parent = Parent;
           
            // Indentation feature
            this.Indentation = Parent.Indentation;
            this.IsIndnted = Parent.IsIndnted;
            this._level = Parent._level + 1;
        }

        public TagBuilder(StringWriter writer) {
            this.writer = writer;
        }
    
        private string tagName;
        private TagBuilder parent;
        private StringBuilder body = new StringBuilder();
        private Dictionary<string, string> _attributes = new Dictionary<string, string>();
    
        /*  Indentation feature */
        public bool IsIndnted {set; get;} = false;
        public int Indentation {set; get; }
        private StringWriter writer;
        private int _level = 0;

        public TagBuilder AddContent( string Content ) {
            body.Append(_indents());
            body.Append( Content );
            body.Append(_newLine());
            return this;
        }
    
        public TagBuilder AddContentFormat( string Format, params object[] args ) {
            body.AppendFormat( Format, args );
            return this;
        }
    
        public TagBuilder StartTag( string TagName ) {
            TagBuilder tag = new TagBuilder( TagName, this );
            return tag;
        }
    
        public TagBuilder EndTag() {
            parent.AddContent( this.ToString() );
            return parent;
        }
    
        public TagBuilder AddAttribute( string Name, string Value ) {
            _attributes.Add( Name, Value );
            return this;
        }
    
        private string _newLine() {
            return IsIndnted ? "\n": "";
        }

        private string _indents(int modifier = 0) {
            return "".PadLeft((_level + modifier) * Indentation);
        }

        
        public override string ToString() {
            StringBuilder tag = new StringBuilder();
    
            // preamble
            if ( !string.IsNullOrEmpty( this.tagName ) )
                tag.AppendFormat("<{0}", tagName, _indents());
    
            if ( _attributes.Count > 0 )
            {
                tag.Append( " " );
                tag.Append( 
                    string.Join( " ", 
                        _attributes
                            .Select( 
                                kvp => string.Format( "{0}='{1}'", kvp.Key, kvp.Value ) )
                            .ToArray() ) );
            }
    
            // body/ending
            if ( body.Length > 0 )
            {
                if ( !string.IsNullOrEmpty( this.tagName) || this._attributes.Count > 0 )
                    tag.AppendFormat(">{0}", _newLine());

                tag.Append( body.ToString() );

                if ( !string.IsNullOrEmpty( this.tagName ) )
                    tag.AppendFormat( "{2}</{0}>{1}", this.tagName, "", _indents(-1));
            }
            else
                if ( !string.IsNullOrEmpty( this.tagName ) )
                    tag.AppendFormat( "/>{0}", _newLine());
    
            return tag.ToString();
        }
    }
}