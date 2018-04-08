using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace caesar {

    public class CaesarStream : Stream {
        Stream _stream;
        private int _shift;

        public CaesarStream(Stream stream, int shift) {
            this._stream = stream;
            this._shift = shift;
        }

        private byte shiftByte(byte b) {
            var shifted = b + _shift;
            return (byte) (shifted % Byte.MaxValue);
        }

        public override void Write(byte[] buffer, int offset, int count) {
            _stream.Write(buffer.Select(shiftByte).ToArray(), offset, count);            
        }

        public override int Read(byte[] buffer, int offset, int count) {
            int read = _stream.Read(buffer, offset, count);
            for(int i = 0; i < read; i++) {
                buffer[i] = shiftByte(buffer[i]);
            }
            return read;
        }

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position { get => _stream.Position; 
                                        set => _stream.Position = value; }

        public override void Flush() {
            _stream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin) {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value) {
            _stream.SetLength(value);
        }
    }
}