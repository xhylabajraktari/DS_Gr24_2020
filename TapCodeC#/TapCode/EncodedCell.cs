using System;
using System.Collections.Generic;
using System.Text;

namespace TapCode
{
    public class EncodedCell
    {
        public string X_Encoded { get; set; }
        public string Y_Encoded { get; set; }
        public EncodedCell()
        {

        }

        public EncodedCell(string x_enc, string y_enc)
        {
            this.X_Encoded = x_enc;
            this.Y_Encoded = y_enc;
        }

    }
}
