using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ShopNum1.Deploy.App_Code
{
    public class HtmlCompressWhitespaceFilter : Stream
    {
        private CompressOptions compressOptions_0;
        private DeflateStream deflateStream_0;
        private GZipStream gzipStream_0;
        private Stream stream_0;

        public HtmlCompressWhitespaceFilter(Stream contentStream, CompressOptions compressOptions)
        {
            if (compressOptions == CompressOptions.GZip)
            {
                this.gzipStream_0 = new GZipStream(contentStream, CompressionMode.Compress);
                this.stream_0 = this.gzipStream_0;
            }
            else if (compressOptions == CompressOptions.Deflate)
            {
                this.deflateStream_0 = new DeflateStream(contentStream, CompressionMode.Compress);
                this.stream_0 = this.deflateStream_0;
            }
            else
            {
                this.stream_0 = contentStream;
            }
            this.compressOptions_0 = compressOptions;
        }

        public override void Flush()
        {
            this.stream_0.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.stream_0.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.stream_0.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            this.stream_0.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            byte[] dst = new byte[count + 1];
            Buffer.BlockCopy(buffer, offset, dst, 0, count);
            string input = string.Empty;
            try
            {
                input = Encoding.GetEncoding(HttpContext.Current.Request.ContentEncoding.BodyName).GetString(dst);
            }
            catch
            {
                input = Encoding.UTF8.GetString(dst);
            }
            input = Regex.Replace(Regex.Replace(input, @"^\s*", string.Empty, RegexOptions.Compiled | RegexOptions.Multiline), "([\r\n])(?!<script [^>]{0,}>\\w*?</script>)", string.Empty, RegexOptions.Compiled | RegexOptions.Multiline);
            byte[] bytes = null;
            try
            {
                bytes = Encoding.GetEncoding(HttpContext.Current.Request.ContentEncoding.BodyName).GetBytes(input);
            }
            catch
            {
                bytes = Encoding.UTF8.GetBytes(input);
            }
            this.stream_0.Write(bytes, 0, bytes.GetLength(0));
        }

        public override bool CanRead
        {
            get
            {
                return this.stream_0.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return this.stream_0.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return this.stream_0.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return this.stream_0.Length;
            }
        }

        public override long Position
        {
            get
            {
                return this.stream_0.Position;
            }
            set
            {
                this.stream_0.Position = value;
            }
        }
    }


}